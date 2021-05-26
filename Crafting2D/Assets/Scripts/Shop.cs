using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public ItemDatabase dataBase;
    public Inventory inventory;

    public GameObject shopSlot;

    public int purchaseLevel;

    [Header("Shop Tooltip Things")]
    public ToolTipManager toolTipManager;
    public GameObject shopTooltipPanel;
    public Text shopTooltipText;

    private void Start()
    {
        GenShopSlots();
    }

    void GenShopSlots()
    {
        for (int i = 0; i < dataBase.dataBaseItems.Count; i++)
        {
            Item currentItem = dataBase.dataBaseItems[i];
            if (purchaseLevel >= currentItem.purchaseLevel)
            {
                GameObject go = Instantiate(shopSlot, gameObject.transform.position, Quaternion.identity);
                go.transform.SetParent(gameObject.transform);
                go.GetComponent<ShopSlot>().shopItem = currentItem;
            }
        }
    }

    public void PurchaseItem(Item itemToPurchase)
    {
        Add(itemToPurchase);
    }

    void Add(Item itemToAdd)
    {
        inventory.AddItem(itemToAdd, 5);
    }

    //----------------------Shop Tool Tip -------------------------

    public void ShowShopToolTip(Item toolTipItem, Vector3 pos)
    {
        toolTipManager.ShowToolTip(toolTipItem, pos, shopTooltipPanel, shopTooltipText, 
            toolTipItem.itemName);
    }
    public void HideShopToolTip()
    {
        toolTipManager.HideToolTip(shopTooltipPanel);
    }
}
