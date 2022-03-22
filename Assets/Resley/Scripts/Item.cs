using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Inventory/Items")]

public class Item : ScriptableObject
{
    new public string name = "New Name";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        Debug.Log("Using" + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
 
}
