using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour
{
    public PlayerData playerData;

    public ResourceBar manaBar;
    public float currentMana;

    public bool isDashOffCd;

    // Start is called before the first frame update
    void Start()
    {
        isDashOffCd = true;
        currentMana = playerData.maxMana;
        manaBar.SetMaxValue(playerData.maxMana);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        RefillManaBar();
    }

    public void SpendMana(float cost)
    {
        currentMana -= cost;

    }

    private void RefillManaBar()
    {
        if (currentMana < playerData.maxMana)
        {
            currentMana += playerData.manaRegenRate * Time.fixedDeltaTime;

            if (currentMana > playerData.maxMana)
            {
                currentMana = playerData.maxMana;
            }
        }

        manaBar.SetValue(currentMana);
    }

    public IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(playerData.dashCooldown);
        isDashOffCd = true;
    }
}
