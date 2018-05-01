using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Audio;
using Assets.Scripts.DataBase;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public static string languageAPP;
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Dropdown language;
    private string idioma;
    public static string mensaje = "";
    Resolution[] resolutions;
    DataTable idiomas;
    DataRow[] rowsIdioma = new DataRow[3];
    void Start() {

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        language.ClearOptions();
        int currentResolutionIndex = 0;
        int currentLangIndex = 0;
        List<string> options = new List<string>();
        List<string> languageOptions = new List<string>();
        idiomas = GamePruebas.GameDataBase.getIdiomas(ref mensaje);
        int contadorIdioma = 0;
        foreach (DataRow row in idiomas.Rows)
        {
            rowsIdioma[contadorIdioma]=row;
        }
        for (int i = 0; i < rowsIdioma.Length;i++)
        {
            languageOptions.Add(rowsIdioma[i]["Denominacion"].ToString());
        }
        language.AddOptions(languageOptions);
        for (int i = 0; i < resolutions.Length; i++) {

            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height==Screen.currentResolution.height) {

                currentResolutionIndex = i;
            }

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        languageAPP = language.value.ToString();

    }


    public void setResolution (int resolutionIndex) {

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }


    public void setVolume(float volume) {

        audioMixer.SetFloat("volume",volume);

    }


    public void setQuality(int index) {

        QualitySettings.SetQualityLevel(index);

    }

    public void setFullScreen(bool isFullScreen) {

        Screen.fullScreen = isFullScreen;

    }
    
    public void setWindowed(bool isFullScreen)
    {
        isFullScreen = false;
        Screen.fullScreen = isFullScreen;
    }


	
}
