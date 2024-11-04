using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienMovement : MonoBehaviour
{
    public float speed = 2f;               
    public Transform leftBoundary;         
    public Transform rightBoundary;        
 
    //speeds up alien over time
    public float acceleration = 0.5f;

    // random swap from left top right = surprise attacks
    public float changeOfDirection = 0.20f;  


    // yt tutorial used this method of true or false direction to help with animation
    // and facing sprite the right way
    private bool movingRight = true;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetBool("isRunning", true);
    }

    void Update()
    {

        if (Random.value < changeOfDirection)
        {
            movingRight = !movingRight;
            FlipSprite();
        }
    
        speed = speed + acceleration * Time.deltaTime;
        // turns alien away from right edge with boundary object
        if (movingRight && transform.position.x >= rightBoundary.position.x)
        {
            movingRight = false;
            FlipSprite();
        }
        // turns alien away from left edge with boundary object
        else if (!movingRight && transform.position.x <= leftBoundary.position.x)
        {
            movingRight = true;
            FlipSprite();
        }

        // Move the alien based on direction
        float moveDirection = movingRight ? 1 : -1; //no idea what the ? does
        transform.Translate(Vector2.right * moveDirection * speed * Time.deltaTime);

        animator.SetFloat("moveDirection", moveDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the alien hits player (this sollision will be the end of game)
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }

    }
// flips sprite (also a yt tutorial)
    void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x = movingRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
}
