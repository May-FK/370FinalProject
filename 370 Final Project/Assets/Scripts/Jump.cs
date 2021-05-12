using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce;
    public float raycastDistance;
    public bool isJumping;
    public ForceMode appliedForceMode;
    private RaycastHit hit;
    private float distanceToGround;
    private Vector3 groundLocation;
    private bool isGrounded;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectGround();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Debug.Log("jumping");
                JumpForce(jumpForce, appliedForceMode);
            }
        }
    }

    private void DetectGround()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, raycastDistance))
        {
            groundLocation = hit.point;
            distanceToGround = transform.position.y - groundLocation.y;
            //Debug.Log(distanceToGround);
        }

        isGrounded = (distanceToGround <= .126f);
        //Debug.Log(isGrounded);
    }

    private void JumpForce(float jumpForce, ForceMode forceMode)
    {
        rb.AddForce(0f, (jumpForce), 0f, forceMode);
    }
}
