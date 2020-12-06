using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "new Consumable", menuName = "Items/Consumable")]
public class Consumable : Item
{
    public int heal = 0;

    public override void Use() {
        GameObject player = Inventory.instance.player;
        Heal(heal);
        Inventory.instance.Remove(this);
    }

    public void Heal(int amount) {
        UIScript.health += amount;

        if (UIScript.health > 100) {
            UIScript.health = 100;
        }
    }
}
