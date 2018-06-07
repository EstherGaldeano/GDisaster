using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WikiSlot : MonoBehaviour
{

    public Text text;
    public Image icon;

    Monster monster;

    //method to display a monster in the monsterpedia list
    public void AddMonster(Monster newMonster)
    {
        monster = newMonster;

        //it shows the name of the monster
        text.text = monster.name;
        text.enabled = true;
    }

    //method to clear a slot in the monsterpedia list
    public void ClearSlot()
    {
        //set everything to null
        monster = null;

        text.text = "";
        text.enabled = false;
    }

    //method to display the monster icon in the monsterpedia
    public void showMonster()
    {
        Debug.Log("imagen");
        icon.sprite = monster.icon;
    }
}
