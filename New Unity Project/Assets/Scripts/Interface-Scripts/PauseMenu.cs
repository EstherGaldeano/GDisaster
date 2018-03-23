using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    private static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
	
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (GameIsPaused) {

                Resume();

            }else {

                Pause();

            }
        }
	}

   public static bool getGameState()
    {
        return GameIsPaused;
    }
   public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;



    }


    void Pause() {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }


   public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }


   public void QuitGame() {

        Application.Quit();


    }



}
