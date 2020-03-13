using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{ 
    Player playerScript;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerScript.isJumpBtn = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        playerScript.isJumpBtn = true;
    }
}
