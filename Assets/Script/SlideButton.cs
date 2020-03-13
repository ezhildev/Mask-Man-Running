using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlideButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    Player playerScript;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerScript.isSlideBtn = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        playerScript.isSlideBtn = true;
    }
}
