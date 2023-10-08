using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemTriggerControl : MonoBehaviour
{
    public Items item;
    public int amount;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item newItem = null;
        switch (item)
        {
            case Items.none:
                return;
                break;
            case Items.BulletproofCloak:
                newItem = (Item)(new BulletproofCloak(amount));
                break;
            case Items.ammo:
                newItem = (Item)(new Ammo(15));
                break;
            default:
                break;
        }

        itemsControl.ItemsControl.AddItem(newItem);
        gameObject.SetActive(false);
    }
}
