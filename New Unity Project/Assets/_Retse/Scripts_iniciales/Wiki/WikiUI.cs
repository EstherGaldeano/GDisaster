using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WikiUI : MonoBehaviour {

    public Transform itemsParent;

    WikiRegisters wiki;

    WikiSlot[] slots;
    // Use this for initialization
    void Start()
    {
        wiki = WikiRegisters.instance;
        wiki.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<WikiSlot>();
    }

    void UpdateUI()
    {
        Debug.Log("holaMonster");

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < wiki.monsters.Count)
            {
                slots[i].AddMonster(wiki.monsters[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
