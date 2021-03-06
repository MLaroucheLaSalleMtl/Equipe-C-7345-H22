using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquimepentSlot equipSlot;
    public SkinnedMeshRenderer mesh;

    public int armorModifier;
    public int damageModifier;
    public int healthModifier;
    public int manaModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
        //AddToEquipSlot();
    }
}

public enum EquimepentSlot { Head, Chest, Leg, Weapon, Shield, Feet, Consumable}
