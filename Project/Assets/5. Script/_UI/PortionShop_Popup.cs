using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortionShop_Popup : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    [SerializeField] GameObject RealBuy_Popup;
    [SerializeField] Text ItemName_txt;
    [SerializeField] Text ItemPrice;

    [SerializeField] GameObject No_Money_Popup;
    [SerializeField] GameObject Succes_Buy_Popup;
}
