using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IMModelMenu2
{
    IMBeanFramework BeanFramework;
    MonoBehaviour Component;
    string Transform;
    string Prefab;
    string IdNameFrom;
    string IdNameTo;
    string PwdNameFrom;
    string PwdNameTo;

    public IMModelMenu2(
        IMBeanFramework beanFramework,
        MonoBehaviour component,
        string transform,
        string prefab,
        string idNameFrom,
        string idNameTo,
        string pwdNameFrom,
        string pwdNameTo
    )
    {
        this.BeanFramework = beanFramework;
        this.Component = component;
        this.Transform = transform;
        this.Prefab = prefab;
        this.IdNameFrom = idNameFrom;
        this.IdNameTo = idNameTo;
        this.PwdNameFrom = pwdNameFrom;
        this.PwdNameTo = pwdNameTo;
    }

    public IEnumerator Main()
    {
        var transform = GameObject.Find(this.Transform).GetComponent<Transform>();

        var destroyList = new List<GameObject>();
        foreach (Transform child in transform.transform)
        {
            destroyList.Add(child.gameObject);
        }

        var gameObjectNew = ((GameObject)Object.Instantiate(Resources.Load(this.Prefab), new Vector3(), Quaternion.identity));
        var inputIdFrom  = GameObject.Find(this.IdNameFrom).GetComponent<InputField>();
        var inputIdTo    = GameObject.Find(this.IdNameTo).GetComponent<InputField>();
        var inputPwdFrom = GameObject.Find(this.PwdNameFrom).GetComponent<InputField>();
        var inputPwdTo   = GameObject.Find(this.PwdNameTo).GetComponent<InputField>();
        inputIdTo.text  = inputIdFrom.text;
        inputPwdTo.text = inputPwdFrom.text;

        gameObjectNew.transform.SetParent(transform, false);

        foreach (var child in destroyList)
        {
            Object.Destroy(child);
        }
        return null;
    }
}
