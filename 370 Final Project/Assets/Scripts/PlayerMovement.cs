using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    public bool isJumping;
    public float raycastDistance;
    public ForceMode appliedForceMode;

    private float xAxis;
    private float zAxis;
    private Rigidbody rb;
    private RaycastHit hit;
    private float distanceToGround;
    private Vector3 groundLocation;
    private bool isGrounded;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        isJumping = Input.GetKeyDown(KeyCode.Space);
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, raycastDistance))
        {
            groundLocation = hit.point;
            distanceToGround = transform.position.y - groundLocation.y;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + Time.deltaTime * movementSpeed * transform.TransformDirection(xAxis, 0f, zAxis));
        isGrounded = distanceToGround <= 1f;
        if (isJumping && isGrounded)
        {
            StartCoroutine(Jump());
        }
    }

    private void JumpForce(float jumpForce, ForceMode forceMode)
    {
        rb.AddForce(jumpForce * rb.mass * Time.deltaTime * Vector3.up, forceMode);
    }
    private IEnumerator Jump()
    {
        JumpForce(jumpForce, appliedForceMode);
        isGrounded = false;
        yield return new WaitUntil(() => !isJumping);
    }
}
