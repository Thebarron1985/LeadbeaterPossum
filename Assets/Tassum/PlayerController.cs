using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    public KeyCode forwardKey = KeyCode.RightArrow;
    public KeyCode backKey = KeyCode.LeftArrow;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode climbUpKey = KeyCode.UpArrow;
    public KeyCode climbDownKey = KeyCode.DownArrow;

    public Vector3 sideMovement;
    public float playerSpeed = 0.5f;

    private bool onTheGround = true;
    private bool onTree = false; 

    public Vector3 jump;
    public float jumpHeight = 2f;
    public float climbSpeed = 1f;
    Rigidbody rb;

    private bool climbKeyPressed = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f, 2f, 0f);
	}

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onTheGround = true;
        }

        if (other.gameObject.tag == "Tree")
        {
            onTree = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Tree")
        {
            onTree = false;
            climbKeyPressed = false;
        }
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey(jumpKey) && (onTheGround || onTree))
        {
            rb.AddForce(jump * jumpHeight, ForceMode.Impulse);
            onTheGround = false;
            onTree = false;
        }
        if (onTheGround == true || onTree == true)
        {
            if (Input.GetKey(forwardKey))
            {
                rb.AddForce(sideMovement * playerSpeed  , ForceMode.Impulse);
            }

            if (Input.GetKey(backKey))
            {
                rb.AddForce(sideMovement * -playerSpeed, ForceMode.Impulse);
            }
        }
        if (onTree == true)
        {
            onTheGround = false;
            if (Input.GetKey(climbUpKey))
            {
                climbKeyPressed = true;
                rb.AddForce(jump * climbSpeed, ForceMode.Impulse);
            }

            if (Input.GetKey(climbDownKey))
            {
                climbKeyPressed = true;
                rb.AddForce(jump * -climbSpeed, ForceMode.Impulse);
            }

            if (Input.GetKeyUp(climbUpKey))
            {
                climbKeyPressed = false;
            }

            if (Input.GetKeyUp(climbDownKey))
            {
                climbKeyPressed = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (climbKeyPressed == true)
        {
            if (GetComponent<Rigidbody>().velocity.magnitude > climbSpeed)
            {
                GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * climbSpeed;
            }
        }
        else climbKeyPressed = false;
    }
}
