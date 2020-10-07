using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBase : MonoBehaviour
{
    public string nome;
    public Sprite icone;
    protected int quantidade = 1;
    private bool podePegarItem;
    public int itemId;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && podePegarItem)
        {
            InventorioControle.instancia.AddItemParaInventorio(this);
        }
    }

    public void AddItem(int quantidadeAdd = 1)
    {
        quantidade += quantidadeAdd;
    }

    public int PegarQuantidade()
    {
        return quantidade;
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.name == "Player")
        {
            podePegarItem = true;
            UIElementos.instancia.MostrarMensagemItem();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            podePegarItem = false;
        }
    }
}
