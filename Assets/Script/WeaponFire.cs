using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{

    [SerializeField] private Transform firePosition;
    [SerializeField] private GameObject bullet;
    //[SerializeField] private Animator anim;

    public float bulletSpeed = 2000.0f;
    public short bulletCount = 6;
    private Vector2 bulletDirection;
       

    private void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && bulletCount>0)
        {
            GameObject inst = Instantiate(bullet, firePosition.position, Quaternion.identity);

            // Detach the bullet from the shooting point's transform hierarchy
            inst.transform.parent = null;

            // Calculate the bullet direction
            bulletDirection = firePosition.position - transform.position;

            // Apply force to the bullet in the calculated direction
            Rigidbody2D bulletRigidbody = inst.GetComponent<Rigidbody2D>();
            bulletRigidbody.AddForce(bulletDirection.normalized * bulletSpeed);
            //anim.SetTrigger("shoot");

            bulletCount--;
        }
    }
}
