using Amazon.SQS;
using Amazon.SQS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Controls;

namespace InternetMouse.Model
{
    public class ModelAws
    {
        const string URL_CREATE_QUEUE = "https://x5pdzbgoo6.execute-api.ap-northeast-1.amazonaws.com/prod/imCreateQueue";

        BeanCreateQueue beanCreateQueue { get; set; }

        AmazonSQSClient _sqs;
        AmazonSQSClient Sqs
        {
            get
            {
                return this._sqs ?? (this._sqs = new AmazonSQSClient(this.beanCreateQueue.AccessKeyId, this.beanCreateQueue.SecretAccessKey, this.beanCreateQueue.SessionToken, Amazon.RegionEndpoint.APNortheast1));
            }
        }

        CancellationTokenSource cts = new CancellationTokenSource();
        public void EndReceiveMessage()
        {
            this.cts.Cancel();
            this.TextBoxId.IsEnabled = true;
            this.PasswordBoxPassword.IsEnabled = true;
            this.ButtonConnect.IsEnabled = true;
            this.ButtonDisconnect.IsEnabled = false;
        }

        readonly Regex RegexP     = new Regex(@"^(P,[^,]*,)");
        readonly Regex RegexPPart = new Regex(@"^(P),([^,]*),");
        readonly Regex RegexM     = new Regex(@"^(M,\d*,-?\d*,-?\d*,-?\d*,?)");
        readonly Regex RegexMPart = new Regex(@"^(M),(\d*),(-?\d*),(-?\d*),(-?\d*)");
        readonly Regex RegexK     = new Regex(@"^(K,[\dA-Z]{2},\d,?)");
        readonly Regex RegexKPart = new Regex(@"^(K),([\dA-Z]{2}),(\d)");

        public TextBox TextBoxId;
        public PasswordBox PasswordBoxPassword;
        public Button ButtonConnect;
        public Button ButtonDisconnect;
        public TextBox TextBoxLog;

        public async void CreateQueue()
        {
            try
            {
                this.TextBoxId.IsEnabled = false;
                this.PasswordBoxPassword.IsEnabled = false;
                this.ButtonConnect.IsEnabled = false;
                this.ButtonDisconnect.IsEnabled = true;

                this.AddLog("Create queue start");
                this.beanCreateQueue = null;
                var response = await new HttpClient().GetAsync(URL_CREATE_QUEUE + "?queueId=" + this.TextBoxId.Text.Replace(" ", "").Replace("　", ""), cts.Token);
                var content = await response.Content.ReadAsStringAsync();
                this.beanCreateQueue = JsonConvert.DeserializeObject<BeanCreateQueue>(content);
                if (this.beanCreateQueue.Message != null)
                {
                    this.AddLog(this.beanCreateQueue.Message);
                    this.EndReceiveMessage();
                    return;
                }
                //タイムアウト
                if (this.beanCreateQueue.QueueUrl == null ||
                    this.beanCreateQueue.AccessKeyId == null ||
                    this.beanCreateQueue.SecretAccessKey == null ||
                    this.beanCreateQueue.SessionToken == null)
                {
                    this.AddLog(content);
                    this.EndReceiveMessage();
                    return;
                }
                this.UpdateId();
                this.AddLog("Create queue complete");

                var receiveReq = new ReceiveMessageRequest()
                {
                    QueueUrl = this.beanCreateQueue.QueueUrl,
                    VisibilityTimeout = 43200,
                    WaitTimeSeconds = 20
                };

                while (true)
                {
                    var receive = await this.Sqs.ReceiveMessageAsync(receiveReq, this.cts.Token);
                    foreach (var message in receive.Messages)
                    {
                        this.Input(message.Body);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                this.AddLog("切断");
            }
            catch (Exception e)
            {
                this.AddLog("エラーが発生しました。接続しなおしてください。\n" + e.ToString());
            }
        }

        void UpdateId()
        {
            this.TextBoxId.Dispatcher.Invoke(new Action(() =>
            {
                this.TextBoxId.Text =
                    this.TextBoxId.Text == this.beanCreateQueue.QueueId ?
                    this.beanCreateQueue.QueueId :
                    this.beanCreateQueue.QueueId.Substring(0, this.beanCreateQueue.QueueId.Length / 2) +
                    " " +
                    this.beanCreateQueue.QueueId.Substring(this.beanCreateQueue.QueueId.Length / 2);
            }));
        }
        void AddLog(string str)
        {
            this.TextBoxLog.Dispatcher.Invoke(new Action(() =>
            {
                var txt = DateTime.Now.ToString("[HH:mm:ss]") + str + "\n" + this.TextBoxLog.Text;
                this.TextBoxLog.Text = txt.Substring(0, txt.Length > 10000 ? 10000 : txt.Length);
            }));
        }

        void Input(ReceiveMessageResponse receive)
        {
            foreach (var message in receive.Messages)
            {
                this.Input(message.Body);
            }
        }

        void Input(string message)
        {
            List<ModelInput> inputs = this.GetModelInput(message);
            foreach (var input in inputs)
            {
                input.Input();
            }
        }

        List<ModelInput> GetModelInput(string message)
        {
            var inputs = new List<ModelInput>();

            var command = message;
            string pwd = null;
            while (command != "")
            {
                var groupP = RegexP.Match(command).Groups;
                if (groupP.Count > 1)
                {
                    var groupPPart = RegexPPart.Match(groupP[1].Value).Groups;
                    pwd = groupPPart[2].Value;
                    command = RegexP.Replace(command, "");
                    continue;
                }

                var groupM = RegexM.Match(command).Groups;
                if (groupM.Count > 1)
                {
                    var groupMPart = RegexMPart.Match(groupM[1].Value).Groups;
                    var dwFlags = this.GetValueUintHex(groupMPart[2].Value);
                    var dx = this.GetValueUint(groupMPart[3].Value);
                    var dy = this.GetValueUint(groupMPart[4].Value);
                    var cButtons = this.GetValueInt(groupMPart[5].Value);
                    inputs.Add(new ModelInputMouse(dwFlags, dx, dy, cButtons));
                    command = RegexM.Replace(command, "");
                    continue;
                }

                var groupK = RegexK.Match(command).Groups;
                if (groupK.Count > 1)
                {
                    var groupKPart = RegexKPart.Match(groupK[1].Value).Groups;
                    byte bVk = (byte)this.GetValueIntHex(groupKPart[2].Value);
                    int dwFlags = this.GetValueUintHex(groupKPart[3].Value);
                    inputs.Add(new ModelInputKey(bVk, dwFlags));
                    command = RegexK.Replace(command, "");
                    continue;
                }

                return new List<ModelInput>();
            }

            if (this.PasswordBoxPassword.Password != "" &&
                this.PasswordBoxPassword.Password != pwd)
            {
                return new List<ModelInput>();
            }
            this.AddLog(message);
            return inputs;
        }

        int GetValueIntHex(string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return 0;
            }
            return Convert.ToInt32(val, 16);
        }

        int GetValueInt(string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return 0;
            }
            return int.Parse(val);
        }

        int GetValueUint(string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return 0;
            }
            return int.Parse(val);
        }

        int GetValueUintHex(string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return 0;
            }
            return (int)Convert.ToInt32(val, 16);
        }
    }
}
