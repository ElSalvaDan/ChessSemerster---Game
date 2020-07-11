using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    ClubStatPopUpScript clubStatPopUp;

    private void Start()
    {
        clubStatPopUp = GameObject.Find("Main Camera").GetComponentInChildren<Canvas>().GetComponentInChildren<ClubStatPopUpScript>();
    }

    private void Update()
    {
        OnMouseDown();
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(1) && clubStatPopUp.popUpBox.activeInHierarchy == true)
        {
            Debug.Log("Closing It Up Master");
            StartCoroutine(clubStatPopUp.popOut());
        }
    }
}
