using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class AngleR : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData data)
    {
        if (PlayerJump.instance != null)
        {
            PlayerJump.instance.SetAngleR(true);
        }
    }
    public void OnPointerUp(PointerEventData data)
    {
        if (PlayerJump.instance != null)
        {
            PlayerJump.instance.SetAngleR(false);
        }
    }
}
