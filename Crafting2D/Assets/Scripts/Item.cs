using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;

    public int purchaseLevel;

    public bool isStackable;
    public int maxStackAmount;

    public int goldCost;

    [Header("------CRAFTING-------")]
    public bool isCraftable;
    public int minLevelToCraft;
    public int makesHowMany;

    [Header("Resources")]
    public List<Item> crftItms = new List<Item>();
    public List<int> crftAmnt = new List<int>();

    public string resourceNames;
}
