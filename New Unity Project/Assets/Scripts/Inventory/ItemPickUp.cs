using UnityEngine;

public class ItemPickUp : Interactible {
    public Item item;
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
    }
}
