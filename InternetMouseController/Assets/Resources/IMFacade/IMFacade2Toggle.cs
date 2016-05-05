using System.Collections;
using UnityEngine;

public class IMFacade2Toggle : IMFacade2
{
    public IMBeanFramework BeanFramework { get; set; }

    string IdName;
    string PwdName;
    string MessageOn;
    string MessageOff;

    public IMFacade2Toggle(
        IMBeanFramework beanFramework,
        string idName,
        string pwdName,
        string messageOn,
        string messageOff
        )
    {
        this.BeanFramework = beanFramework;
        this.IdName = idName;
        this.PwdName = pwdName;
        this.MessageOn = messageOn;
        this.MessageOff = messageOff;
    }

    public IEnumerator Main(MonoBehaviour component)
    {
        return new IMModelToggle(
            this.BeanFramework,
            (IMComponentToggle2)component,
            this.IdName,
            this.PwdName,
            this.MessageOn,
            this.MessageOff
        ).Main();
    }
}