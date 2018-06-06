using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WikiInterface : MonoBehaviour {

    private static bool gamePaused = false;
    public GameObject wikiUI;
    public GameObject miniMapUI;

    void Update()
    {
        //comprobamos si apretamos la p (pedia)
        if (Input.GetKeyDown(KeyCode.P))
        {
            //comprobamos si ya esta abierto
            if (gamePaused)
            {
                //si lo esta lo abrimos
                closeWiki();
                Time.timeScale = 1f;
            }
            else
            {
                //si no lo esta lo cerramos 
                openWiki();
            }
        }
    }

    /**
     * openWiki muestra la wiki y desactiva el minimapa
     * para evitar que se sobrepongan y moleste
     * 
     * indicamos que esta abierto poniendo en true el bool
     */
    private void openWiki()
    {
        wikiUI.SetActive(true);
        closeMap();
        Time.timeScale = 0f;
        gamePaused = true;
    }

    /**
     * closeWiki quita la wiki y reactiva el minimapa
     * 
     * indicamos que esta cerrado poniendo en false el bool
     */
    private void closeWiki()
    {
        wikiUI.SetActive(false);
        openMap();
        gamePaused = false;
    }

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
}
