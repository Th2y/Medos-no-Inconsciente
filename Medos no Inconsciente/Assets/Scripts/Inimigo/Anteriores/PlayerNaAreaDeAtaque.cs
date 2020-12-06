using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNaAreaDeAtaque : MonoBehaviour
{
    public static bool passou0 = false;
    public static bool passou1 = false;

    public GameObject[] fracos;
    public GameObject[] fortes;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(gameObject.CompareTag("PoderX1"))
            {
                fracos[0].GetComponent<Inimigo>().podeAtacar = true;
                fracos[1].GetComponent<Inimigo>().podeAtacar = true;
                fracos[2].GetComponent<Inimigo>().podeAtacar = true;
                fracos[3].GetComponent<Inimigo>().podeAtacar = true;
                fracos[4].GetComponent<Inimigo>().podeAtacar = true;
            }
            else if(gameObject.CompareTag("PoderX2"))
            {
                fortes[0].GetComponent<Inimigo>().podeAtacar = true;
                fortes[1].GetComponent<Inimigo>().podeAtacar = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("PoderX1"))
            {
                fracos[0].GetComponent<Inimigo>().podeAtacar = false;
                fracos[1].GetComponent<Inimigo>().podeAtacar = false;
                fracos[2].GetComponent<Inimigo>().podeAtacar = false;
                fracos[3].GetComponent<Inimigo>().podeAtacar = false;
                fracos[4].GetComponent<Inimigo>().podeAtacar = false;
            }
            else if (gameObject.CompareTag("PoderX2"))
            {
                fortes[0].GetComponent<Inimigo>().podeAtacar = false;
                fortes[1].GetComponent<Inimigo>().podeAtacar = false;
            }
        }
    }
}
