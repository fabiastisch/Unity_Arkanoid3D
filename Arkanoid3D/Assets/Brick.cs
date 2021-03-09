using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Brick : MonoBehaviour
{
    public int brickValue;

    // Start is called before the first frame update
    void Start()
    {
        Material material = GetComponent<Renderer>().material;
        material.color = getColor(brickValue);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        brickValue--;
        Material material = GetComponent<Renderer>().material;

        if (brickValue == 0)
        {
            int random = Random.Range(0, 3);
            if (random == 1)
            {
             
               GameObject obj = GameObject.FindWithTag("GameController").GetComponent<PlayGround>().GetRandomPowerUp();
               Instantiate(obj, transform.position, Quaternion.identity);   
            }
            Destroy(gameObject);
        }

        material.color = getColor(brickValue);
    }

    private Color getColor(int brickValue)
    {
        switch (brickValue % 8)
        {
            case 1:
                return Color.white;
            case 2:
                return Color.blue;
            case 3:
                return Color.cyan;
            case 4:
                return Color.gray;
            case 5:
                return Color.green;
            case 6:
                return Color.magenta;
            case 7:
                return Color.red;
            case 8:
                return Color.yellow;
            default:
                return Color.black;
        }
    }
}