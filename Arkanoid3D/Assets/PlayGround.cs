using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class PlayGround : MonoBehaviour
{
    [SerializeField]
    public GameObject[] powerups;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetRandomPowerUp()
    {
        return powerups[Random.Range(0,powerups.Length)];
    }
    
}
