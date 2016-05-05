using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class IMModelJoystickTime
{
    MonoBehaviour Component;
    IMBeanFramework BeanFramework;
    string IdName;
    string PwdName;
    string Message;
    int    MagnificationX;
    int    MagnificationY;
    string Joystick;
    string Horizontal;
    string Vertical;
    string Trans;
    public Vector3 Pos;
    public float DiffTime;

    public IMModelJoystickTime(
        MonoBehaviour component,
        IMBeanFramework beanFramework,
        string idName,
        string pwdName,
        string message,
        int    magnificationX,
        int    magnificationY,
        string joystick,
        string horizontal,
        string vertical,
        string trans,
        Vector3 pos,
        float diffTime
        )
    {
        this.Component = component;
        this.BeanFramework = beanFramework;
        this.IdName = idName;
        this.PwdName = pwdName;
        this.Message = message;
        this.MagnificationX = magnificationX;
        this.MagnificationY = magnificationY;
        this.Joystick = joystick;
        this.Horizontal = horizontal;
        this.Vertical = vertical;
        this.Trans = trans;
        this.Pos = pos;
        this.DiffTime = diffTime;
    }

    public IEnumerator Main()
    {
        this.Rect();
        return this.Move();
    }

    void Rect()
    {
        var rectTransform = GameObject.Find(this.Trans).GetComponent<RectTransform>();
        if (this.Pos == rectTransform.transform.position)
        {
            return;
        }

        this.Pos = rectTransform.transform.position;

        var joystick = GameObject.Find(this.Joystick).GetComponent<Joystick>();
        typeof(Joystick)
            .GetField("m_StartPos", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(joystick, rectTransform.transform.position);
    }

    IEnumerator Move()
    {
        this.DiffTime += Time.deltaTime;
        if (this.DiffTime < 0.2)
        {
            return null;
        }
        this.DiffTime = 0;

        var mouseX = (int)(CrossPlatformInputManager.GetAxisRaw(this.Horizontal) * this.MagnificationX);
        var mouseY = (int)(CrossPlatformInputManager.GetAxisRaw(this.Vertical)   * this.MagnificationY);
        if (mouseX == 0 && mouseY == 0)
        {
            return null;
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
            string.Format(this.Message, mouseX, -1 * mouseY)
        ).Main();
    }
}
