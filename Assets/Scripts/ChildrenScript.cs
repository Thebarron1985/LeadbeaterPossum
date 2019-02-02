using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenScript : MonoBehaviour {

    public string requiredFood = "";

    private void OnTriggerEnter(Collider other)
    {
        if (!GameObject.FindObjectOfType<InventoryController>().CheckItem(requiredFood))
        {
            return;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
