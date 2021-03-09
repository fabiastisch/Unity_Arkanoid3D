using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    private Vector3 velocity;
    public float maxZ;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, -maxZ);
  
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
                OnPaddleHit(other);
                break;
            case "BottomWall":
                OnBottomWallHit(other);
                break;
        }
    }

    protected abstract void OnPaddleHit(Collider collider);
    protected abstract void OnBottomWallHit(Collider collider);
    
}
