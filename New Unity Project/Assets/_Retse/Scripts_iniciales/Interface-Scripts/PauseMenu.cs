using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    private static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject miniMapUI;
    public GameObject menu;

    public GameObject inventoryUI;
    public GameObject wikiUI;
    public GameObject healthBar;

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
        menu.SetActive(false);
        openMap();
        showHP();
        Time.timeScale = 1f;
        GameIsPaused = false;

    }


    void Pause() {

        pauseMenuUI.SetActive(true);
        menu.SetActive(true);
        closeMap();
        hideHP();
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


    #region esconderMostrarElementos
    //método que activa el minimapa
    public void openMap()
    {
        miniMapUI.SetActive(true);
    }

    //método que desactiva el minimapa
    public void closeMap()
    {
        miniMapUI.SetActive(false);
    }

    //método que esconde la vida
    public void showHP()
    {
        healthBar.SetActive(true);
    }

    //método que muestra la vida
    public void hideHP()
    {
        healthBar.SetActive(false);
    }

    #endregion

    //método que abre el inventario
    public void openInventory()
    {
        Debug.Log("inventario");
        menu.SetActive(false);
        wikiUI.SetActive(false);
        inventoryUI.SetActive(true);        
    }

    //método que abre el menu
    public void openMenu()
    {
        Debug.Log("menu");
        inventoryUI.SetActive(false);
        wikiUI.SetActive(false);
        menu.SetActive(true);
    }

    //método que abre la wiki
    public void openWiki()
    {
        Debug.Log("wiki");
        inventoryUI.SetActive(false);
        menu.SetActive(false);
        wikiUI.SetActive(true);
    }


}
