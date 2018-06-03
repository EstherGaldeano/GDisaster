using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

    //obtenemos el transform del personaje
    public Transform player;

    private void LateUpdate()
    {
        //guardamos la posición del personaje en un vector
        Vector3 newPosition = player.position;
        //cambiamos la y por la y de la cámara
        newPosition.y = transform.position.y;
        //sustituimos la posición de la cámara por la del personaje
        transform.position = newPosition;
        //obtenemos la rotación del personaje para que la camara gire con él
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
