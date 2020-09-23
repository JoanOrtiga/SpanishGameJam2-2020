using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject parent;
    public GameObject[] instruments;

    private float time;

    private void Update()
    {
        time -= Time.deltaTime;
        
        if(time <= 0)
        {
            time = 3;
            Instantiate(instruments[0], parent.transform);
        }
    }
}
