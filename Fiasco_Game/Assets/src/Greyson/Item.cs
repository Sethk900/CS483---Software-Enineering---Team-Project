using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public ItemTypes Type;

    public Inventory Inventory;

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left) {
            Inventory.Add(Type);
        }
        else if (eventData.button == PointerEventData.InputButton.Right) {
            Debug.Log(message: Inventory.Get(Type));
        }
    }
}
