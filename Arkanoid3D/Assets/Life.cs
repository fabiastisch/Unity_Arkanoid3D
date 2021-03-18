using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    private Text textComponent;
    private string text;
    public GameObject gameOverObj;

    public int life;

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

    private void ApplyChanges()
    {
        textComponent.text = text + life;
    }

    public void removeOneLife()
    {
        if (life > 1)
        {
            this.life--;
        }
        else
        {
            if (life > 0)
            {
                this.life--;
                gameOverObj.SetActive(true);
                Time.timeScale = 0;
            }
        }

        this.ApplyChanges();
    }

    public void addOneLife()
    {
        this.life++;
        this.ApplyChanges();
    }
}