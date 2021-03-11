using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void Notify();
public class CountDownTimer : MonoBehaviour
{
    private float currentTime = 0f;
    private float startingTime = 5f;
    private bool isActive = true;
    public event Notify CountDownFinished;

    [SerializeField] public Text countDownText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            currentTime -= 1 * Time.deltaTime;

            if (currentTime <= 0)
            {
                countDownText.text = "";
                isActive = false;
                CountDownFinished?.Invoke();
            }
            else
            {
                countDownText.text = currentTime.ToString("0");
            }
        }
    }

    public void ResetCountdown()
    {
        currentTime = startingTime;
        this.isActive = true;
    }
    
    
}
