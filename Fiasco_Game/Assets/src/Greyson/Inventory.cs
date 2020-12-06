using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<ItemTypes, int> inventory;

    private void Awake() {
        inventory = new Dictionary<ItemTypes, int>();
    }

    public void Add(ItemTypes type, int count = 1) {
        if (!inventory.TryGetValue(type, out int current)) {
            inventory.Add(type, count);
        }
        else {
            inventory[type] += count;
        }
    }

    public int Get(ItemTypes type) {
        if (inventory.TryGetValue(type, out int current)) {
            return current;
        }
        else {
            throw new KeyNotFoundException();
        }
    }
}
