using System.Collections;
using UnityEngine;

public class IMFacade2Menu : IMFacade2
{
    public IMBeanFramework BeanFramework { get; set; }
    string Transform;
    string Prefab;
    string IdNameFrom;
    string IdNameTo;
    string PwdNameFrom;
    string PwdNameTo;

    public IMFacade2Menu(
        IMBeanFramework beanFramework,
        string transform,
        string prefab,
        string idNameFrom,
        string idNameTo,
        string pwdNameFrom,
        string pwdNameTo
        )
    {
        this.BeanFramework = beanFramework;
        this.Transform = transform;
        this.Prefab = prefab;
        this.IdNameFrom = idNameFrom;
        this.IdNameTo = idNameTo;
        this.PwdNameFrom = pwdNameFrom;
        this.PwdNameTo = pwdNameTo;
    }

    public IEnumerator Main(MonoBehaviour component)
    {
        return new IMModelMenu2(
            this.BeanFramework,
            component,
            this.Transform,
            this.Prefab,
            this.IdNameFrom,
            this.IdNameTo,
            this.PwdNameFrom,
            this.PwdNameTo
        ).Main();
    }
}
