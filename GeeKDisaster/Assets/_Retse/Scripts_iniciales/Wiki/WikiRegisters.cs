using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WikiRegisters : MonoBehaviour
{

    public static WikiRegisters instance;

    public Monster m1;
    public Monster m2;
    public Monster m3;
    public Monster m4;
    public Monster m5;
    public Monster m6;
    public Monster m7;
    public Monster m8;
    public Monster m9;

    void Awake()
    {
        if (instance != null)
        {
            //Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
        Add();
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public List<Monster> monsters = new List<Monster>();

    public void Add()
    {
        //if the gameobject is not null is added to the list
        if (m1 != null)
        {
            monsters.Add(m1);
        }

        if (m2 != null)
        {
            monsters.Add(m2);
        }

        if (m3 != null)
        {
            monsters.Add(m3);
        }

        if (m4 != null)
        {
            monsters.Add(m4);
        }

        if (m5 != null)
        {
            monsters.Add(m5);
        }

        if (m6 != null)
        {
            monsters.Add(m6);
        }

        if (m7 != null)
        {
            monsters.Add(m7);
        }

        if (m8 != null)
        {
            monsters.Add(m8);
        }

        if (m9 != null)
        {
            monsters.Add(m9);
        }


        onItemChangedCallback.Invoke();

    }

}
