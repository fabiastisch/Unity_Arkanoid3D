using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    
    public float speed;
    public Transform playArea;
    private float maxX;

    // Start is called before the first frame update
    void Start()
    {
        float playAreaSize = playArea.localScale.x * 10;
        float paddleSize = transform.localScale.x * 1;

        maxX = 0.5f * playAreaSize - 0.5f * paddleSize;
    }

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxis("Horizontal");
        float newX = transform.position.x + Time.deltaTime * speed * dir;

     
        float clampedX = Mathf.Clamp(newX, -maxX, maxX);

        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
