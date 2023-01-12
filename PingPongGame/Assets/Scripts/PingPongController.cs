using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PingPongController : MonoBehaviour
{
    public Transform topPong;
    public Transform bottomPong;
    private float _maxDistance;
    public Transform ball;
    // Tracking accuracy regulates AI's tracking accuracy. Lower accuracy makes more humanoid.
    [Range(0,0.25f)] public float trackingAccuracy;

    private void Start()
    {
        // Distance between top and bottom borders.
        _maxDistance = Mathf.Abs(topPong.position.z - bottomPong.position.z);
    }

    private void Update()
    {
        // Clamps absolute distance value between 0 and 1 by dividing to maximum distance value.
        // Returns distance value of from ball to target border.
        float distance = Math.Abs(ball.position.z - transform.position.z)/_maxDistance;
        
        // Set new position's x to ball position's x according to the distance between them and tracking accuracy.
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Lerp(transform.position.x, ball.position.x,trackingAccuracy*Mathf.Abs(1-distance));
        transform.position = newPosition;
    }
}
