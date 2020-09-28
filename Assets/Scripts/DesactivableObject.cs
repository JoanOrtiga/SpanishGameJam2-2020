using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class DesactivableObject : MonoBehaviour
{
    SpriteRenderer spr;
    Collider2D coll;
    Light2D child;

    public bool active;
    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();

        if(transform.childCount != 0)
            if(transform.GetChild(0).GetComponent<Light2D>() != null)
                child = transform.GetChild(0).GetComponent<Light2D>();

        if (active)
        {
            coll.enabled = true;
            spr.color += new Color(0, 0, 0, 1);
        }
        else
        {
            coll.enabled = false;
            spr.color -= new Color(0, 0, 0, 1);
        }
    }

    public void DeActivate()
    {
        StopCoroutine(IncreaseOpacity());
        StartCoroutine(LowerOpacity());
    }

    public void ReActivate()
    {
        StopCoroutine(LowerOpacity());
        StartCoroutine(IncreaseOpacity());
    }

    IEnumerator LowerOpacity()
    {
        coll.enabled = false;

        if (child!= null)
            child.enabled = false;

        for (float ft = 1f; ft >= 0; ft -= 0.01f)
        {
            spr.color -= new Color(0, 0, 0, ft);
            yield return null;
        }
    }

    IEnumerator IncreaseOpacity()
    {
        for (float ft = 0f; ft <= 1f; ft += 0.01f)
        {
            spr.color += new Color(0, 0, 0, ft);
            yield return null;
        }

        coll.enabled = true;

        if (child != null)
            child.enabled = true;
    }


}
