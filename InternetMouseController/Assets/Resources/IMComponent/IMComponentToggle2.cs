using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IMComponentToggle2 : Toggle
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        IMFramework2.GetInstance().Main(this, IMEnumEvent.OnPointerDown);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        IMFramework2.GetInstance().Main(this, IMEnumEvent.OnPointerUp);
    }
}
