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

    // Update is called once per frame
    void Update()
    {
        
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
}
