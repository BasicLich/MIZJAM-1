using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public ControllerBase controller;
    public GameObject pauseMenu, gameUI, loseScreen;
    public bool paused = false;
    public AudioSource aSource;

    public void Resume() {


        pauseMenu.SetActive(false);
        gameUI.SetActive(true);
        Cursor.visible = false;
         paused = false;
        Time.timeScale = 1 ;
        Cursor.lockState = CursorLockMode.Locked;
        controller.Resume();
        aSource.UnPause();
       

    }


    public void Pause() {

        Cursor.visible = true;
        pauseMenu.SetActive(true);
        gameUI.SetActive(false);
        paused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        controller.Pause();
        aSource.Pause();
        if (ItemManager.instance != null) ItemManager.instance.wordBox.gameObject.SetActive(false);


    }


    private void Awake() {

        loseScreen.SetActive(false);
        Resume();
    }


    private void Update() {

        if (onLoseScreen) return;

        if (Input.GetKeyDown(KeyCode.Escape)) {


            if (paused) {
                Resume();
            } else if (Time.timeScale != 0) {
                Pause();
            }


        }

    }

    bool onLoseScreen = false;

    public void ShowLoseScreen() {

        pauseMenu.SetActive(false);
        gameUI.SetActive(false);
        loseScreen.SetActive(true);
        onLoseScreen = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    public void RestartLevel() {
        Time.timeScale = 1;
        SceneManager.LoadScene("BattleScene");
    }

    public void MainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }





}
