using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensDataBase : MonoBehaviour
{
    public List<ItemBase> itens;
    public static ItensDataBase instancia;

    private void Start()
    {
        instancia = this;
    }

    public int PegarIdItem(ItemBase itemParaChecar)
    {
        int id = -1;

        if (itemParaChecar.nome == "ItemThay")
        {
            id = 1;
            PlayerPrefs.SetInt("ItemThay", id);
        }
        else if (itemParaChecar.nome == "ItemMio")
        {
            id = 2;
            PlayerPrefs.SetInt("ItemMio", id);
        }

        return id;
    }
}
