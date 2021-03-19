using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Larger : PowerUp
{
    protected override void OnPaddleHit(Collider collider)
    {
        GameObject.FindWithTag("GameController").GetComponent<CustomAudioManager>().Play(GetComponent<AudioSource>().clip);
        collider.gameObject.GetComponent<Paddle>().SetLarger(10);
        Destroy(gameObject);

    }

    protected override void OnBottomWallHit(Collider collider)
    {
        Destroy(gameObject);
    }
}
