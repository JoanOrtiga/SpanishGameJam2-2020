using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateInstrumental : MonoBehaviour
{
    public InstrumentAttack instrument;
    PressBar pressbar;
    Animator anim;
    ScreenShake camera;

    

    private void Start()
    {
        pressbar = GameObject.FindGameObjectWithTag("PressBar").GetComponent<PressBar>();
        anim = GetComponent<Animator>();

        camera = Camera.main.GetComponent<ScreenShake>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButton("Action") && collision.CompareTag("Player"))
        {
            anim.SetTrigger("Pressed");

            if (pressbar.playingInstrument)
            {
                if(instrument == pressbar.whatInstrument)
                {
                    print("Pressed");
                    camera.Shake(0.1f, 0.045f);
                    pressbar.ChangePressed();
                }
            }
        }
    }
}
