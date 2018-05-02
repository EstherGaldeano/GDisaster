using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryInterface : MonoBehaviour {

    private static bool gamePaused = false;
    public GameObject inventoryUI;
    public GameObject miniMapUI;
    [SerializeField] private MouseLook cursor;

    void Update () {
        //comprobamos si apretamos la i (inventario)
        if (Input.GetKeyDown(KeyCode.I))
        {
            //comprobamos si ya esta abierto
            if (gamePaused)
            {
                //si lo esta lo abrimos
                closeInv();                
            }
            else
            {
                //si no lo esta lo cerramos 
                openInv();
            }
        }
	}

    /**
     * openInv muestra el inventario y desactiva el minimapa
     * para evitar que se sobrepongan y moleste
     * 
     * indicamos que esta abierto poniendo en true el bool
     */
    private void openInv()
    {
        inventoryUI.SetActive(true);
        closeMap();
        gamePaused = true;
    }

    /**
     * openInv quita el inventario y reactiva el minimapa
     * 
     * indicamos que esta cerrado poniendo en false el bool
     */
    private void closeInv()
    {
        inventoryUI.SetActive(false);
        openMap();
        gamePaused = false;
    }

    //método que activa el minimapa
    private void openMap()
    {
        miniMapUI.SetActive(true);
    }

    //método que desactiva el minimapa
    private void closeMap()
    {
        miniMapUI.SetActive(false);
    }
}
