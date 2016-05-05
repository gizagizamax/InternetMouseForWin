using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IMModelJoystickButton
{
    IMComponentJoystick2 Component;
    IMBeanFramework BeanFramework;
    string IdName;
    string PwdName;
    string Message;
    bool IsHold;

    static List<string> SendMessageList = new List<string>();

    public IMModelJoystickButton(IMComponentJoystick2 component, IMBeanFramework beanFramework, string idName, string pwdName, string message, bool isHold)
    {
        this.Component = component;
        this.BeanFramework = beanFramework;
        this.IdName = idName;
        this.PwdName = pwdName;
        this.Message = message;
        this.IsHold = isHold;
    }

    public IEnumerator Main()
    {
        this.Component.IsHold = this.IsHold;

        var inputPwd = GameObject.Find(this.PwdName).GetComponent<InputField>();
        var inputId  = GameObject.Find(this.IdName).GetComponent<InputField>();
        var pwd = inputPwd.text.Replace(",", "");
        pwd = pwd == "" ? "" : "P," + pwd + ",";
        return new IMModelAws(
            Component,
            this.BeanFramework,
            inputId.text,
            pwd,
            this.Message
        ).Main();
    }
}
