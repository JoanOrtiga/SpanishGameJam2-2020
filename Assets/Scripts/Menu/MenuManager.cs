using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int sceneToLoad;
    public GameObject gameObjectToShow;
    

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ShowMenu()
    {
        gameObjectToShow.GetComponent<CanvasGroup>().alpha = 1;
        gameObjectToShow.GetComponent<CanvasGroup>().interactable = true;
        gameObjectToShow.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void HideMenu()
    {
        gameObjectToShow.GetComponent<CanvasGroup>().alpha = 0;
        gameObjectToShow.GetComponent<CanvasGroup>().interactable = false;
        gameObjectToShow.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
