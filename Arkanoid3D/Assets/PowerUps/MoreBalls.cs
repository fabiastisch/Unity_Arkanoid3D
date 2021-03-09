using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class MoreBalls : PowerUp
{
    protected override void OnPaddleHit(Collider collider)
    {
        GameObject ball = Instantiate(GameObject.FindWithTag("Ball").gameObject, collider.transform.position, Quaternion.identity);
        Material material = ball.GetComponent<Renderer>().material;
        ball.GetComponent<Ball>().isFake = true;
        material.color = Color.cyan;
        Destroy(gameObject);
    }

    protected override void OnBottomWallHit(Collider collider)
    {
        Destroy(gameObject);
    }
}