using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMModelAws
{
    MonoBehaviour Component;
    IMBeanFramework BeanFramework;
    string QueueId;
    string QueuePwd;
    string Message;

    static List<string> SendMessageList = new List<string>();

    public IMModelAws(MonoBehaviour component, IMBeanFramework beanFramework, string queueId, string queuePwd, string message)
    {
        this.Component = component;
        this.BeanFramework = beanFramework;
        this.QueueId = queueId;
        this.QueuePwd = queuePwd;
        this.Message = message;
    }

    public IEnumerator Main()
    {
        lock (IMDaoAws.GetInstance())
        {
            return this.MainLocked();
        }
    }

    IEnumerator MainLocked()
    {
        var queueIdTemp = this.QueueId.Replace(" ", "");
        if (queueIdTemp != this.BeanFramework.QueueId)
        {
            this.BeanFramework.QueueId = queueIdTemp;
            IMDaoAws.GetInstance().Sqs = null;
            return this.UpdateQueueUrl();
        }
        if (IMDaoAws.GetInstance().Sqs == null)
        {
            SendMessageList.Add(this.QueuePwd + this.Message);
            return null;
        }
        return this.SendMessage();
    }

    IEnumerator UpdateQueueUrl()
    {
        return IMDaoAws.GetInstance().GetQueueUrl(QueueId, (beanUpdateQueueUrl) =>
        {
            this.BeanFramework.BeanUpdateQueueUrl = beanUpdateQueueUrl;
            this.SendMessage();
        });
    }

    IEnumerator SendMessage()
    {
        return IMDaoAws.GetInstance().SendMessage(this.BeanFramework.BeanUpdateQueueUrl.QueueUrl, this.QueuePwd + this.Message, () =>
        {
            while (SendMessageList.Count > 0)
            {
                IMDaoAws.GetInstance().SendMessage(this.BeanFramework.BeanUpdateQueueUrl.QueueUrl, SendMessageList[0], () => { });
                SendMessageList.RemoveAt(0);
            }
        });
    }
}
