using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Larger : PowerUp
{
    protected override void OnPaddleHit(Collider collider)
    {
        collider.gameObject.GetComponent<Paddle>().SetLarger(10);
        Destroy(gameObject);

    }

    protected override void OnBottomWallHit(Collider collider)
    {
        Destroy(gameObject);
    }
}
