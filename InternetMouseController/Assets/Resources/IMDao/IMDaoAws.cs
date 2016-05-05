using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections;
using UnityEngine;

public class IMDaoAws
{
    private static IMDaoAws instance = new IMDaoAws();

    public AmazonSQSClient Sqs;

    public static IMDaoAws GetInstance()
    {
        return instance;
    }

    public IEnumerator GetQueueUrl(string queueId, Action<IMBeanUpdateQueueUrl> callback)
    {
        this.Sqs = null;

        var form = new WWW("https://x5pdzbgoo6.execute-api.ap-northeast-1.amazonaws.com/prod/imGetQueueUrl?queueId=" + queueId);
        yield return form;
        Debug.Log(form.text);
        var bean = JsonUtility.FromJson<IMBeanUpdateQueueUrl>(form.text);

        if (bean.AccessKeyId == null || bean.SecretAccessKey == null || bean.SessionToken == null)
        {
            IMCoroutine.CoroutineList.RemoveAll(p => true);
        }
        else
        {
            this.Sqs = new AmazonSQSClient(bean.AccessKeyId, bean.SecretAccessKey, bean.SessionToken, Amazon.RegionEndpoint.APNortheast1);
            callback(bean);
        }
    }

    public IEnumerator SendMessage(string queueUrl, string message, Action callback)
    {
        Sqs.SendMessageAsync(new SendMessageRequest()
        {
            QueueUrl = queueUrl,
            MessageBody = message
        }, (result) =>
        {
            if (result.Exception == null)
            {
                Debug.LogFormat("Message Sent[{0}]", message);
                callback();
            }
            else
            {
                Debug.LogException(result.Exception);
            }
        });
        return null;
    }
}
