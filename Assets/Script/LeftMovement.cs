using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 0f, startPoint = 0f, endPoint = 0f;
    [SerializeField]
    private bool isDestroy = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            LeftSideMovement();
            MovementRestart();
        }
    }

    private void LeftSideMovement()
    {
        transform.position -= new Vector3(movementSpeed * Time.deltaTime, 0, 0);
    }

    private void MovementRestart()
    {
        if(transform.position.x < endPoint )
        {
            if (isDestroy)
            {
                Destroy(this.gameObject);
            }
            else
            {
                transform.position = new Vector3(startPoint, transform.position.y, transform.position.z);
            }
        }
    }
}
