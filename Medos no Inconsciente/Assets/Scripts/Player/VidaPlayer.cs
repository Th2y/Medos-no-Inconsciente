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
    public GameObject inimigo;
    public GameObject perdeu;
    public VidaSlider vidaSlider;
    public Text quantidadeMoedas;
    public AudioSource morte;

    private int moedas;
    private int moedasGanhas = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey("Moedas"))
            moedas = PlayerPrefs.GetInt("Moedas");
        else
            moedas = 0;

        ganhou.SetActive(false);
        perdeu.SetActive(false);
        vidaAtual = vidaMax;
        vidaSlider.MaxVida(vidaMax);
        PlayerPrefs.SetString("Mudou", "false");
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
        if (vidaAtual <= 0)
        {
            morte.Play();

            moedasGanhas = Random.Range(1, 4);
            moedas += moedasGanhas;
            PlayerPrefs.SetInt("Moedas", moedas);
            quantidadeMoedas.text = moedasGanhas.ToString();

            MouseCursorAparencia.mouseOn = true;
            perdeu.SetActive(true);
            Menu.instancia.DeletarKeysFase1();
        }

        if (inimigo == null)
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
        MouseCursorAparencia.mouseOn = true;
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
