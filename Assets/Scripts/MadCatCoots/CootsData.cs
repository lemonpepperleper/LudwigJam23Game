using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Coots", menuName = "ScriptableObjects/Coots")]
public class CootsData : ScriptableObject
{

    [Header("Run settings")]
    public float moveSpeed = 3f;
    public float runRange = 2f;
    public float sprintSpeed = 10f;

    [Header("Swipe settings")]
    public float swipeTriggerRange = 1.5f;
    public float swipeCoolDown = 4f;
    public float swipeDmg = 20f;

    [Header("Punch settings")]
    public float punchTriggerRange = 9f;
    public float punchCoolDown = 10f;
    public float punchDmg = 40f;
    public float punchDashSpeed = 1.5f;

    [Header("Roar settings")]
    public float roarTriggerRange = 2.5f;
    public float roarDuration = 2f;
    public float roarTickRate = 0.5f;
    public float roarCoolDown = 10f;
    public float roarDmg = 15f;

    [Header("Tornado settings")]
    public float tornadoCoolDown = 15f;
    public float tornadoDuration = 5f;
    public float tornadoTickRate = 0.5f;
    public float tornadoDmg = 10f;
    public float tornadoSpeed = 5f;

    [Header("Stomp settings")]
    public float stompCoolDown = 15f;
    public float numOfRocks = 5f;
    public float rockDmg = 10f;

    [Header("Crash settings")]
    public float hpThreshold = 50f;
}
