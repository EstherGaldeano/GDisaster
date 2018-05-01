using GamePruebas;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    
    void Awake()
    {
        string menseje="";
        string codIdioma = GameDataBase.getCodIdiomas(SettingsMenu.languageAPP,ref menseje);
        DataTable newGame = GameDataBase.getLiteral(1, codIdioma, ref menseje);
        DataRow rows = newGame.Rows[0];
        GameObject.Find("NewGame").GetComponentInChildren<Text>().text = rows["Descripcion"].ToString();
        newGame = GameDataBase.getLiteral(2, codIdioma, ref menseje);
        rows = newGame.Rows[0];
        GameObject.Find("ResumeGame").GetComponentInChildren<Text>().text = rows["Descripcion"].ToString();
        newGame = GameDataBase.getLiteral(3, codIdioma, ref menseje);
        rows = newGame.Rows[0];
        GameObject.Find("Exit").GetComponentInChildren<Text>().text = rows["Descripcion"].ToString();
    }
    public void PlayGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame() {

        Application.Quit();

    }
}
