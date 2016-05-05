using UnityEngine;
using UnityEngine.EventSystems;

public class IMComponentButton2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        IMFramework2.GetInstance().Main(this, IMEnumEvent.OnPointerDown);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IMFramework2.GetInstance().Main(this, IMEnumEvent.OnPointerUp);
    }
}
