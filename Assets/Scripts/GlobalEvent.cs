using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEvent : MonoBehaviour
{
    public GameObject madCat;
    public GameObject madCathpBar;

    public GameObject coots;
    public GameObject cootshpBar;

    public GameObject cam;

    public GameObject boulderPrefab;
    public Vector2[] boulderStartingPos;
    public Vector2[] boulderFinalPos;
    public float numOfBoulders;

    // Start is called before the first frame update
    void Start()
    {
        numOfBoulders = boulderFinalPos.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DropBoulders()
    {
        for (int i = 0; i < boulderFinalPos.Length; i++)
        {
            GameObject boulder = Instantiate(boulderPrefab, boulderStartingPos[i], Quaternion.identity);
            boulder.GetComponent<BoulderController>().SetTarget(boulderFinalPos[i]);
        }
    }


    public void MadCatTransition()
    {
        coots.SetActive(false);
        cootshpBar.SetActive(false);
        madCat.SetActive(true);
        madCathpBar.SetActive(true);
    }

    public void TurnOnCootsCam()
    {
        cam.SetActive(true);
    }

    public void TurnOffCootsCam()
    {
        cam.SetActive(false);
    }
}
