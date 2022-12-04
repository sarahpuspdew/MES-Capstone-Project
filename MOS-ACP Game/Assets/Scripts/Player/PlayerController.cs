using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float gravityModifier;

    Rigidbody playerRb;
    Animator playerAnim;
    bool facingRight;
    bool grounded = false;
    bool isOnGround = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        facingRight = true;    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            playerAnim.SetTrigger("jump");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (isOnGround) {
            playerAnim.SetBool("isGrounded", true);
        }
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        playerAnim.SetFloat("speed", Mathf.Abs(move));
        playerRb.velocity = new Vector3(0, playerRb.velocity.y, move * speed);

        if (move > 0 && !facingRight) {
            Flip();
        }
        else if (move < 0 && facingRight) {
            Flip();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        }
        if (other.gameObject.CompareTag("Pushable")) {
            Push();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Pushable")) {
            playerAnim.SetTrigger("exitPush");
        }
    }

    void Push()
    {
        playerAnim.SetTrigger("push");
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }
}