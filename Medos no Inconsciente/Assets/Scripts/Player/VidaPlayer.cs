using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public int vidaMax = 100;
    public int vidaAtual;
    public static bool estaSendoAtacadoX1 = false;
    public static bool estaSendoAtacadoX2 = false;

    public GameObject ganhou;
    public static int inimigo;
    public GameObject[] inimigos;
    public GameObject perdeu;
    public VidaSlider vidaSlider;
    public AudioSource morte;

    private bool acabou = false;

    void Start()
    {
        ganhou.SetActive(false);
        perdeu.SetActive(false);
        vidaAtual = vidaMax;
        vidaSlider.MaxVida(vidaMax);
        PlayerPrefs.SetString("Mudou", "false");
        inimigo = inimigos.Length;
    }

    void Update()
    {
        if (PortaAuto.ganhou)
            Invoke("Ganhou", 5f);

        if (estaSendoAtacadoX1)
        {
            LevarDanoX1(10);
            estaSendoAtacadoX1 = false;
        }
        if (estaSendoAtacadoX2)
        {
            LevarDanoX2(20);
            estaSendoAtacadoX2 = false;
        }
        if (vidaAtual <= 0 && !acabou)
        {
            morte.Play();

            MouseCursorAparencia.MudarCursor(true);
            perdeu.SetActive(true);
            Menu.instancia.DeletarKeysFase1();
            acabou = true;
        }

        if (inimigo <= 0)
            ganhou.SetActive(true);
    }

    public void LevarDanoX1(int dano)
    {
        estaSendoAtacadoX1 = true;
        vidaAtual -= dano;
        vidaSlider.EscolherVida(vidaAtual);
    }

    public void LevarDanoX2(int dano)
    {
        estaSendoAtacadoX2 = true;
        vidaAtual -= dano;
        vidaSlider.EscolherVida(vidaAtual);
    }

    void Ganhou()
    {
        MouseCursorAparencia.MudarCursor(true);
        ganhou.SetActive(true);
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
