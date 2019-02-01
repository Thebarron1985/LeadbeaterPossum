using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour {

    public List<GameObject> focusList;

    private static Vector3 point;
    public float speed;

	// Use this for initialization
	void Start () {
        focusList = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        Vector3 direction = point - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(transform.forward, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.time);
    }
}
