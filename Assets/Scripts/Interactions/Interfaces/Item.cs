using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item es el objeto intermediario para almacenar info acerca de un GameObject para guardar en Inventory.
// Intermediario entre objeto real en escena y objeto en el inventario
public enum ItemType
{
    Consumable, Tool, Generic
}

[CreateAssetMenu(fileName= "New Item", menuName= "Inventory/Generic")]

public class Item : ScriptableObject
{
    public int id;
    public ItemType itemType = ItemType.Generic;
    public string ItemName;
    [TextArea(15,20)]
    public string description;
    public Sprite icon = null;
    public virtual void Use(){

    }
    // public Item(int id, string itemName, string desc, Sprite icon){
    //     this.id = id;
    //     this.ItemName = itemName;
    //     this.description = desc;
    //     this.icon
    // }

}
