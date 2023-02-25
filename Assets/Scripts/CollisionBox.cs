using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBox : MonoBehaviour, IDamageResponder
{
    public Animator animator;
    public Collider2D _collider;
    public GlobalEvent global;

    private void Start()
    {
        global = GameObject.Find("Global Event").GetComponent<GlobalEvent>();
    }

    public void TakeDamage(float damage)
    {
        global.numOfBoulders -= 1;
        _collider.enabled = false;
        animator.Play("BoulderCrack");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
