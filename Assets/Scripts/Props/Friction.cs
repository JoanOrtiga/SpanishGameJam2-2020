using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    public PhysicsMaterial2D frictionless;
    public PhysicsMaterial2D friction;

    Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
            coll.sharedMaterial = frictionless;
        }
        else
        {
            coll.sharedMaterial = friction;
        }
    }

}
