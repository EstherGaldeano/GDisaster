using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour
{
    private bool GameIsPaused = false;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update()
    {
        GameIsPaused = PauseMenu.getGameState();

        if (!GameIsPaused)
        {
            Cursor.visible = false;
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
        else
        {
            Cursor.visible = true;
        }
        
    }
}