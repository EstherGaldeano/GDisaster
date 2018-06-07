using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WikiUI : MonoBehaviour
{

    public Transform itemsParent;

    WikiRegisters wiki;

    WikiSlot[] slots;
    // Use this for initialization
    void Start()
    {
        //acces to wikiregister
        wiki = WikiRegisters.instance;

        //we try to show the items
        wiki.onItemChangedCallback += UpdateUI;

        //gets the children components
        slots = itemsParent.GetComponentsInChildren<WikiSlot>();

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Inventory"))
        {
            
                inventoryUI.SetActive(!inventoryUI.activeSelf);
            
        } */
    }

    void UpdateUI()
    {
        //debug funtion
        Debug.Log("holaMonster");

        //loop that itearte tje slot array
        for (int i = 0; i < slots.Length; i++)
        {
            //if the position of the slot is not greater than the number of monsters
            if (i < wiki.monsters.Count)
            {
                //the monster is added
                slots[i].AddMonster(wiki.monsters[i]);
            }
            else
            {
                //if it is greater the slot is cleared
                slots[i].ClearSlot();
            }
        }
    }
}
