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

    // Start is called before the first frame update
    void Start()
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
            case "Paddle":
            case "Brick":
                float maxDist = other.transform.localScale.x * 1f * 0.5f + transform.localScale.x * 1f * 0.5f;
                float dist = transform.position.x - other.transform.position.x;
                float nDist = dist / maxDist;

                velocity = new Vector3(nDist * maxX, 0, -velocity.z);
                break;
            case "Wall":
                velocity = new Vector3(-velocity.x, velocity.y, velocity.z);

                break;
            case "TopWall":
                velocity = new Vector3(velocity.x, velocity.y, -velocity.z);

                break;
            case "BottomWall":
                ResetBall();

                break;
            default:
                Debug.LogWarning("Unknown Collider tag" +other.tag.ToString());
                
                break;
        }
        /*if (other.CompareTag("Paddle") || other.CompareTag("Brick"))
        {
            float maxDist = other.transform.localScale.x * 1f * 0.5f + transform.localScale.x * 1f * 0.5f;
            float dist = transform.position.x - other.transform.position.x;
            float nDist = dist / maxDist;

            velocity = new Vector3(nDist * maxX, 0, -velocity.z);
        }
        else if (other.CompareTag("Wall"))
        {
            velocity = new Vector3(-velocity.x, velocity.y, velocity.z);
        }
        else if (other.CompareTag("TopWall"))
        {
            velocity = new Vector3(velocity.x, velocity.y, -velocity.z);
        }
        else if (other.CompareTag("BottomWall"))
        {
            ResetBall();
        }*/
    }
}