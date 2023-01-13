using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    public Rigidbody rb;

    public float speed = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(Random.Range(0, 2) * 2f - 1f * Random.Range(0.2f, 1f), 0,
            Random.Range(0, 2) * 2f - 1f);
        rb.velocity = rb.velocity.normalized*speed;
    }

    public void IncreaseSpeed()
    {
        rb.velocity = rb.velocity.normalized*speed;
    }
}
