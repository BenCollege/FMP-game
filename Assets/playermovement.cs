using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private Rigidbody2D rb2;
    private Animator anim;

    private float dirX = 0f;

    [SerializeField] private float playerMoveSpeed = 5f;
    [SerializeField] private float playerJumpHeight = 18f;

    // Start is called before the first frame update
    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb2.velocity = new Vector2(dirX * playerMoveSpeed, rb2.velocity.y);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb2.velocity.y) < 0.001f)
        {
            rb2.AddForce(new Vector2(0, playerJumpHeight), ForceMode2D.Impulse);
        }

        if (dirX > 0f)
        {
            anim.SetBool("running", true);
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}
