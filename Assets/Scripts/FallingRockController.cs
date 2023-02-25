using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRockController : MonoBehaviour
{

    public HitBox hitBox;
    public Rigidbody2D body;
    public Animator animator;

    private Vector2 target;

    public float damage;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        hitBox.isActive = false;
    }

    private void FixedUpdate()
    {
        body.position = Vector2.MoveTowards(body.position, target, speed * Time.fixedDeltaTime);

        if (hitBox.isActive)
        {
            hitBox.HitboxUpdate(damage);
        }
    }

    private void Update()
    {
        if (body.position == target)
        {
            animator.Play("RockBreak");
        }

        if (body.position.y - target.y <= 2.6f)
        {
            hitBox.isActive = true;
        }
    }

    public void SetTarget(Vector2 endPt)
    {
        this.target = endPt;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
