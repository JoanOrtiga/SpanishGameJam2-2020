using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    private RawImage raw;

    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        raw = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        raw.uvRect = new Rect(Time.deltaTime * speed + raw.uvRect.x, raw.uvRect.y, raw.uvRect.width, raw.uvRect.height);

    }
}
