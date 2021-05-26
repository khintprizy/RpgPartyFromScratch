using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> slots = new List<GameObject>();
    Inventory inventory;

    [Header("Tooltip Things")]
    public ToolTipManager toolTipManager; 
    public GameObject toolTipPanel;
    public Text tooltipText;

    /*[Header("Drag Drop Things")]
    public bool isDragging = false;
    public Image draggingImage = null;
    public Item draggingItem;
    public int draggingAmount;*/


    public bool AddItem(Item itemToAdd, int amount)
    {
        Slot emptySlot = null;
        for (int i = 0; i < slots.Count; i++)
        {
            Slot currentSlot = slots[i].GetComponent<Slot>();
            if (currentSlot.slotItem == itemToAdd && itemToAdd.isStackable && currentSlot.slotItemAmount + amount <= itemToAdd.maxStackAmount)
            {
                currentSlot.AddItem(itemToAdd, amount);
                return true;
            }
            else if (currentSlot.slotItem == null && emptySlot == null)
            {
                emptySlot = currentSlot;
            }
        }

        if (emptySlot != null)
        {
            emptySlot.AddItem(itemToAdd, amount);
            return true;
        }
        else
        {
            Debug.Log("Inventory is full");
            return false;
        }
    }

    public void RemoveItem(Item itemToRemove, int amount)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            Slot currentSlot = slots[i].GetComponent<Slot>();
            if (currentSlot.slotItem == itemToRemove)
            {
                currentSlot.RemoveItem(amount);
                return;
            }
        }
    }



    //-------------------Crafting Helpers------------------

    public bool HasInInventory(string lookupItem, int amount)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].GetComponent<Slot>().slotItem != null)
            {
                if (slots[i].GetComponent<Slot>().slotItem.itemName == lookupItem && slots[i].GetComponent<Slot>().slotItemAmount >= amount)
                {
                    return true;
                }
            }
        }
        return false;
    }


    //----------------------Tool Tip -------------------------

    public void ShowInventoryToolTip(Item toolTipItem, Vector3 pos)
    {
        toolTipManager.ShowToolTip(toolTipItem, pos, toolTipPanel, tooltipText, "- " + toolTipItem.itemName);
    }
    public void HideInventoryToolTip()
    {
        toolTipManager.HideToolTip(toolTipPanel);
    }

    //--------------------Drag Drop Things-------------------------

    /*public void DoDrag(Item itemToDrag, int amnt)
    {
        draggingItem = itemToDrag;
        isDragging = true;
        draggingImage.enabled = true;
        draggingImage.sprite = draggingItem.itemIcon;
        draggingAmount = amnt;
    }

    public void EndDrag()
    {
        draggingItem = null;
        isDragging = false;
        draggingImage.enabled = false;
        draggingAmount = 0;
    }*/
}
