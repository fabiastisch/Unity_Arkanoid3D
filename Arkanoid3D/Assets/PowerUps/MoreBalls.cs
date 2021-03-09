using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class MoreBalls : MonoBehaviour
{
    private Vector3 velocity;
    public float maxZ;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0,-maxZ);
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
                Instantiate(GameObject.FindWithTag("Ball").gameObject, other.transform.position, Quaternion.identity);
                break;
            case "BottomWall":
                Destroy(gameObject);
                break;
        }
    }
}
