using UnityEngine;
using System.Collections;

public class SetSunLight : MonoBehaviour
{

    //public Renderer lightwall;

    Material sky;

    //public Renderer water;

    public Transform stars;
   // public Transform worldProbe;

    // Use this for initialization
    void Start()
    {

        sky = RenderSettings.skybox;

    }

    bool lighton = false;

    // Update is called once per frame
    void Update()
    {

        stars.transform.rotation = transform.rotation;
   

    }
}