using UnityEngine;

public class ItemPickUp : Interactible {
    public Item item;
    public GameObject text;

    public void Update()
    {
        if (base.getCerca())
        {
            text.SetActive(true);
            Debug.Log("cerca");
        }
        else
        {
            text.SetActive(false);
        }
    }
    public override void Interact()
    {
        
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("add " + item.name);
        Inventory.instance.Add(item);
        Destroy(gameObject);
        text.SetActive(false);
    }
}
