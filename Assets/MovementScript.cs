using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed;
    private float moveInput;
    public bool isGrounded;
    private Rigidbody2D rb;
    public LayerMask ground;

    public bool canJump = true;
    public float jumpValue = 0.0f;
    public PhysicsMaterial2D bounceMat, normalMat;

    public Sprite idle;
    public Sprite holding;
    public Sprite jumping;
    SpriteRenderer sr;

    public GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gc.gameover)
        {

        moveInput = Input.GetAxis("Horizontal");

        if(!Input.GetKey("space") && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        
        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 2f),
            new Vector2(2f, 1f), 0f, ground);

        if (!isGrounded)
        {
            rb.sharedMaterial = bounceMat;
            sr.sprite = jumping;
        }
        else
        {
            rb.sharedMaterial = normalMat;
            if (!Input.GetKey("space"))
            {
                sr.sprite = idle;
            }
            

        }

        if (Input.GetKey("space") && isGrounded && canJump)
        {
            jumpValue += 0.55f;
            sr.sprite = holding;
        }

        if(Input.GetKey("space")&& isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

        if (jumpValue >= 45f && isGrounded)
        {
            float tempx = moveInput * speed;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx * 2, tempy);
            Invoke("ResetJump", 0.1f);
        }

        if (Input.GetKeyUp("space"))
        {
            if (isGrounded)
            {
                float tempx = moveInput * speed;
                float tempy = jumpValue;
                rb.velocity = new Vector2(tempx * 2, tempy);
                jumpValue = 0.0f;
            }

            canJump = true;
        }
        }
    }
    void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }
}
