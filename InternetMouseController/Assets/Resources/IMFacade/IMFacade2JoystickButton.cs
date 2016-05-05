using System.Collections;
using UnityEngine;

public class IMFacade2JoystickButton : IMFacade2
{
    public IMBeanFramework BeanFramework { get; set; }

    string IdName;
    string PwdName;
    string Message;
    bool IsHold;

    public IMFacade2JoystickButton(IMBeanFramework beanFramework, string idName, string pwdName, string message, bool isHold)
    {
        this.BeanFramework = beanFramework;
        this.IdName = idName;
        this.PwdName = pwdName;
        this.Message = message;
        this.IsHold = isHold;
    }

    public IEnumerator Main(MonoBehaviour component)
    {
        return new IMModelJoystickButton(
            (IMComponentJoystick2)component,
            this.BeanFramework,
            this.IdName,
            this.PwdName,
            this.Message,
            this.IsHold
        ).Main();
    }
}