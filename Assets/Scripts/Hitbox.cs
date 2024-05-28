using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private float knockbackSpeed = 0.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            // Debug.Log("Attack hitbox collision");
            
            float dirX = transform.localScale.x;

            // Apply knockback force to the other object
            Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();
            if (otherRb != null)
            {
                otherRb.velocity = new Vector3(dirX * knockbackSpeed, 0.5f, 0.0f);
            }
            
            // other.gameObject.SetActive(false);
        }
    }
}
