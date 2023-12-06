using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float moveForce = 8f;
    [SerializeField]
    public float jumpForce = 8f;
    [SerializeField]
    public float sliceForce = 10f;

    private float movementX;
    [SerializeField]
    private Rigidbody2D myBody;

    public BoxCollider2D Collider;
    private SpriteRenderer sr;
    private Animator anim;

    private bool isGrounded;
    private string Run_Animation = "Run";
    private string Jump_Animation = "Jump";
    private string Crouch_Animation = "Crouch";
    private string Slice_Animation = "Slice";
    private string GROUND_TAG = "Ground";
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        Collider = GetComponent<BoxCollider2D>();
 
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMoveKeyBoard();
        AnimatePlayer();
        playerJump();
        playerSlice();
    }
     void FixedUpdate()
    {
        
    }
    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }
    void AnimatePlayer()
    {
        if(movementX > 0)
        {
            anim.SetBool(Run_Animation, true);
            sr.flipX = false;
        }else if (movementX < 0)
        {
            anim.SetBool(Run_Animation, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(Run_Animation, false);
        }
    }
    void playerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool(Jump_Animation, true);
        }
    }
    void playerSlice()
    {
        if (Input.GetKey("x"))
        {
            anim.SetBool(Slice_Animation, true);
            transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * sliceForce;
        }
        else
        {
            anim.SetBool(Slice_Animation, false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            anim.SetBool(Jump_Animation, false);
        }
    }
}
