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
    public float turnSmoothTime = .1f;
    float turnSmoothVelocity;

    public Transform cam;

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
        

        
    }

    private void FixedUpdate()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        //isJumping = Input.GetKeyDown(KeyCode.Space);
        //Debug.Log("isJumping: " + isJumping);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, raycastDistance))
        {
            groundLocation = hit.point;
            distanceToGround = transform.position.y - groundLocation.y;
            //Debug.Log(distanceToGround);
        }

        Vector3 direction = new Vector3(xAxis, 0f, zAxis);
        if (direction.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.MovePosition(transform.position + Time.deltaTime * movementSpeed * moveDir);
        }
        
        //Debug.Log("isGrounded: " + isGrounded);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump");
            if (isGrounded)
            {
                rb.AddForce(jumpForce * rb.mass * Time.deltaTime * Vector3.up, appliedForceMode);
                Debug.Log("jumping");
                //StartCoroutine(Jump());
            }
        }
    }

    /*private void JumpForce(float jumpForce, ForceMode forceMode)
    {
        rb.AddForce(jumpForce * rb.mass * Time.deltaTime * Vector3.up, forceMode);
    }
    private IEnumerator Jump()
    {
        JumpForce(jumpForce, appliedForceMode);
        isGrounded = false;
        yield return new WaitUntil(() => !isJumping);
    }*/
}
