using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public int id;
    public string ItemName;
    [TextArea(15,20)]
    public string description;
    public Sprite icon;
    public virtual void Use(){

    }
    // public Item(int id, string itemName, string desc, Sprite icon){
    //     this.id = id;
    //     this.ItemName = itemName;
    //     this.description = desc;
    //     this.icon
    // }

}
