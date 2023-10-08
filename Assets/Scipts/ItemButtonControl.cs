using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemButtonControl : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI count;
    public Item currentItem;
    uiControl uiControl;

    public void Click()
    {
        uiControl.SelectItem(currentItem);
    }


    public void SetController(uiControl uiControl)
    {
        this.uiControl = uiControl;
    }

    public void DisableItemButton()
    {
        gameObject.SetActive(false);
    }

    public void SetNewIcon(Sprite sprite, int amount, Item item)
    {
        icon.sprite = sprite;
        count.text = amount.ToString();
        currentItem = item;
    }
}
