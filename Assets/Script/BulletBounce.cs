using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBounce : MonoBehaviour
{
    [SerializeField] private Transform firePosition;
    private Rigidbody2D rb;
    Vector3 lastVelocity;
    public int  bounceCount = 5;
    public float bulletSpeed = 2000.0f;
    private bool hit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed,0f);
        bounceCount--;
        if (bounceCount <= 0)
        {
            Destroy(gameObject);
            return;
        }
    }
}
