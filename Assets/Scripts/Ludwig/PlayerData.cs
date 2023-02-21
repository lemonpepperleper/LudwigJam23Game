
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player")]
public class PlayerData : ScriptableObject
{
    public float moveSpeed;

    public float atkDmg;

    public float maxMana;
    public float manaRegenRate;

    public float dashSpeed;
    public float dashManaCost;
    public float dashTime;
    public float dashCooldown;
}
