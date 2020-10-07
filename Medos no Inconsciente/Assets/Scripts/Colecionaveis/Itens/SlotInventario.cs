using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInventario : MonoBehaviour
{
    public ItemBase itemAtual;
    public Button item;
    public Image icone;
    public Image iconeBloqueado;

    public static bool[] playerPegou = new bool[2];

    void Start()
    {
        icone.gameObject.SetActive(false);
        iconeBloqueado.gameObject.SetActive(false);
        playerPegou[0] = false;
        playerPegou[1] = false;
    }

    void Update()
    {
        if (item.name == "ItemThay")
        {
            CarregarInventorio();
            if (playerPegou[0])
                PlayerPegou();
            else
                PlayerNaoPegou();

        }
        else if (item.name == "ItemMio")
        {
            CarregarInventorio();
            if (playerPegou[1])
                PlayerPegou();
            else
                PlayerNaoPegou();
        }
    }

    public void PlayerPegou()
    {
        icone.gameObject.SetActive(true);
        iconeBloqueado.gameObject.SetActive(false);
        item.interactable = true;
    }

    public void PlayerNaoPegou()
    {
        icone.gameObject.SetActive(false);
        iconeBloqueado.gameObject.SetActive(true);
        item.interactable = false;
    }

    public static void CarregarInventorio()
    {
        if (PlayerPrefs.GetInt("ItemThay") != 0)
            playerPegou[0] = true;
        if (PlayerPrefs.GetInt("ItemMio") != 0)
            playerPegou[1] = true;
    }
}
