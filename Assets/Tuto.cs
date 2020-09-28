using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MonoBehaviour
{
    private int i = 0;
    public List<GameObject> g = new List<GameObject>();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            i++;
            for (int i1 = 0; i1 < g.Count; i1++)
            {
                g[i1].SetActive(false);
            }
            g[i].SetActive(true);
        }
        if (i == g.Count)
        {
            Destroy(gameObject);
        }
    }
}
