using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody2D rb;
    public float moveSpeed;
    public Animator anim;
    [Header("Jump")]
    public float jumpForce;
    public Transform groundPoint;
    public LayerMask whatisGround;
    public bool onGround;
    private JsonController json;
    
    // Start is called before the first frame update
    void Start()
    {
        json = FindObjectOfType<JsonController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveAndJump();
        animations();

        Debug.Log(rb.gravityScale);

    }
    public void moveAndJump()
    {
        
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);
        if (rb.velocity.x > 0)  // Karakteri döndürme
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        //Jump
        onGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatisGround);
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    
    public void animations()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("Vertical", rb.velocity.y);
        anim.SetBool("isGround", onGround);
    }
   
}
