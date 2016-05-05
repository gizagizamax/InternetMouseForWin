using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IMModelToggle
{
    public IMBeanFramework BeanFramework { get; set; }
    IMComponentToggle2 Component;

    string IdName;
    string PwdName;
    string MessageOn;
    string MessageOff;

    public IMModelToggle(
        IMBeanFramework beanFramework,
        IMComponentToggle2 component,
        string idName,
        string pwdName,
        string messageOn,
        string messageOff
        )
    {
        this.BeanFramework = beanFramework;
        this.Component = component;
        this.IdName = idName;
        this.PwdName = pwdName;
        this.MessageOn = messageOn;
        this.MessageOff = messageOff;
    }

    public IEnumerator Main()
    {
        var inputId = GameObject.Find(this.IdName).GetComponent<InputField>();
        var inputPwd = GameObject.Find(this.PwdName).GetComponent<InputField>();
        var pwd = inputPwd.text.Replace(",", "");
        pwd = pwd == "" ? "" : "P," + pwd + ",";

        this.updateColor();

        return new IMModelAws(
            this.Component,
            this.BeanFramework,
            inputId.text,
            pwd,
            this.Component.isOn ? this.MessageOn : this.MessageOff
        ).Main();
    }

    void updateColor()
    {
        if (this.Component.isOn)
        {
            var colors = this.Component.colors;
            var color = new Color(1f, 1f, 1f, 0f);
            colors.normalColor = color;
            colors.pressedColor = color;
            colors.highlightedColor = color;
            this.Component.colors = colors;
        }
        else
        {
            var colors = this.Component.colors;
            var color = new Color(1f, 1f, 0f, 90f / 255f);
            colors.normalColor = color;
            colors.pressedColor = color;
            colors.highlightedColor = color;
            this.Component.colors = colors;
        }
    }
}