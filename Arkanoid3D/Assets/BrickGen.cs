using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BrickGen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public Transform playArea;
    private int level = 1;

    void Start()
    {
        //GameObject newGameObject = Instantiate(prefab, new Vector3(0,0.5f,0), Quaternion.identity);
        //newGameObject.transform.parent = gameObject.transform;
        prefab.transform.localScale = new Vector3(2f, 1,1);
       LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            level++;
            LoadLevel();
        }
    }

    private void LoadLevel()
    {
        float z = prefab.transform.localScale.z;
        float offset = 2f;
        for (int i = 0; i < 3; i++)
        {
            LoadRow(offset, i*(z+offset) ,prefab, level);
        }
    }
    

    private void LoadRow(float offset, float zCood, GameObject gameObjectPrefab, int brickLive)
    {
        Vector3 localScale = gameObjectPrefab.transform.localScale;
        float playAreaSize = playArea.localScale.x * 10;
       
        float numb = playAreaSize / (localScale.x + offset);
        int numAsInt = (int) numb;
        float numOffset = numb - numAsInt;
        
        for (int i = 0; i < numAsInt; i++)
        {
            float xCoord = -(playAreaSize / 2) + (offset + localScale.x + numOffset) / 2 + i * (localScale.x + offset);
            GameObject newGameObj = Instantiate(gameObjectPrefab, new Vector3(xCoord, 0, zCood), Quaternion.identity);
            newGameObj.GetComponent<Brick>().brickValue = brickLive;
            newGameObj.transform.parent = transform;
        }
    }

    private void LoadCircle(int objNumbers, float radius, GameObject gameObjectPefab)
    {
        for (int i = 0; i < objNumbers; i++)
        {
            float angle = i * Mathf.PI * 2 / objNumbers;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 position = transform.position + new Vector3(x, 0, z);
            float angleInDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, angleInDegrees, 0);
            Instantiate(gameObjectPefab, position, rotation);
        }
    }
}