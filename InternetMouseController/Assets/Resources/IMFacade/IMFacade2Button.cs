using System.Collections;
using UnityEngine;

public class IMFacade2Button : IMFacade2
{
    public IMBeanFramework BeanFramework { get; set; }

    string IdName;
    string PwdName;
    string Message;

    public IMFacade2Button(IMBeanFramework beanFramework, string idName, string pwdName, string message)
    {
        this.BeanFramework = beanFramework;
        this.IdName = idName;
        this.PwdName = pwdName;
        this.Message = message;
    }

    public IEnumerator Main(MonoBehaviour component)
    {
        return new IMModelButton(
            component,
            this.BeanFramework,
            this.IdName,
            this.PwdName,
            this.Message
        ).Main();
    }
}