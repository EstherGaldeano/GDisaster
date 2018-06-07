using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    [HideInInspector]
    public virtual void Interact()
    {
        Debug.Log("Interactuando con la clase base");
    }      
}