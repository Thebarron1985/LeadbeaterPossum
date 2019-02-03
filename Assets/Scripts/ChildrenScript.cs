using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenScript : MonoBehaviour {

    public string requiredFood = "";

    public Transform toFollow;
    private Vector3 targetPos;
    //private Vector3 offset;
    public Vector3 followLimiter;
    public float speed;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        if (!GameObject.FindObjectOfType<InventoryController>().CheckItem(requiredFood))
    //        {
    //            return;
    //        }

    //        GameObject.FindObjectOfType<InventoryController>().RemoveItem();
    //        Debug.Log("Removed food from inventory");

    //    }
    //}

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        targetPos = toFollow.position;

        if (transform.position == followLimiter)
        {
            return;
        }
        else
        {
            Move();
        }
        //if (transform.position <= followLimiter)
        //{

        //}
        //transform.position = toFollow.position - offset;
        //transform.rotation = toFollow.rotation;
	}

    private void Move()
    {
        // First, we need to find out the total distance we intend to move.
        float distance = Vector3.Distance(transform.position, targetPos);

        // Next, we need to find out how far we intend to move.
        float movement = speed * Time.deltaTime;

        // We find the increment by simply dividing movement by distance.
        // This will give us a decimal value. If the decimal is greater than
        // 1, we are moving more than the remaining distance. Lerp 
        // caps this number at 1, which in turn, returns the end position.
        float increment = movement / distance;

        // Lerp gives us the absolute position, so we pass it straight into our transform.
        transform.position = Vector3.Lerp(transform.position, targetPos, increment);
    }
}
