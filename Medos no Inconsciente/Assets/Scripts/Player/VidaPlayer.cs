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
    public Text quantidadeMoedas;

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

        if (estaSendoAtacado)
        {
            LevarDano(20);
            estaSendoAtacado = false;
        }
        if (vidaAtual <= 0)
        {
            moedasGanhas = Random.Range(1, 4);
            moedas += moedasGanhas;
            PlayerPrefs.SetInt("Moedas", moedas);
            quantidadeMoedas.text = moedasGanhas.ToString();
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
