using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider master;

    bool settings = false;
    public GameObject settingsScreen;

    void Start()
    {
        if (PlayerPrefs.HasKey("masterMixer"))
        {
            Load();
        }
        else
        {
            ChangeMaster();
        }
    }

    public void ChangeMaster()
    {
        mixer.SetFloat("masterMixer", Mathf.Log10(master.value) * 20);
        PlayerPrefs.SetFloat("masterMixer", master.value);
    }
    void Load()
    {
        master.value = PlayerPrefs.GetFloat("masterMixer");
        ChangeMaster();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Settings();
        }
    }
    
    public void Settings()
    {
        Debug.Log(settings);
        if (!settings)
        {
            Time.timeScale = 0f;
            settingsScreen.SetActive(true);
            settings = true;
        }
        else
        {
            Time.timeScale = 1f;
            settingsScreen.SetActive(false);
            settings = false;
        }
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
