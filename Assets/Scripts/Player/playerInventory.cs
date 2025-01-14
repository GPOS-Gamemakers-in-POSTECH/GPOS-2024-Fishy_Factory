using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    public List<KeyValuePair<int, int>> itemAndCount = new List<KeyValuePair<int, int>>();



    void Awake()
    {



    }

    // Start is called before the first frame update
    void Start()
    {
        addToInventory(1, 12);
        PrintInventory();
        addToInventory(1, 12);
        PrintInventory();
        addToInventory(2, 12);
        PrintInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addToInventory(int itemID, int count)
    {
        // Flag to check if itemID is already in the list
        bool itemExists = false;

        // Iterate through the list to find the itemID
        for (int i = 0; i < itemAndCount.Count; i++)
        {
            if (itemAndCount[i].Key == itemID)
            {
                // If itemID is found, update its count
                itemAndCount[i] = new KeyValuePair<int, int>(itemID, itemAndCount[i].Value + count);
                itemExists = true;                
                break;
            }
        }

        // If itemID was not found, add it as a new item
        if (!itemExists)
        {
            itemAndCount.Add(new KeyValuePair<int, int>(itemID, count));
        }
    }

    public void PrintInventory()
    {
        foreach (KeyValuePair<int, int> item in itemAndCount)
        {
            Debug.Log("Item ID: " + item.Key + ", Count: " + item.Value);
        }
        Debug.Log("----");
    }




}
