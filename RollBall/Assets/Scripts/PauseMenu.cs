using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject SettingsMenuUI;

    public Slider speedslider;

    public GameObject Player;





    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard kb = InputSystem.GetDevice<Keyboard>();

        if (kb.escapeKey.wasPressedThisFrame)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadSettings()
    {
        pauseMenuUI.SetActive(false);
        Debug.Log("Loading settings");
        SettingsMenuUI.SetActive(true);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading menu");
        //SceneManager.LoadScene("");
    }



    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();

    }

    public void Back()
    {
        pauseMenuUI.SetActive(true);
        SettingsMenuUI.SetActive(false);
    }

    public void ToggleChanged(bool isToggled)
    {
        GameObject sphere = GameObject.FindWithTag("Player");
        if (isToggled)
        {
            sphere.transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {

            sphere.transform.localScale = new Vector3(2, 2, 2);
        }
    }
    
    

}
