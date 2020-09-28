using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventStartLevel : MonoBehaviour
{
    public GameObject InitialDialogue;
    public GameObject FinalDialogue;

    float timeUntil = 2f;
    private bool active = false;

    private void Start()
    {
        Time.timeScale = 0;

        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().songFinished.AddListener(FinishDialogue);
    }

    private void Update()
    {
        timeUntil -= Time.unscaledDeltaTime;

        if(timeUntil <= 0 && active == false)
        {
            InitialDialogue.SetActive(true);
            active = true;
        }
    }

    public void FinishDialogue()
    {
        FinalDialogue.SetActive(true);
    }

}
