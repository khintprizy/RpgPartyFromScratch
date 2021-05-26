using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickAdd : MonoBehaviour
{
    public ItemDatabase dataBase;
    public Inventory inventory;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventory.AddItem(dataBase.GetItemById(0), 5);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            inventory.AddItem(dataBase.GetItemById(1), 5);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.AddItem(dataBase.GetItemById(2), 5);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            inventory.AddItem(dataBase.GetItemById(3), 5);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            inventory.AddItem(dataBase.GetItemById(4), 5);
        }

        //-----------Adding to craft------------


    }
}
