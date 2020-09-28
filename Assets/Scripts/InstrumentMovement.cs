using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentMovement : MonoBehaviour
{
    public InstrumentAttack instrument;

    public float speed = 0.5f;

    void Update()
    {
        transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
    }
}
