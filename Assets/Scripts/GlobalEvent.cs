using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEvent : MonoBehaviour
{
    public GameObject madCat;
    public GameObject madCathpBar;

    public GameObject coots;
    public GameObject cootshpBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            MadCatTransition();
        } 
    }

    public void MadCatTransition()
    {
        coots.SetActive(false);
        cootshpBar.SetActive(false);
        madCat.SetActive(true);
        madCathpBar.SetActive(true);
    }

}
