using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class itemsControl : MonoBehaviour
{
    public static itemsControl ItemsControl;

    [SerializeField] uiControl uiControl;
    [SerializeField] GameObject[] itemPrefabs;
    public List<Item> items;

    public Item SelectedItem;

    void Awake()
    {
        items = new List<Item>();
        items.Add((Item)new Ammo(100));
        SelectedItem = items[0];
        if (ItemsControl == null)
        {
            ItemsControl = this;
        }
    }

    private void Start()
    {
        uiControl.UpdateItemButtons();
    }

    public void AddItem(Item item)
    {
        bool f = false;
        foreach (Item i in items)
        {
            if(i.name == item.name)
            {
                i.amount+=item.amount;
                f = true;
                break;
            }
        }
        if (!f) { items.Add(item); }
        uiControl.UpdateItemButtons();
    }

    public bool CheckItem(Item item)
    {
        foreach (Item i in items)
        {
            if (i.name == item.name)
            {
                return true;
            }
        }
        return false;
    }

    public bool ConsumptItem(Item item)
    {
        foreach (Item i in items)
        {
            if (i.name == item.name)
            {
                if(i.amount > 0)
                {
                    i.amount--;
                    uiControl.UpdateItemButtons();
                    if(i.amount == 0)
                    {
                        items.Remove(i);
                    }
                    return true;
                }
                
            }
        }
        return false;
    }

    public void DeleteItem(Item item)
    {
        foreach (Item i in items)
        {
            if (i.name == item.name)
            {
                items.Remove(i);
                uiControl.UpdateItemButtons();
                break;
            }
        }
    }

    public void SpawnNewItem(Vector3 pos, Item item)
    {
        int a = 0;
        foreach (string nameItem in uiControl.namesItem)
        {
            if(item.name == nameItem)
            {
                GameObject go = Instantiate(itemPrefabs[a], pos, new Quaternion());
            }
            a++;
        }
    }
}

public abstract class Item
{
    public int amount;
    public string name;
}

public enum Items
{
    none,
    BulletproofCloak,
    ammo
}


public class BulletproofCloak : Item
{ 
    public BulletproofCloak(int amount)
    {
        base.amount = amount;
        base.name = "BulletproofCloak";

    }
}

public class Ammo : Item
{
    public Ammo(int amount)
    {
        base.amount = amount;
        base.name = "Ammo";

    }
}