using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed;
    public Transform playArea;
    private float maxX;

    // Start is called before the first frame update
    void Start()
    {
        this.UpdateSizes();
    }

    public void UpdateSizes()
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

    public void SetLarger(int seconds)
    {
        Vector3 localScale = transform.localScale;
        float maxScaleX = playArea.localScale.x * 10;
        float newLocalScaleX = ((localScale.x * 1.2f) < maxScaleX)
            ? localScale.x * 1.2f
            : maxScaleX;
        transform.localScale = new Vector3(newLocalScaleX, localScale.y, localScale.z);
        this.UpdateSizes();
        Invoke(nameof(SetSmaller),seconds);
    }
    
    public void SetSmaller(int seconds)
    {
        Vector3 localScale = transform.localScale;
        float minScaleX = 1;
        float newLocalScaleX = ((localScale.x * 0.8f) > minScaleX)
            ? localScale.x * 0.8f
            : minScaleX;
        transform.localScale = new Vector3(newLocalScaleX, localScale.y, localScale.z);
        this.UpdateSizes();
        Invoke(nameof(SetLarger),seconds);
    }

    private void SetSmaller()
    {
        Vector3 localScale = transform.localScale;
        transform.localScale = new Vector3(localScale.x / 1.2f, localScale.y, localScale.z);
        this.UpdateSizes();

    } private void SetLarger()
    {
        Vector3 localScale = transform.localScale;
        transform.localScale = new Vector3(localScale.x /0.8f, localScale.y, localScale.z);
        this.UpdateSizes();

    }
}