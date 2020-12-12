using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNaAreaDeAtaque : MonoBehaviour
{
    public GameObject[] inimigosFracos;
    public GameObject[] inimigosFortes;
    public static int fracos, fortes;

    private void Start()
    {
        fracos = inimigosFracos.Length;
        fortes = inimigosFortes.Length;
    }

    private void OnTriggerStay(Collider other)
    {
        if (inimigosFracos.Length > 0)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                for (int i = 0; i < inimigosFracos.Length; i++)
                {
                    if (inimigosFracos[i] != null)
                        inimigosFracos[i].GetComponent<InimigoFraco>().areaAtaque = true;
                }
            }
        }


        if (inimigosFortes.Length > 0)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                for (int i = 0; i < inimigosFortes.Length; i++)
                {
                    if (inimigosFortes[i] != null)
                        inimigosFortes[i].GetComponent<InimigoForte>().areaAtaque = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(inimigosFracos.Length > 0)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                for (int i = 0; i < inimigosFracos.Length; i++)
                {
                    if (inimigosFracos[i] != null)
                        inimigosFracos[i].GetComponent<InimigoFraco>().areaAtaque = false;
                }
            }
        }
        if(inimigosFortes.Length > 0)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                for (int i = 0; i < inimigosFortes.Length; i++)
                {
                    if(inimigosFortes[i] != null)
                        inimigosFortes[i].GetComponent<InimigoForte>().areaAtaque = false;
                }
            }
        }
    }
}
