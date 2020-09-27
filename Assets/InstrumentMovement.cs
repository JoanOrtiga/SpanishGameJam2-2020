using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentMovement : MonoBehaviour
{
    public float speed = 0.5f;

    void Update()
    {
        transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
