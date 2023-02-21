using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{

    public LayerMask mask;
    public Vector2 hitBoxSize = new Vector2(1, 1);
    public Color color;
    private HashSet<Collider2D> hitColliders = new HashSet<Collider2D>();

    public bool isActive = false;


    public void HitboxUpdate(float damage)
    {

        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, hitBoxSize, 0, mask);

        if (colliders != null)
        {
            foreach (var collider in colliders)
            {
                if (hitColliders.Contains(collider))
                {
                    continue;
                }
                collider.GetComponent<IDamageResponder>().TakeDamage(damage);
                hitColliders.Add(collider);

            }
        }
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = PickGizmosColor();

        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);

        Gizmos.DrawCube(Vector2.zero, new Vector2(hitBoxSize.x, hitBoxSize.y));

    }

    public void ClearHitColliders()
    {
        hitColliders.Clear();
    }

    private Color PickGizmosColor()
    {
        if (isActive)
        {
            return color;
        }
        else
        {
            return Color.clear;
        }
    }

}
