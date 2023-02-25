using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderController : MonoBehaviour
{
    public Rigidbody2D body;
    public float fallingSpeed;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = Vector2.MoveTowards(body.position, target, fallingSpeed * Time.fixedDeltaTime);
        body.MovePosition(newPos);
    }

    public void SetTarget(Vector2 endPos)
    {
        target = endPos;
    }
}
