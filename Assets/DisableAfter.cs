using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfter : MonoBehaviour
{
    public float DisableAfterTime = 3f;
    private void OnEnable()
    {
        StartCoroutine(Disable());   
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(DisableAfterTime);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine(Disable());
    }
}
