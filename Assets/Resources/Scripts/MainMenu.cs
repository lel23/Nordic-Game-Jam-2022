using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelzero;
    public GameObject credits;

    public void StartGame()
    {
        SceneManager.LoadScene(levelzero);
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
    }
    public void CloseCredits()
    {
        credits.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
