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

    public bool nextLevel;
    public bool resetLevel;

    int character = 0;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Action") || Input.GetButtonDown("Submit"))
        {
            note.SetActive(false);
            text.text = "";
            nextText++;

            if (nextText >= dialogueText.Length - 1)
            {
                if (nextLevel)
                {
                    int nextSceneLoad = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;

                    if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                    {
                        PlayerPrefs.SetInt("levelAt", nextSceneLoad);

                    }

                    UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneLoad);
                }
                else if (resetLevel)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
                }

                dialogueUI.SetActive(false);
            }
            else
            {
                StopCoroutine(WriteText());
                StartCoroutine(WriteText());
            }
        }
    }

    IEnumerator WriteText()
    {
        character = 0;

        while (character < dialogueText[nextText].Length)
        {
            text.text += dialogueText[nextText][character];

            character++;
            yield return new WaitForSecondsRealtime(timeBetweenText);
        }


        note.SetActive(true);
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
