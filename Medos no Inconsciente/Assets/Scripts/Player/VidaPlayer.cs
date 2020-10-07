using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public int vidaMax = 100;
    public int vidaAtual;
    public static bool estaSendoAtacado = false;

    public GameObject ganhou;
    public GameObject perdeu;
    public VidaSlider vidaSlider;

    public GameObject[] itensColetados;

    void Start()
    {
        ganhou.SetActive(false);
        perdeu.SetActive(false);
        vidaAtual = vidaMax;
        vidaSlider.MaxVida(vidaMax);
        itensColetados[0].SetActive(false);
        itensColetados[1].SetActive(false);
        PlayerPrefs.SetString("Mudou", "false");
    }

    void Update()
    {
        if (PortaAuto.ganhou)
            Invoke("Ganhou", 5f);

        if (estaSendoAtacado)
        {
            LevarDano(20);
            estaSendoAtacado = false;
        }
        if (vidaAtual <= 0)
        {
            MouseCursorAparencia.mouseOn = true;
            perdeu.SetActive(true);
            Menu.instancia.DeletarKeysFase1();
        }
    }

    public void LevarDano(int dano)
    {
        estaSendoAtacado = true;
        vidaAtual -= dano;
        vidaSlider.EscolherVida(vidaAtual);
    }

    void Ganhou()
    {
        MouseCursorAparencia.mouseOn = true;
        ganhou.SetActive(true);

        if(PlayerPrefs.GetInt("ItemThay") != 0)
            itensColetados[0].SetActive(true);
        if (PlayerPrefs.GetInt("ItemMio") != 0)
            itensColetados[1].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ganhou")
        {
            PlayerPrefs.SetString("Mudou", "true");
            Loja.instancia.GanharMoedas();
        }
    }
}
