using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleProjectileController : MonoBehaviour
{
    public float speed;
    public float damage;
    public Rigidbody2D body;
    public Transform target;
    private Vector3 targetDirection;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        targetDirection = (target.position-transform.position).normalized;
    }

    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, 360f * Time.fixedDeltaTime);
        transform.position += targetDirection * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<IDamageResponder>() != null)
        {
            collision.collider.GetComponent<IDamageResponder>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
