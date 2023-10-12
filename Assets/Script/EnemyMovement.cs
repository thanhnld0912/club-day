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
    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeAnimationState(IDLE);
    }
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
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
