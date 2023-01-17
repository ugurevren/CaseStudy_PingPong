using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    public static BallController instance;
    public Rigidbody rb;
    private Vector3 _lastVelocity;
    public float speed = 0.1f;
    private float _defaultSpeed;
    [Range(0,0.3f)] public float increaseSpeedRate;
    
    private void Awake()
    {
        
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this);
        // Save speed of ball to reset speed later.
        _defaultSpeed = speed;
        
       InitialThrow();
    }

    public void InitialThrow()
    {
        //Initial throwing
        rb.velocity = new Vector3(Random.Range(0, 2) * 2f - 1f * Random.Range(0.2f, 1f), 0,
            Random.Range(0, 2) * 2f - 1f);
    }
 
    private void FixedUpdate()
    {
        //Save last Velocity
        _lastVelocity = rb.velocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Secure velocity of ball on collision
        var _tempSpeed = _lastVelocity.magnitude;
        var direction = Vector3.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(_tempSpeed, 0f);
    }

    public void ResetBall()
    {
        // Reset Speed
        speed = _defaultSpeed;
        rb.velocity = rb.velocity.normalized*speed;
        
        // Call InitialThrow() to change direction of ball
        InitialThrow();
    }

    public void IncreaseSpeed()
    {
        //Increase speed by rate
        speed += increaseSpeedRate;
        rb.velocity = rb.velocity.normalized*speed;
    }
}
