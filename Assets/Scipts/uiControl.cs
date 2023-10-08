using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiControl : MonoBehaviour
{
    [SerializeField] itemsControl itemsController;
    [SerializeField] GameObject itemButtonPrefab;
    [SerializeField] GameObject deleteItemsButton;
    [SerializeField] GameObject inventoryBaseObject;
    [SerializeField] public Sprite[] icons;
    [SerializeField] public string[] namesItem;

    GameObject[] itemButtons;
    ItemButtonControl[] itemButtonControls;

    private void Awake()
    {
        itemButtons = new GameObject[6];
        itemButtonControls = new ItemButtonControl[6];

        for (int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i] = Instantiate(itemButtonPrefab);
            itemButtonControls[i] = itemButtons[i].GetComponent<ItemButtonControl>();
            itemButtonControls[i].SetController(this);

            itemButtons[i].SetActive(false);
        }


    }

    public void UpdateItemButtons()
    {
        for (int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i].SetActive(false);
        }

        for (int i = 0; i < itemsController.items.Count; i++)
        {
            itemButtons[i].SetActive(true);
            string item = itemsController.items[i].name;
            int amount = itemsController.items[i].amount;

            itemButtons[i].transform.SetParent(inventoryBaseObject.transform);
            itemButtons[i].transform.localPosition = new Vector3(-170 * i, 0, 0);

            for (int a = 0; a < icons.Length; a++)
            {
                if (namesItem[a] == item)
                {
                    itemButtonControls[i].SetNewIcon(icons[a], amount, itemsController.items[i]);
                    break;
                }
                    
            }
        }
    }

    public void SelectItem(Item item)
    {
        itemsController.SelectedItem = item;
        deleteItemsButton.SetActive(true);
    }

    public void DisableDeleteButton()
    {
        deleteItemsButton.SetActive(false);
        itemsController.DeleteItem(itemsController.SelectedItem);
    }
}
