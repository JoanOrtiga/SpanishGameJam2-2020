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
        gameObjectToShow.SetActive(true);
    }

    public void HideMenu()
    {
        gameObjectToShow.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
