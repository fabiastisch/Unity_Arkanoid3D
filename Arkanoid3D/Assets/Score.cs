using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text textComponent;
    private string text;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        textComponent = this.gameObject.GetComponent<Text>();
        text = textComponent.text;
        this.ApplyChanges();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void addScore(int score = 1)
    {
        this.score += score;
        this.ApplyChanges();
    }

    private void ApplyChanges()
    {
        textComponent.text = text + score;
    }
}
