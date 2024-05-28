using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private UIController ui;

    [SerializeField] private CoinManager coinManager;

    [SerializeField] private LayerMask ground;
    
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        float yPos = transform.position.y;
        
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (!Input.GetButtonUp("Fire1"))
            {
                anim.SetBool("attacking", true);
            }
        }

        if (yPos < -5.0f)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            OutOfBounds();
        }

        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()    // this tutorial guy can't speak english
    {
        if (dirX > 0f)
        {
            anim.SetBool("attacking", false);
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("attacking", false);
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }

        if (rb.velocity.y > 0.1f)
        {
            anim.SetBool("attacking", false);
            anim.SetBool("jumping", true);
        }
        else if (IsGrounded())
        {
            anim.SetBool("jumping", false);
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }

    public void ResetAttackAnimationState()
    {
        anim.SetBool("attacking", false);
    }

    public void OutOfBounds()
    {
        ui.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coinManager.coinCount++;
        }
    }
}
