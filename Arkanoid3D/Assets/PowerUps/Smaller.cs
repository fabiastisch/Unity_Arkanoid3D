using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smaller : PowerUp
{
    protected override void OnPaddleHit(Collider collider)
    {
        collider.gameObject.GetComponent<Paddle>().SetSmaller(10);
        Destroy(gameObject);
    }

    protected override void OnBottomWallHit(Collider collider)
    {
        Destroy(gameObject);
    }
}
