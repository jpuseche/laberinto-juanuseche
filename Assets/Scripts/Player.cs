using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 2f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        if ((int)transform.position.x == PlayerPrefs.GetInt("size")-1 && (int)transform.position.y == PlayerPrefs.GetInt("size")-1)
        {
            if (PlayerPrefs.GetInt("level") == 4)
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
                SceneManager.LoadScene("MainScene");
            }
        }   
    }

    private void Move()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);
        if (Mathf.Abs(rb.velocity.x) > 0 || Mathf.Abs(rb.velocity.y) > 0)
        {
            animator.SetBool("Moving", true);
            animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
            if (rb.velocity.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            animator.SetBool("Moving", false);
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
