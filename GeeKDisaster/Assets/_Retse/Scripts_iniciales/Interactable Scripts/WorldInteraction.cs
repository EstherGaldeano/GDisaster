using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {

    /*
    Esta clase sirve como base para las interacciones con el "mundo" del juego     
    */

    private void Update()
    {
        //If para comprobar si la tecla de accion asignada (la 'e') esta pulsada y si 
        //evitar que el evento active interacciones en objetos "detras" del que se quiere interactuar
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetInteraction();
        }        
    }

    //manda un ray desde la camara hacia la posicion del raton
    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;

            if (interactedObject.tag == "Interactable Object")
            {
                interactedObject.GetComponent<Interactable>().Interact();
            }
        }
    }
}
