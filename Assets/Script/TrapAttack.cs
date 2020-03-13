using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAttack : LeftMovement
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().playerDestroy();
        }
    }
}
