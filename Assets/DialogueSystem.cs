using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public string[] dialogueText;

    private int nextText = -1;

    public float timeBetweenText;

    Text text;

    public GameObject note;
    public GameObject dialogueUI;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetButtonDown("Action") || Input.GetButtonDown("Submit"))
        {
            

            note.SetActive(false);
            text.text = "";
            nextText++;

            if (nextText >= dialogueText.Length)
            {
                dialogueUI.SetActive(false);
            }
            else
            {
                StartCoroutine(WriteText());
            }
        }
    }

    IEnumerator WriteText()
    {
        for (int i = 0; i < dialogueText[nextText].Length; i++)
        {
            text.text += dialogueText[nextText][i];

            yield return new WaitForSeconds(timeBetweenText);
        }

        note.SetActive(true);


        
    }


}
