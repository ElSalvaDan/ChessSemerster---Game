using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopPopUpScript : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator popUpAnimator;
    public TMP_Text popUpMessage;

    private Canvas background;
    public bool buyAttempt;

    private void Start()
    {
        background = GameObject.Find("DarkenBackground").GetComponent<Canvas>();
    }

    public void popUp(string text)
    {
        background.enabled = true;
        popUpBox.SetActive(true);
        popUpMessage.text = text;
        popUpAnimator.SetTrigger("PopIn");
    }

    IEnumerator popOut()
    {
        popUpAnimator.SetTrigger("PopOut");

        yield return new WaitForSeconds(1);

        background.enabled = false;
        popUpBox.SetActive(false);
    }

    public void okayButtonPressed()
    {
        StartCoroutine(popOut());
        buyAttempt = true;
    }

    public void noButtonPressed()
    {
        StartCoroutine(popOut());
        buyAttempt = false;
    }
}
