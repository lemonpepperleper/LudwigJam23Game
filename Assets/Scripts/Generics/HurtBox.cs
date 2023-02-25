using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour, IDamageResponder
{

    public BoxCollider2D _collider;
    public ResourceBar HpBar;
    public Color color;

    public float maxHP;
    public float currentHP;

    // Start is called before the first frame update
    void Start()
    {
        HpBar.SetMaxValue(maxHP);
        currentHP = maxHP;
    }

    private void FixedUpdate()
    {
        HpBar.SetValue(currentHP);
    }

    public void TakeDamage(float damage)
    {
        currentHP = currentHP - damage >= 0 ? currentHP - damage : 0;
        HpBar.SetValue(currentHP);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = color;

        Gizmos.matrix = Matrix4x4.TRS(_collider.transform.position, _collider.transform.rotation, _collider.transform.localScale);

        Gizmos.DrawCube(_collider.offset, _collider.size);

    }
}
