using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator animator;

    string currentAni;
    const string IDLE = "EnemyIdle";
    const string DIE = "SkeletonDead";
    [SerializeField] private int health = 1, currentHealth = 1;
    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeAnimationState(IDLE);
    }
    //public void takeDamage(int damage, Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Bullet")
    //    {
    //        health -= damage;
    //    }
        
    //    if (health <= 0)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
    private void ChangeAnimationState(string newAni)
    {
        if (newAni == currentAni)
        {
            return;
        }
        animator.Play(newAni);
        currentAni = newAni;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            StartCoroutine(Dead());
        }
    }
    IEnumerator Dead()
    {
        ChangeAnimationState(DIE);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
