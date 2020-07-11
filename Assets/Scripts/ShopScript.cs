using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    private ShopPopUpScript popUpControls;

    private void Start()
    {
        popUpControls = GameObject.Find("PopUp").GetComponent<ShopPopUpScript>();
    }

    public void purchaseItem()
    {
        popUpControls.popUp("Are you sure you want to buy this item?");
        Debug.Log(popUpControls.buyAttempt);
    }

    public void purchaseSpecialItem()
    {
        Debug.Log("lol u don't have enough money");
    }

    public void hireStaff()
    {
        Debug.Log("dis is hunman");
    }

    public void backToClub()
    {
        Debug.Log("okey dokay");
    }
}
