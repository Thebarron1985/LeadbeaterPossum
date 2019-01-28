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
    public float airSpeed = 0.5f;

    private bool onTheGround = true;
    private bool onTree = false; 

    private Vector3 jump;
    public float jumpHeight = 2f;
    public float climbSpeed = 1f;
    Rigidbody rb;

    public float magnetStrength = 50f;
    public bool magnitized = false;
    private GameObject treeItself;
    private Vector3 treeTransform;


    private bool climbKeyPressed = false;

    public int raycastDistance;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f, 2f, 0f);

        rb.constraints = RigidbodyConstraints.FreezeRotation;
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
            magnitized = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            treeItself = this.gameObject;
            magnitized = true;
        }
    }

    // Update is called once per frame
    void Update () {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, raycastDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hit.distance, Color.blue);
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, raycastDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.red);
        }

        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.white);
        }

        if (hit.transform.tag == "Tree")
        {
            treeItself = this.gameObject;
            magnitized = true;
        }

        if (onTheGround == true && (Input.GetKey(forwardKey) || Input.GetKey(backKey)))
        {
            Debug.Log("Insert Forest Gumpy qutoe about running");
        }

        else
        {
            if (magnitized)
            {
                Debug.Log("Work You piece of shis");
                treeTransform = -(transform.position - treeItself.transform.position).normalized;
                rb.velocity = hit.point * magnetStrength;

                if (hit.distance <= 1)
                {
                    rb.velocity = new Vector3(0, 0, 0);
                   onTree = true;
                }
                else if (hit.distance > 1)
                {
                    onTree = false;
                }

                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
        }

        if (onTree == false)
        {
            climbKeyPressed = false;
            magnitized = false;
        }

        if (Input.GetKey(jumpKey) && (onTheGround || onTree))
        {
            magnitized = false;
            ReleaseXZConstraints();
            rb.AddRelativeForce(jump * jumpHeight, ForceMode.Impulse);
            onTheGround = false;
            onTree = false;
        }
        if (onTheGround == true )
        {
            if (Input.GetKey(forwardKey))
            {
                magnitized = false;
                ReleaseXZConstraints();
                rb.AddForce(sideMovement * playerSpeed  , ForceMode.Impulse);
            }

            if (Input.GetKey(backKey))
            {
                magnitized = false;
                ReleaseXZConstraints();
                rb.AddForce(sideMovement * -playerSpeed, ForceMode.Impulse);
            }
        }

        if (onTree == false)
        {

        if (onTheGround == false)
        {
            if (Input.GetKey(forwardKey))
            {
                magnitized = false;
                ReleaseXZConstraints();
                rb.AddRelativeForce(sideMovement * airSpeed, ForceMode.Impulse);
            }

            if (Input.GetKey(backKey))
            {
                magnitized = false;
                ReleaseXZConstraints();
                rb.AddRelativeForce(sideMovement * -airSpeed, ForceMode.Impulse);
            }
        }
        }


        if (onTree == true)
        {

            if (Input.GetKey(forwardKey))
            {
                magnitized = true;
                rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
                rb.AddForce(transform.forward * climbSpeed, ForceMode.Impulse);
            }

            if (Input.GetKey(backKey))

            {
                magnitized = true;
                rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
                rb.AddForce(transform.forward * -climbSpeed, ForceMode.Impulse);
            }
        }

        if (onTree == true)
        {
            Debug.Log("Collision");
            onTheGround = false;
            if (Input.GetKey(climbUpKey) && (magnitized == true))
            {
                climbKeyPressed = true;

                rb.AddForce(jump * climbSpeed, ForceMode.Impulse);

            }

            if (Input.GetKey(climbDownKey) && (magnitized == true))
            {
                climbKeyPressed = true;
                rb.AddForce(jump * -climbSpeed, ForceMode.Impulse);
            }

        }       
        if (hit.transform.tag == "Wall")
        {
            rb.constraints &= ~RigidbodyConstraints.FreezePosition;
            magnitized = false;
            onTree = false;

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

    void ReleaseXZConstraints()
    {
        rb.constraints &= ~RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionZ;
    }
}
