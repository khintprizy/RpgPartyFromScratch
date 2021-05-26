using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler/*, IBeginDragHandler, IDragHandler, IDropHandler*/
{
    Inventory inventory;

    Image slotImage;
    Text slotText;

    public Item slotItem;
    public int slotItemAmount;

    private void Start()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
        slotImage = transform.GetChild(0).GetComponent<Image>();
        slotText = transform.GetChild(1).GetComponent<Text>();
        ShowUI();
    }

    public void AddItem(Item itemToAdd, int amnt)
    {
        if (itemToAdd == slotItem)
        {
            slotItemAmount += amnt;
        }
        else if (slotItem != null && itemToAdd != slotItem)
        {
            AddToEmpty(itemToAdd, amnt);
        }
        else
        {
            slotItem = itemToAdd;
            slotItemAmount = amnt;
        }
        ShowUI();
    }

    public void RemoveItem(int amnt)
    {
        if (slotItem != null)
        {
            slotItemAmount -= amnt;
            if (slotItemAmount <= 0)
            {
                slotItem = null;
            }
        }
        ShowUI();
    }

    void ShowUI()
    {
        if (slotItem != null)
        {
            slotImage.enabled = true;
            slotText.enabled = true;
            slotImage.sprite = slotItem.itemIcon;
            slotText.text = slotItemAmount.ToString();
        }
        else
        {
            slotImage.enabled = false;
            slotText.enabled = false;
        }
    }

    private void AddToEmpty(Item itemToAdd, int amnt)
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            Slot currentSlot = inventory.slots[i].GetComponent<Slot>();
            if (currentSlot.slotItem == null)
            {
                currentSlot.slotItem = itemToAdd;
                currentSlot.slotItemAmount = amnt;
                currentSlot.slotImage.enabled = true;
                currentSlot.slotImage.sprite = itemToAdd.itemIcon;
                currentSlot.slotText.enabled = true;
                currentSlot.slotText.text = currentSlot.slotItemAmount.ToString();
                Debug.Log("Item added to " + inventory.slots[i]);
                return;
            }
        }
    }

    //-------------------------ToolTip Mouse Over Stuff-----------------------

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (slotItem != null)
        {
            inventory.ShowInventoryToolTip(slotItem, gameObject.transform.position);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        inventory.HideInventoryToolTip();
    }

    //----------------------Drag Drop Things -----------------------

    /*public void OnBeginDrag(PointerEventData eventData)
    {
        if (slotItem != null)
        {
            inventory.DoDrag(slotItem, slotItemAmount);
            RemoveItem(slotItemAmount);
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        inventory.draggingImage.transform.position = Input.mousePosition;
    }
    public void OnDrop(PointerEventData eventData)
    {
        AddItem(inventory.draggingItem, inventory.draggingAmount);
        inventory.EndDrag();
    }*/
}
