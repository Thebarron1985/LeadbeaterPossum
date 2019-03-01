using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingPlayerControllerHopefully : MonoBehaviour {

//    public KeyCode forwardKey = KeyCode.RightArrow;
//    public KeyCode backKey = KeyCode.LeftArrow;
//    public KeyCode jumpKey = KeyCode.Space;
//    public KeyCode climbUpKey = KeyCode.UpArrow;
//    public KeyCode climbDownKey = KeyCode.DownArrow;

//    public Vector3 sideMovement;

//    private bool onTheGround = true;
//    private bool onTree = false;

//    public Vector3 jump;

//    public Vector3 sideClimbMovement;
//    public Vector3 verticalClimbMovement;

//    public float climbDrag;
//    private float normalDrag; 

//    Rigidbody rb;

//    // Use this for initialization
//    void Start () {
//        normalDrag = gameObject.GetComponent<Rigidbody>().drag;
//	}

//    private void OnTriggerStay(Collider other)
//    {
//        if (other.tag == "TreeTrigger")
//        {
//            onTree = true;
//            gameObject.GetComponent<Rigidbody>().useGravity = false;
//            gameObject.GetComponent<Rigidbody>().drag = climbDrag;
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.tag == "TreeTrigger")
//        {
//            onTree = false;
//            gameObject.GetComponent<Rigidbody>().useGravity = true;
//            gameObject.GetComponent<Rigidbody>().drag = normalDrag;
//        }
//    }


//    // Update is called once per frame
//    void Update ()
//    {
//        if (onTree == false)
//        {
//            PlayerRunning();
//        }
//        else if (onTree == true)
//        {
//            PlayerClimbing();
//        }
//	}

//    void PlayerRunning()
//    {
//        if (Input.GetKey(forwardKey))
//        {
//            gameObject.GetComponent<Rigidbody>().AddRelativeForce(sideMovement, ForceMode.Impulse);
//        }

//        if (Input.GetKey(backKey))
//        {
//            gameObject.GetComponent<Rigidbody>().AddRelativeForce(-sideMovement, ForceMode.Impulse);
//        }

//        if (onTheGround == true)
//        {
//            if (Input.GetKeyDown(jumpKey))
//            {
//                onTheGround = false;
//                gameObject.GetComponent<Rigidbody>().AddForce(jump, ForceMode.Impulse);
//            }
//        }
//    }

//    private void OnCollisionEnter(Collision other)
//    {
//        if (other.gameObject.tag == "Ground")
//        {
//            onTheGround = true;
//        }
//    }

//    void PlayerClimbing()
//    {
//        if (Input.GetKey(forwardKey))
//        {
//            gameObject.GetComponent<Rigidbody>().AddForce(sideClimbMovement, ForceMode.Impulse);
//        }

//        if (Input.GetKey(backKey))
//        {
//            gameObject.GetComponent<Rigidbody>().AddForce(-sideClimbMovement, ForceMode.Impulse);
//        }

//        if (Input.GetKey(climbUpKey))
//        {
//            gameObject.GetComponent<Rigidbody>().AddForce(verticalClimbMovement, ForceMode.Impulse);
//        }

//        if (Input.GetKey(climbDownKey))
//        {
//            gameObject.GetComponent<Rigidbody>().AddForce(-verticalClimbMovement, ForceMode.Impulse);
//        }
//    }
}
