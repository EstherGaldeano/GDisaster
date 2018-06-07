using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {
    public string[] dialogue;
    public string name;


    public override void Interact()
    {
        DialogSystem.Instance.AddNewDialogue(dialogue, name);
        Debug.Log("Hey bossss!!");
    }

}
