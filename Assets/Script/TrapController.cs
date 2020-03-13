using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Traps;

    private bool playerAlive;
    private float startTime = 1.5f, nextTime = 1f, trapDifficulty;

    void Start()
    {
        
    }

    void Update()
    {
        if (this.transform.childCount < 3 && Time.time > nextTime)
        {
            nextTime = Time.time + startTime;
            TrapCreater();
        }
    }

    private void TrapCreater()
    {
        GameObject curentObject = Instantiate(Traps[Random.Range(0, Traps.Length)], transform.position, Quaternion.identity);
        curentObject.transform.parent = transform;
    }
}
