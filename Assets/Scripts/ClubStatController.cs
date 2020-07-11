using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubStatController : MonoBehaviour
{
    ClubStatPopUpScript clubStatPopUp;

    private void Start()
    {
        clubStatPopUp = GameObject.Find("Main Camera").GetComponentInChildren<Canvas>().GetComponentInChildren<ClubStatPopUpScript>();
    }

    public void openStatPopUp()
    {
        Debug.Log("Opening It Up Master");
        clubStatPopUp.popIn();
    }
}
