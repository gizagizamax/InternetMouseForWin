using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class IMModelJoystickPos2
{
    IMComponentJoystick2 Component;
    IMBeanFramework BeanFramework;
    string IdName;
    string PwdName;
    string MessagePlus;
    string MessageMinus;
    int    Magnification;
    string Joystick;
    string Horizontal;
    string Vertical;
    string Trans;

    public IMModelJoystickPos2(
        IMComponentJoystick2 component,
        IMBeanFramework beanFramework,
        string idName,
        string pwdName,
        string messagePlus,
        string messageMinus,
        int    magnification,
        string joystick,
        string horizontal,
        string vertical,
        string trans
        )
    {
        this.Component = component;
        this.BeanFramework = beanFramework;
        this.IdName = idName;
        this.PwdName = pwdName;
        this.MessagePlus = messagePlus;
        this.MessageMinus = messageMinus;
        this.Magnification = magnification;
        this.Joystick = joystick;
        this.Horizontal = horizontal;
        this.Vertical = vertical;
        this.Trans = trans;
    }

    public IEnumerator Main()
    {
        this.Rect();
        return this.Move();
    }

    void Rect()
    {
        if (this.Component.ScreenWidth == Screen.width && this.Component.ScreenHeight == Screen.height)
        {
            return;
        }

        this.Component.ScreenWidth = Screen.width;
        this.Component.ScreenHeight = Screen.height;

        var joystick = GameObject.Find(this.Joystick).GetComponent<Joystick>();
        var rectTransform = GameObject.Find(this.Trans).GetComponent<RectTransform>();
        typeof(Joystick)
            .GetField("m_StartPos", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(joystick, rectTransform.transform.position);
    }

    IEnumerator Move()
    {
        if (!this.Component.IsHold)
        {
            this.Component.LastX = 0;
            this.Component.LastY = 0;
            return null;
        }

        var currX = CrossPlatformInputManager.GetAxisRaw(this.Horizontal);
        var currY = CrossPlatformInputManager.GetAxisRaw(this.Vertical);
        var diff = (int)((currX + currY - this.Component.LastX - this.Component.LastY) * this.Magnification);
        if (diff == 0)
        {
            return null;
        }

        this.Component.LastX = currX;
        this.Component.LastY = currY;

        var time = diff < 0 ? -1 * diff : diff;
        var array = new string[time];
        for (var i = 0; i < time; i++)
        {
            array[i] = diff > 0 ? this.MessagePlus : this.MessageMinus;
        }

        var inputPwd = GameObject.Find(this.PwdName).GetComponent<InputField>();
        var inputId  = GameObject.Find(this.IdName).GetComponent<InputField>();
        var pwd = inputPwd.text.Replace(",", "");
        pwd = pwd == "" ? "" : "P," + pwd + ",";
        return new IMModelAws(
            this.Component,
            this.BeanFramework,
            inputId.text,
            pwd,
            string.Join(",", array)
        ).Main();
    }
}
