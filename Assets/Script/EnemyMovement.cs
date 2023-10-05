using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //private Animator animator;

    string currentAni;
    const string IDLE = "Idle";
    const string DIE = "Die";
    [SerializeField] private int health = 1, currentHealth = 1;
    [SerializeField] private GameObject gameobject;
    void Start()
    {
        //animator = GetComponent<Animator>();
        ChangeAnimationState(IDLE);
    }
    public void takeDamage(int damage, Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= damage;
        }
        
        if (health <= 0)
        {
            Destroy(gameobject);
        }
    }
    private void ChangeAnimationState(string newAni)
    {
        if (newAni == currentAni)
        {
            return;
        }
        //animator.Play(newAni);
        currentAni = newAni;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            StartCoroutine(Dead());
        }
    }
    IEnumerator Dead()
    {
        ChangeAnimationState(DIE);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
