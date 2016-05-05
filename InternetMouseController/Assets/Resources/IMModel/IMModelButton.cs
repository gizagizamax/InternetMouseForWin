using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IMModelButton
{
    MonoBehaviour Component;
    IMBeanFramework BeanFramework;
    string IdName;
    string PwdName;
    string Message;

    static List<string> SendMessageList = new List<string>();

    public IMModelButton(MonoBehaviour component, IMBeanFramework beanFramework, string idName, string pwdName, string message)
    {
        this.Component = component;
        this.BeanFramework = beanFramework;
        this.IdName = idName;
        this.PwdName = pwdName;
        this.Message = message;
    }

    public IEnumerator Main()
    {
        var inputPwd = GameObject.Find(this.PwdName).GetComponent<InputField>();
        var inputId  = GameObject.Find(this.IdName).GetComponent<InputField>();
        var pwd = inputPwd.text.Replace(",", "");
        pwd = pwd == "" ? "" : "P," + pwd + ",";
        return new IMModelAws(
            this.Component,
            this.BeanFramework,
            inputId.text,
            pwd,
            this.Message
        ).Main();
    }
}
