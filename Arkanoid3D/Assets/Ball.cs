using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 velocity;
    public float maxX;
    public float maxZ;
    private Vector3 startPosition;
    public static int count = 0;
    private CountDownTimer countDownComponent;

    private void Awake()
    {
        count++;
        countDownComponent = GameObject.FindWithTag("CountDown").GetComponent<CountDownTimer>();
    }

    private void OnDestroy()
    {
        count--;
        countDownComponent.CountDownFinished -= this.CountDownFinished;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        if (count == 1)
        {
            countDownComponent.CountDownFinished += this.CountDownFinished;
        }
        else
        {
            velocity = new Vector3(0, 0, maxZ);
            startPosition = transform.position;
        }
    }

    private void CountDownFinished()
    {
        velocity = new Vector3(0, 0, -maxZ);
        startPosition = transform.position;
    }

    //TODO: fix bugs
    void ResetBall()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Wall":
                velocity = new Vector3(-velocity.x, velocity.y, velocity.z);

                break;
            case "TopWall":
                velocity = new Vector3(velocity.x, velocity.y, -velocity.z);

                break;
            case "BottomWall":
                if (GameObject.FindGameObjectsWithTag("Ball").Length == 1)
                {
                    Life lifeComponent = GameObject.FindWithTag("Lives").GetComponent<Life>();
                    lifeComponent.removeOneLife();
                    Debug.Log("GameOver");
                    if (lifeComponent.life > 0)
                    {
                        GameObject.FindWithTag("CountDown").GetComponent<CountDownTimer>().ResetCountdown();
                        this.NextLife();
                    }
                    else
                    {
                       Destroy(gameObject);
                    }

                    // TODO: Add End Screen
                }
                else
                {
                    Destroy(gameObject);
                }
                // ResetBall();

                break;
            case "Paddle":
                float maxDist = other.transform.localScale.x * 1f * 0.5f + transform.localScale.x * 1f * 0.5f;
                float dist = transform.position.x - other.transform.position.x;
                float nDist = dist / maxDist;

                velocity = new Vector3(nDist * maxX, 0, -velocity.z);
                break;
            case "Brick":
                //  Debug.Log(other.ClosestPoint(transform.position) - transform.position);
                
                float distX = Mathf.Abs(transform.position.x - other.transform.position.x);
                float distZ = Mathf.Abs(transform.position.z - other.transform.position.z);
                
                if (distX >= other.transform.localScale.x / 2)
                {
                    if (distZ <= other.transform.localScale.z / 2)
                    {
                        velocity = new Vector3(-velocity.x, velocity.y, velocity.z);
                    }
                    else if (distX - other.transform.localScale.x / 2 < distZ - other.transform.localScale.z /2)
                    {
                        velocity = new Vector3(velocity.x, velocity.y, -velocity.z);
                    }
                    else
                    {
                        velocity = new Vector3(-velocity.x, velocity.y, velocity.z);
                    }
                }
                else
                {
                    velocity = new Vector3(velocity.x, velocity.y, -velocity.z);
                }
                break;
        }

        if (!other.tag.Equals("Background") && !other.tag.Equals("BottomWall"))
        {
            GetComponent<AudioSource>().Play();
        }
    }

    private void NextLife()
    {
        countDownComponent.CountDownFinished += this.CountDownFinished;
        transform.position = new Vector3(0, 0.5f, -7f);
        velocity = Vector3.zero;
    }
}