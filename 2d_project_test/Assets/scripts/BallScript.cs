using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float ballSpeed;
    public bool inPlay;
    public Transform platform;
    public Transform sparks;
    public GameManeger gm;
    public Transform powerUp;
    AudioSource audio;
    

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(Vector2.up * ballSpeed);
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        if (inPlay == false)
        {
            transform.position = platform.position;
        }
        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rigidBody.AddForce(Vector2.up * ballSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("GameOver"))
        {
            
            rigidBody.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);
            
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Bricks"))
        {
            BcricksScript bricksScript = other.gameObject.GetComponent<BcricksScript>();
            if (bricksScript.doubleHits > 1)
            {
                bricksScript.BreakBrick();
            }
            else
            {
                int random = Random.Range(1, 101);
                if (random < 18)
                {
                    Instantiate(powerUp, other.transform.position, other.transform.rotation);
                }
                Transform newSparks = Instantiate(sparks, other.transform.position, other.transform.rotation);
                Destroy(newSparks.gameObject, 2.5f);
                gm.UpdateScore(bricksScript.points);
                gm.UpdateBricks();
                Destroy(other.gameObject);
                audio.Play();
            }
            audio.Play();
            
        }
    }
}
