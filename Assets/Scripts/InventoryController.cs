using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

    public List<string> inventoryList = new List<string>();

    public GameObject inventoryPanel;
    public Text inventoryText;

    public void AddItem(string itemName)
    {
        inventoryList.Add(itemName);
        UpdateInventory();
    }

    public bool CheckItem(string itemName)
    {
        if (itemName == "")
        {
            return true;
        }
        return inventoryList.Contains(itemName);
    }

	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.I))
        {
            UpdateInventory();
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
	}

    private void UpdateInventory()
    {
        string inventoryString = "";

        foreach (string item in inventoryList)
        {
            inventoryString += item + "\n";
        }

        inventoryText.text = inventoryString;
    }
}
