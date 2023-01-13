using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    
    public Rigidbody rb;
    private Vector3 _lastVelocity;
    public float speed = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(Random.Range(0, 2) * 2f - 1f * Random.Range(0.2f, 1f), 0,
            Random.Range(0, 2) * 2f - 1f);
        rb.velocity = rb.velocity.normalized*speed;
    }

    private void FixedUpdate()
    {
        IncreaseSpeed();
        _lastVelocity = rb.velocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        var _tempSpeed = _lastVelocity.magnitude;
        var direction = Vector3.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(_tempSpeed, 0f);
    }

    public void IncreaseSpeed()
    {
        rb.velocity = rb.velocity.normalized*speed;
    }
}
