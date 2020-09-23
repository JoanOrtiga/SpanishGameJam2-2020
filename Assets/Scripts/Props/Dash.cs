using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public DashPositions dashPos;

    float rotationAngle;

    float time = 3f;

    Vector2 rotation;

    private void Start()
    {
        rotation = new Vector2(0, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Movement>().Dash(rotation.x, rotation.y);
        }
    }

    private void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,  Mathf.LerpAngle(transform.eulerAngles.z, Mathf.Rad2Deg * rotationAngle, 0.1f));

        time -= Time.deltaTime;

        if(time <= 0)
        {
            time = 3f;

            if((int)dashPos == 7)
            {
                dashPos = DashPositions.top;
            }
            else
                dashPos = (DashPositions)((int)dashPos + 1);

            rotation = GetAxis();
        }        
    }

    private Vector2 GetAxis()
    {
        switch (dashPos)
        {
            case DashPositions.top:
                rotationAngle = 0;
                return new Vector2(0, 1);
                
            case DashPositions.topright:
                rotationAngle = Mathf.Atan2(-1f, 1f);
                return new Vector2(1f, 1f);
                
            case DashPositions.right:
                rotationAngle = Mathf.Atan2(-1,0);
                return new Vector2(1,0);
                
            case DashPositions.botright:
                rotationAngle = Mathf.Atan2(-1f, -1);
                return new Vector2(1f, -1f);
                
            case DashPositions.bot:
                rotationAngle = Mathf.Atan2(0, -1f);
                return new Vector2(0, -1f);
                
            case DashPositions.botleft:
                rotationAngle = Mathf.Atan2(1f, -1f);
                return new Vector2(-1f, -1f);
                
            case DashPositions.left:
                rotationAngle = Mathf.Atan2(1f, 0f);
                return new Vector2(-1f, 0f);
                
            case DashPositions.topleft:
                rotationAngle = Mathf.Atan2(1f, 1f);
                return new Vector2(-1f, 1f);
            default:
                return new Vector2(0, 0);
        }
    }
}


public enum DashPositions
{
    top, topright, right, botright, bot, botleft, left, topleft
}
