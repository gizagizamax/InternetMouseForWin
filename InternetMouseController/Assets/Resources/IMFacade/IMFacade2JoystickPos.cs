using System.Collections;
using UnityEngine;

public class IMFacade2JoystickPos : IMFacade2
{
    public IMBeanFramework BeanFramework { get; set; }

    string IdName;
    string PwdName;
    string MessagePlus;
    string MessageMinus;
    int    Magnification;
    string Joystick;
    string Horizontal;
    string Vertical;
    string Trans;

    public IMFacade2JoystickPos(
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

    public IEnumerator Main(MonoBehaviour component)
    {
        return new IMModelJoystickPos2(
            (IMComponentJoystick2)component,
            this.BeanFramework,
            this.IdName,
            this.PwdName,
            this.MessagePlus,
            this.MessageMinus,
            this.Magnification,
            this.Joystick,
            this.Horizontal,
            this.Vertical,
            this.Trans
        ).Main();
    }
}
