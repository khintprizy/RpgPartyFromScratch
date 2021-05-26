using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    Inventory inventory;

    Shop shop;

    public Item shopItem;
    Image shopIcon;

    private void Start()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
        if (shopItem == null)
        {
            Destroy(gameObject);
        }
        shop = GameObject.FindObjectOfType<Shop>();
        shopIcon = GetComponent<Image>();
        shopIcon.sprite = shopItem.itemIcon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        shop.PurchaseItem(shopItem);
    }


    //----------------ShopToolTipThings----------------

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (shopItem != null)
        {
            shop.ShowShopToolTip(shopItem, gameObject.transform.position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        shop.HideShopToolTip();
    }
}
