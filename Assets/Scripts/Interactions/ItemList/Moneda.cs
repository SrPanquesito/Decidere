using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour, Interactable
{
    public Item item;
    
    public float maxRange {get{return 5f;}}
    public void OnHoverStart(){
        Debug.Log("Estás viendo una moneda");
    }
    public void OnInteract(){
        Debug.Log("Interactuaste con una moneda");

        this.gameObject.SetActive(false);
        Inventory.InventoryInstance.Add(item);
    }
    public void OnHoverEnd(){
        Debug.Log("Dejaste de ver una moneda");
    }
}
