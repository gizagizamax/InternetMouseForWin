using UnityEngine;
using UnityEngine.EventSystems;

public class IMComponentJoystick2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int ScreenWidth;
    public int ScreenHeight;
    public float LastX;
    public float LastY;
    public bool IsHold;

    public void OnPointerDown(PointerEventData eventData)
    {
        IMFramework2.GetInstance().Main(this, IMEnumEvent.OnPointerDown);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IMFramework2.GetInstance().Main(this, IMEnumEvent.OnPointerUp);
    }

    void Update()
    {
        IMFramework2.GetInstance().Main(this, IMEnumEvent.Update);
    }
}
