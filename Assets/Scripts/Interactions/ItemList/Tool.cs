using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Tool", menuName="Inventory/Tool")]

public class Tool : Item
{
    public float durability = 5.0f;

    public override void Use()
    {
        base.Use();
    }
}
