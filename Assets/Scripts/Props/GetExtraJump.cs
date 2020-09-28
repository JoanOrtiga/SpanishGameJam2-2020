using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetExtraJump : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("DoubleJump");
            collision.GetComponent<Movement>().extraJump = true;
        }
    }
}
