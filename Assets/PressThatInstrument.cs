using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressThatInstrument : MonoBehaviour
{
    public GameObject reference;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("Win");
            collision.GetComponent<RawImage>().color = Color.blue;
            reference = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject != reference)
        {
            print("lose");
            collision.GetComponent<RawImage>().color = Color.red;
        }
        

    }
}
