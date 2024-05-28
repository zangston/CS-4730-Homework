using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D hitbox;
    // private SpriteRenderer spriteRenderer;

    private float dirX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hitbox = transform.Find("AttackHitbox").GetComponent<BoxCollider2D>();
        // spriteRenderer = transform.Find("AttackHitbox").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        if (dirX < 0f)
        {
            transform.Find("AttackHitbox").transform.localScale = new Vector3(dirX, 1, 1);
        }

        if (dirX > 0f)
        {
            transform.Find("AttackHitbox").transform.localScale = new Vector3(dirX, 1, 1);
        }

        if (animator.GetBool("attacking"))
        {
            ActivateHitbox();
        }
        else
        {
            DeactivateHitbox();
        }
    }

    void ActivateHitbox()
    {
        hitbox.gameObject.SetActive(true);
        // spriteRenderer.gameObject.SetActive(true);
    }

    void DeactivateHitbox()
    {
        hitbox.gameObject.SetActive(false);
        // spriteRenderer.gameObject.SetActive(false);
    }
}
