using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ObjectPickup : MonoBehaviour {

    public string objectName = "Pizza Pasta put it in a box";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player")
        {
            //if (Input.GetKey(KeyCode.Space))
            //{
            //game.FindObjectOfType<UIController>().ShowMessage("Got " + objectName, 2);
            Debug.Log("bye felici");
            GameObject.FindObjectOfType<InventoryController>().AddItem(objectName);
            gameObject.SetActive(false);

            //}
        }
    }
}
