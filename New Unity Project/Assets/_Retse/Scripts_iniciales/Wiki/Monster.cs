using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Wiki/Monster")]

public class Monster : ScriptableObject {

    // Name of the item
    new public string name = "New Item";
    // Item icon
    public Sprite icon = null;              
}
