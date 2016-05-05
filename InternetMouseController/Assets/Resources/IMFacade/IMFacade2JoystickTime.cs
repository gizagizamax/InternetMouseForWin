using System.Collections;
using UnityEngine;

public class IMFacade2JoystickTime : IMFacade2
{
    public IMBeanFramework BeanFramework { get; set; }

    string IdName;
    string PwdName;
    string Message;
    int    MagnificationX;
    int    MagnificationY;
    string Joystick;
    string Horizontal;
    string Vertical;
    string Trans;

    Vector3 Pos;
    float DiffTime;

    public IMFacade2JoystickTime(
        IMBeanFramework beanFramework,
        string idName,
        string pwdName,
        string message,
        int magnificationX,
        int magnificationY,
        string joystick,
        string horizontal,
        string vertical,
        string trans
        )
    {
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
    }

    public IEnumerator Main(MonoBehaviour component)
    {
        var model = new IMModelJoystickTime(
            component,
            this.BeanFramework,
            this.IdName,
            this.PwdName,
            this.Message,
            this.MagnificationX,
            this.MagnificationY,
            this.Joystick,
            this.Horizontal,
            this.Vertical,
            this.Trans,
            this.Pos,
            this.DiffTime
        );
        var enumerator = model.Main();
        this.Pos = model.Pos;
        this.DiffTime = model.DiffTime;
        return enumerator;
    }
}
