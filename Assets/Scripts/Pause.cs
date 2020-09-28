using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool paused;
    CanvasGroup cg;

    void Start()
    {
        cg = GetComponent<CanvasGroup>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Continue();
            }
            else
            {
                paused = true;
                Time.timeScale = 0;
                cg.interactable = true;
                cg.blocksRaycasts = true;
                cg.alpha = 1;
            }
        }
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        cg.interactable = false;
        cg.blocksRaycasts = false;
        cg.alpha = 0;
        paused = false;
    }
}
