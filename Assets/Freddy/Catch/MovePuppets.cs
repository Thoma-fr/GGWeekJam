using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePuppets : MonoBehaviour
{
    public Transform start;
    public Transform end;

    public float period = 4f;

    public bool isMoving = true;

    public AnimationCurve animCurve;

    private void Update()
    {
        if(isMoving)
            Move();
    }

    private void Move()
    {
        float t = Mathf.PingPong(Time.time / period, 1.0f);
        float animatedT = animCurve.Evaluate(t);
        transform.position = Vector2.Lerp(start.position, end.position, animatedT);
    }
}
