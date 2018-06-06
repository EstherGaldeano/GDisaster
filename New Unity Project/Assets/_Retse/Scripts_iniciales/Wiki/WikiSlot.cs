using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WikiSlot : MonoBehaviour {

    public Text text;

    Monster monster;
    public void AddMonster(Monster newMonster)
    {
        monster = newMonster;

        text.text = monster.name;
        text.enabled = true;
    }

    public void ClearSlot()
    {
        monster = null;

        text.text = "";
        text.enabled = false;
    }
}
