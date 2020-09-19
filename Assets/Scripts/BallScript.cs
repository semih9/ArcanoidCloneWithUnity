using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float ballSpeed;
    public Transform explosion;
    public Transform powerup;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }

        if (!inPlay)
        {
            transform.position = paddle.position;
        }

        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * ballSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bottom"))
        {
            Debug.Log("Ball hit the bottom of the screen!");
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Brick"))
        {
            BrickScript brickScript = collision.gameObject.GetComponent<BrickScript>();

            if(brickScript.hitsToBreak > 1)
            {
                brickScript.BreakBrick();
            }
            else
            {
                int randChance = Random.Range(1, 100);

                if (randChance < 50)
                {
                    Instantiate(powerup, collision.transform.position, collision.transform.rotation);
                }


                Transform newExplosion = Instantiate(explosion, collision.transform.position, collision.transform.rotation); //Create an explosion

                Destroy(newExplosion.gameObject, 2.5f); //Destroy the explosion effect

                gm.UpdateScore(brickScript.points);

                gm.UpdateNumberOfBricks();

                Destroy(collision.gameObject); // Destroy the brick
            }

        }
    }
}
