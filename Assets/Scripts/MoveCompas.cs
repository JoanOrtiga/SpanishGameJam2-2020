using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCompas : MonoBehaviour
{
    public GameObject compas1;
    public GameObject compas2;

    public float speed = 0.5f;

    private Vector2 startPos;

    private Camera mainCamera;
    private Vector2 screenBounds;


    private void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        startPos = compas2.transform.position;
    }

    private void Update()
    {
        transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
    }
}
