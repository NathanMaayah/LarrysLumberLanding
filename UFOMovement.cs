using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UFOMovement : MonoBehaviour
{
    public float speed = 2f;               
    public Transform leftBoundary;         
    public Transform rightBoundary;        
 
    //speeds up ufo over time
    // made game too dofficult so left it only for the alien
    public float acceleration = 0.5f;

    // swaps direction left or right randomlu
    // made game too difficult so i took this off the ufos and instead had 2 go at different speeds
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
            FlipSprite(); // flips the sprite to look right direction
        }
    
        speed = speed + acceleration * Time.deltaTime;
        // turns away from right so it stays on screen
        if (movingRight && transform.position.x >= rightBoundary.position.x)
        {
            movingRight = false;
            FlipSprite();
        }
        // turns away from left so it stays on screen
        else if (!movingRight && transform.position.x <= leftBoundary.position.x)
        {
            movingRight = true;
            FlipSprite();
        }

        // Move the ufo based on direction
        float moveDirection = movingRight ? 1 : -1; //no idea what the ? does
        transform.Translate(Vector2.right * moveDirection * speed * Time.deltaTime);

        animator.SetFloat("moveDirection", moveDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the ufo hits player (this sollision will be the end of game)
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver"); // send you to game over scene
        }

    }

    void FlipSprite() // flips the sprite (also yt)
    {
        Vector3 scale = transform.localScale;
        scale.x = movingRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
}
