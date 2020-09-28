using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    public PhysicsMaterial2D frictionless;
    public PhysicsMaterial2D friction;

    Collider2D coll;

    float timePressedJump;
    float timeUntilUnactive = 1f;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        timePressedJump = timeUntilUnactive;
    }

    private void Update()
    {
        if (Input.GetButton("Jump"))
            timePressedJump -= Time.deltaTime;
        else
            timePressedJump = timeUntilUnactive;

        if (Input.GetAxis("Horizontal") == 0 || timePressedJump <= 0)
        {
            coll.sharedMaterial = frictionless;
        }
        else
        {
            coll.sharedMaterial = friction;
        }
    }

}
