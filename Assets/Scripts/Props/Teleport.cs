using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Teleport portal;

    Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.position = portal.transform.position;

            portal.StartCoroutine(portal.DisableTeleport(1f));
        }
    }

    IEnumerator DisableTeleport(float time)
    {
        coll.enabled = false;
        yield return new WaitForSeconds(time);
        coll.enabled = true;      
    }

}
