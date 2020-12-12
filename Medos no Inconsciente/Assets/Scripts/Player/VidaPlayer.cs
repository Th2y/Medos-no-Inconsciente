using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public int vidaMax = 100;
    public int vidaAtual;
    public int inimigo;
    public bool estaSendoAtacado = false;

    private int dano;
    private bool acabou = false;
    private float tempoFumaca = 1f;

    [SerializeField] private GameObject ganhou;
    [SerializeField] private GameObject[] inimigos;
    [SerializeField] private GameObject perdeu;
    [SerializeField] private VidaSlider vidaSlider;
    [SerializeField] private AudioSource morte;
    [SerializeField] private GameObject fumaca;

    public static VidaPlayer instancia;

    void Start()
    {
        instancia = this;
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

        if (estaSendoAtacado)
        {
            tempoFumaca -= Time.deltaTime;
            if(tempoFumaca == 1f)
                LevarDano(dano);
            else if(tempoFumaca <= 0)
            {
                fumaca.SetActive(false);
                tempoFumaca = 1f;
                estaSendoAtacado = false;
            }
        }
        
        if (vidaAtual <= 0 && !acabou)
        {
            morte.Play();

            MouseCursorAparencia.MudarCursor(true);
            perdeu.SetActive(true);
            acabou = true;
        }

        if (inimigo <= 0)
            ganhou.SetActive(true);
    }

    public void LevarDano(int dano)
    {
        estaSendoAtacado = true;
        fumaca.SetActive(true);
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
