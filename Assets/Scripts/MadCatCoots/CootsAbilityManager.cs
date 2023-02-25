using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CootsAbilityManager : MonoBehaviour
{
    public CootsData coots;

    public bool isLocked;

    public bool isSwipeOffCd;

    public bool isPunchOffCd;

    public bool isRoarOffCd;
    [HideInInspector]
    public bool isRoarDone;
    [HideInInspector]
    public bool isNextRoarTickReady;

    public bool isTornadoOffCd;
    [HideInInspector]
    public bool isTornadoDone;
    [HideInInspector]
    public bool isNextTornadoTickReady;

    public bool isStompOffCd;
    [HideInInspector]
    public bool isStompDone;

    [HideInInspector]
    public bool isleapChargeDone;
    [HideInInspector]
    public bool isDashChargeDone;
    [HideInInspector]
    public bool isStunnedDone;

    public GameObject fallingRockPrefab;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        isSwipeOffCd = true;

        isPunchOffCd = false;
        StartCoroutine(PunchCoolDown());
        isRoarOffCd = false;
        StartCoroutine(RoarCoolDown());
        isTornadoOffCd = false;
        StartCoroutine(TornadoCoolDown());
        isStompOffCd = false;
        StartCoroutine(StompCoolDown());

    }


    public void SpawnFallingRocks()
    {
        Vector2 pos = player.position;
        Vector3 spawnPoint = new Vector3(pos.x, 13f, 0f);
        GameObject obj = Instantiate(fallingRockPrefab, spawnPoint, Quaternion.identity);
        obj.GetComponent<FallingRockController>().SetTarget(pos);
    }

    public IEnumerator AbilityLockCoolDown()
    {
        yield return new WaitForSeconds(coots.abilityLock);
        isLocked = false;
    }

    public IEnumerator SwipeCoolDown()
    {
        yield return new WaitForSeconds(coots.swipeCoolDown);
        isSwipeOffCd = true;
    }

    public IEnumerator PunchCoolDown()
    {
        yield return new WaitForSeconds(coots.punchCoolDown);
        isPunchOffCd = true;
    }

    public IEnumerator RoarCoolDown()
    {
        yield return new WaitForSeconds(coots.roarCoolDown);
        isRoarOffCd = true;
    }

    public IEnumerator RoarNextTick()
    {
        yield return new WaitForSeconds(coots.roarTickRate);
        isNextRoarTickReady = true;
    }

    public IEnumerator RoarDuration()
    {
        yield return new WaitForSeconds(coots.roarDuration);
        isRoarDone = true;
    }

    public IEnumerator TornadoCoolDown()
    {
        yield return new WaitForSeconds(coots.tornadoCoolDown);
        isTornadoOffCd = true;
    }

    public IEnumerator TornadoNextTick()
    {
        yield return new WaitForSeconds(coots.tornadoTickRate);
        isNextTornadoTickReady = true;
    }

    public IEnumerator TornadoDuration()
    {
        yield return new WaitForSeconds(coots.tornadoDuration);
        isTornadoDone = true;
    }

    public IEnumerator StompCoolDown()
    {
        yield return new WaitForSeconds(coots.stompCoolDown);
        isStompOffCd = true;
    }

    public IEnumerator StompDuration()
    {
        yield return new WaitForSeconds(coots.roarDuration);
        isRoarDone = true;
    }

    public IEnumerator LeapChargeDone()
    {
        yield return new WaitForSeconds(coots.leapChargeTime);
        isleapChargeDone = true;
    }

    public IEnumerator DashChargeDone()
    {
        yield return new WaitForSeconds(coots.dashChargeTime);
        isDashChargeDone = true;
    }

    public IEnumerator StunnedDone()
    {
        yield return new WaitForSeconds(coots.stunnedTime);
        isStunnedDone = true;
    }
}
