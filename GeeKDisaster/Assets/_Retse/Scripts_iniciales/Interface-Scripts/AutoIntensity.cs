using UnityEngine;
using System.Collections;

public class AutoIntensity : MonoBehaviour
{
    //color dia y noche
    public Gradient nightDayColor;

    //Intensidad de iluminacion
    public float maxIntensity = 3f;
    public float minIntensity = 0f;
    public float minPoint = -0.2f;

    //Iluminacion en el ambiente
    public float maxAmbient = 1f;
    public float minAmbient = 0f;
    public float minAmbientPoint = -0.2f;

    //Colores
    public Gradient nightDayFogColor;
    //Transicion de colores
    public AnimationCurve fogDensityCurve;
    public float fogScale = 1f;

    //Campo de vision 1 mal 0 bien
    public float dayAtmosphereThickness = 0.4f;
    public float nightAtmosphereThickness = 0.87f;

    //Velocidad de rotacion
    public Vector3 dayRotateSpeed;
    public Vector3 nightRotateSpeed;

    float skySpeed =(float) 0.6;

    //Luz
    Light mainLight;
    //El material cielo utilizado
    Skybox sky;
    Material skyMat;

    //Cuando comieza
    void Start()
    {
        //Recuperamos el objeto 
        mainLight = GetComponent<Light>();
        skyMat = RenderSettings.skybox;

    }

    //Por cada frame
    void Update()
    {
        //Calculo de la intensidad de iluminacion
        float tRange = 1 - minPoint;
        float dot = Mathf.Clamp01((Vector3.Dot(mainLight.transform.forward, Vector3.down) - minPoint) / tRange);
        //La intensidad de la luz resultante
        float i = ((maxIntensity - minIntensity) * dot) + minIntensity;
        //Se asigna la intensidad
        mainLight.intensity = i;

        //Calculo de la luz en el ambiente
        tRange = 1 - minAmbientPoint;
        dot = Mathf.Clamp01((Vector3.Dot(mainLight.transform.forward, Vector3.down) - minAmbientPoint) / tRange);
        i = ((maxAmbient - minAmbient) * dot) + minAmbient;
        //Se asigna la luz ambiental
        RenderSettings.ambientIntensity = i;

        //Color de la luz se asigna con el dot que es el rango 0-1 de la luz que equivale en el gradiente
        mainLight.color = nightDayColor.Evaluate(dot);
        RenderSettings.ambientLight = mainLight.color;

        //Se le asigna el color a la niebla que hay al amanecer y atardecer
        RenderSettings.fogColor = nightDayFogColor.Evaluate(dot);
        RenderSettings.fogDensity = fogDensityCurve.Evaluate(dot) * fogScale;

        i = ((dayAtmosphereThickness - nightAtmosphereThickness) * dot) + nightAtmosphereThickness;
        skyMat.SetFloat("_AtmosphereThickness", i);
        //Si es de dia girara a una velocidad lenta
        if (dot > 0) 
            transform.Rotate(dayRotateSpeed * Time.deltaTime * skySpeed);
        //Si es de noche pasara mas rapido
        else
            transform.Rotate(nightRotateSpeed * Time.deltaTime * skySpeed);

        //if (Input.GetKeyDown(KeyCode.Q)) skySpeed *= 0.5f;
        //if (Input.GetKeyDown(KeyCode.E)) skySpeed *= 2f;


    }
}