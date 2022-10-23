using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Movement Axis and Speed
    public float moveX;
    public float moveZ;
    public float baseSpeed;
    public float moveSpeed;
    #endregion
    #region Misc
    public Rigidbody rb;
    public bool isMoving;
    public Animator m_anim;
    #endregion
    #region Jump
    public float jumpForce;
    public Vector3 jumpDist;
    public bool isGrounded;
    #endregion
    #region Points
    //I'll toss points in here because why not, #spaghetticode
    public int points;

    #endregion
    // Start is called before the first frame update
    private void Awake()
    {
        baseSpeed = 10;
    }
    void Start()
    {
        moveSpeed = baseSpeed;
        jumpForce = 4;
        jumpDist = new Vector3(0, 5f, 0);
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((moveX > 0 || moveZ > 0))
        {
            m_anim.SetBool("isMoving", true);
        }
        else
        {
            m_anim.SetBool("isMoving", false);
        }
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        #region Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jumpDist * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        #endregion
    }
    private void FixedUpdate()
    {
        Walk();
    }
    private void Walk()
    {
        #region Old Movement Code
        //new Vector3(moveX * moveSpeed * Time.deltaTime, rb.velocity.y , moveZ * moveSpeed * Time.deltaTime); 
        //this sets velocity in worldspace, ie the x, y and z axes of the world, which doesn't rotate with the camera. Don't use this code again dipshit
        #endregion
        #region Dope Ass New Movement Code
        rb.velocity = transform.TransformDirection(new Vector3(moveX * moveSpeed, rb.velocity.y, moveZ * moveSpeed));
        //this sets velocity relative to its local axis, you know, the shit that rotating the camera actually would change, I have brain damage.
        #endregion
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

}
