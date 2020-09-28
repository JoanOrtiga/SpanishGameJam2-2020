using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PressBar : MonoBehaviour
{
    [HideInInspector]public bool playingInstrument;
    [HideInInspector]public InstrumentAttack whatInstrument;

    [HideInInspector] public Image image;


    public UnityEvent playedInstrument;

    public UnityEvent error;


    private bool pressed;
    
    public void ChangePressed()
    {
        if (playingInstrument && pressed == false)
        {
            pressed = true;
            image.color = Color.green;

            if(whatInstrument == InstrumentAttack.drop)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
            
            playedInstrument.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Instrument"))
        {
            playingInstrument = true;
            whatInstrument = collision.GetComponent<InstrumentMovement>().instrument;
            image = collision.GetComponent<Image>();
        }
    }

    


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Instrument"))
        {
            playingInstrument = false;

            if(pressed == false)
            {
                image.color = Color.red;
                error.Invoke();
            }
                
            pressed = false;
        }
    }
}
