using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorioControle : MonoBehaviour
{
    public List<ItemBase> inventorioItens;
    public static InventorioControle instancia;

    void Start()
    {
        instancia = this;
    }

    public void AddItemParaInventorio(ItemBase item)
    {
        item.itemId = ItensDataBase.instancia.PegarIdItem(item);
        inventorioItens.Add(item);
        item.gameObject.SetActive(false);
    }
}
