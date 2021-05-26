using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CraftingSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    Inventory inventory;

    Crafting craftingScript;

    public Item craftItem;
    Image craftItemIcon;

    private void Start()
    {
        gameObject.SetActive(false);
        InvokeRepeating("CheckIfHas", 0.5f, 0.5f);

        inventory = GameObject.FindObjectOfType<Inventory>();
        if (craftItem == null)
        {
            Destroy(gameObject);
        }
        craftingScript = GameObject.FindObjectOfType<Crafting>();
        craftItemIcon = GetComponent<Image>();
        craftItemIcon.sprite = craftItem.itemIcon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        craftingScript.CraftItem(craftItem);
    }

    public void CheckIfHas()
    {
        if (craftingScript.isOnCraftPanel(craftItem))
        {
            gameObject.SetActive(true);
        } 
    }

    //---------------Crafting ToolTip Things-----------------

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (craftItem != null)
        {
            craftingScript.ShowCraftingToolTip(craftItem, gameObject.transform.position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        craftingScript.HideCraftingToolTip();
    }
}
