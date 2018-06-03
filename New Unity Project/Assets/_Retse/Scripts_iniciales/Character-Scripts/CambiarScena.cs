using System.Collections;
using UnityEngine;

public class CambiarScena : MonoBehaviour
{

    public Texture2D desvanecer;
    public float velDesvanecer;

    private int profundidad = -1000;
    private float alpha = 1.0f;
    private int desDir = -1;

    void OnGUI()
    {
        alpha += desDir * velDesvanecer + Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = profundidad;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), desvanecer);
    }

    public float EmpezarDes(int direccion)
    {
        desDir = direccion;
        return (velDesvanecer);
    }

    void cargaDeNivel()
    {
        EmpezarDes(-1);
    }
}