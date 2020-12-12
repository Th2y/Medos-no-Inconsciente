using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNaAreaDeAtaque : MonoBehaviour
{
    public GameObject[] inimigosFracos;
    public GameObject[] inimigosFortes;

    private void OnTriggerStay(Collider other)
    {
        if (inimigosFracos != null)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                for (int i = 0; i < inimigosFracos.Length; i++)
                {
                    inimigosFracos[i].GetComponent<InimigoFraco>().areaAtaque = true;
                }
            }
        }


        if (inimigosFortes.Length > 0)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                for (int i = 0; i < inimigosFracos.Length; i++)
                {
                    inimigosFortes[i].GetComponent<InimigoForte>().areaAtaque = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(inimigosFracos != null)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                for (int i = 0; i < inimigosFracos.Length; i++)
                {
                    inimigosFracos[i].GetComponent<InimigoFraco>().areaAtaque = false;
                }
            }
        }
        if(inimigosFortes != null)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                for (int i = 0; i < inimigosFracos.Length; i++)
                {
                    inimigosFortes[i].GetComponent<InimigoFraco>().areaAtaque = false;
                }
            }
        }
    }
}
