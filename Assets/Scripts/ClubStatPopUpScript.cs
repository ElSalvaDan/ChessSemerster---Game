using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClubStatPopUpScript : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator popUpAnimator;

    public void popIn()
    {
        popUpBox.SetActive(true);
        popUpAnimator.SetTrigger("ClubStatPopIn");
    }

    public IEnumerator popOut()
    {
        popUpAnimator.SetTrigger("ClubStatPopOut");

        yield return new WaitForSeconds(1);

        popUpBox.SetActive(false);
    }
}