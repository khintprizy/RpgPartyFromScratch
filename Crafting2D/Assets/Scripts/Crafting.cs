using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public ItemDatabase dataBase;
    public Inventory inventory;

    public GameObject craftingPanel;
    public GameObject craftingSlot;

    public int playerLevel;

    [Header("Crafting Tooltip Things")]
    public ToolTipManager toolTipManager;
    public GameObject craftingTooltipPanel;
    public Text craftingTooltipText;

    private void Start()
    {
        GenSlots();
    }

    void GenSlots()
    {
        for (int i = 0; i < dataBase.dataBaseItems.Count; i++)
        {
            Item currentItem = dataBase.dataBaseItems[i];
            if (currentItem.isCraftable && playerLevel >= currentItem.minLevelToCraft)
            {
                GameObject go = Instantiate(craftingSlot, craftingPanel.transform.position, Quaternion.identity);
                go.transform.SetParent(craftingPanel.transform);
                go.GetComponent<CraftingSlot>().craftItem = currentItem;
            }
        }
    }

    public void CraftItem(Item itemToCraft)
    {
        if (itemToCraft.isCraftable)
        {
            if (CanCraft(itemToCraft))
            {
                Add(itemToCraft);
            }
            else
            {
                Debug.Log("cant craft");
            }
        }
        else
        {
            return;
        }
    }

    public bool CanCraft(Item itemToLookUp)
    {
        for (int i = 0; i < itemToLookUp.crftItms.Count; i++)
        {
            Item currentItem = itemToLookUp.crftItms[i];
            int currentAmount = itemToLookUp.crftAmnt[i];
            if (!inventory.HasInInventory(currentItem.itemName, currentAmount))
            {
                return false;
            }
        }
        return true;
    }

    public bool isOnCraftPanel(Item itemToLookUp)
    {
        for (int i = 0; i < itemToLookUp.crftItms.Count; i++)
        {
            Item currentItem = itemToLookUp.crftItms[i];
            if (!inventory.HasInInventory(currentItem.itemName, 1))
            {
                return false;
            }
        }
        return true;
    }



    void Add(Item itemToAdd)
    {
        inventory.AddItem(itemToAdd, itemToAdd.makesHowMany);
        RemoveResourcesOf(itemToAdd);
    }

    void RemoveResourcesOf(Item itemToRemove)
    {
        for (int i = 0; i < itemToRemove.crftItms.Count; i++)
        {
            Item currentItem = itemToRemove.crftItms[i];
            int currentAmount = itemToRemove.crftAmnt[i];
            inventory.RemoveItem(currentItem, currentAmount);
        }
    }

    //----------------------Crafting Tool Tip -------------------------

    public void ShowCraftingToolTip(Item toolTipItem, Vector3 pos)
    {
        toolTipManager.ShowToolTip(toolTipItem, pos, craftingTooltipPanel, craftingTooltipText, 
            toolTipItem.itemName + "\n\n" + "- " + toolTipItem.resourceNames);
    }
    public void HideCraftingToolTip()
    {
        toolTipManager.HideToolTip(craftingTooltipPanel);
    }
}
