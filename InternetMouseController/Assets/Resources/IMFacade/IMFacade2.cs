using System.Collections;
using UnityEngine;

public interface IMFacade2
{
    IMBeanFramework BeanFramework { get; set; }

    IEnumerator Main(MonoBehaviour component);
}
