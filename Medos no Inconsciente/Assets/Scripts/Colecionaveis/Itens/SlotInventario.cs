using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInventario : MonoBehaviour
{
    public Button[] item;

    public static bool[] playerPegou = new bool[12];

    void Start()
    {
        CarregarInventorio();
        for (int i = 0; i < item.Length; i++)
        {
            if (playerPegou[i])
                item[i].interactable = true;
            else
                item[i].interactable = false;
        }
    }

    public void CarregarInventorio()
    {
        if (PlayerPrefs.GetString("Medalha1_1") == "Sim")
            playerPegou[0] = true;
        if (PlayerPrefs.GetString("Medalha1_2") == "Sim")
            playerPegou[1] = true;
        if (PlayerPrefs.GetString("Medalha1_3") == "Sim")
            playerPegou[2] = true;
    }
}
