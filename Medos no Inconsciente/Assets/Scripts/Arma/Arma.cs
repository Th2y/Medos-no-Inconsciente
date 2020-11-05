using UnityEngine;
using System.Collections;

public class Arma : MonoBehaviour
{
    public float dano = 10f;
    public float alcance = 100f;
    private int balasGastas = 0;
    public static int balasUsadas;

    public Camera fpsCam;
    public ParticleSystem flash;
    public GameObject impactoEfeito;

    public int quantidadeBalas;
    public float tempoRecarga;
    public static float mostrarTempoRecarga;
    public static bool estaMirando = false;

    public static Arma instancia;
    public AudioSource tiro;

    public GameObject municaoAtiva;
    public GameObject recargaAtiva;
    public Animator animTiro;

    public Material municoes;
    public Material recarga;
    public Color verde, amarelo, vermelho, azul;

    private void Start()
    {
        municaoAtiva.SetActive(true);
        recargaAtiva.SetActive(false);
        instancia = this;
        quantidadeBalas = PlayerPrefs.GetInt("Municao");
        tempoRecarga = 0;
    }

    void Update()
    {
        if (quantidadeBalas > 0)
        { 
            StopCoroutine("Recarregando");
            recarga.color = azul;
            if (quantidadeBalas >= 3)
            {
                //Material verde
                municoes.color = verde;
            }
            else if (quantidadeBalas >= 2)
            {
                //Material amarelo
                municoes.color = amarelo;
            }
            else
            {
                //Material vermelho
                municoes.color = vermelho;
            }
            municaoAtiva.SetActive(true);
            recargaAtiva.SetActive(false);
        }
        else
            recarga.color = amarelo;

        balasUsadas = balasGastas;

        mostrarTempoRecarga = (int)tempoRecarga;

        if (Input.GetButtonUp("Fire1"))
        {
            if (quantidadeBalas > 0 && !Menu.menuAberto)
                Atirar();
        }
        else
            animTiro.SetInteger("AnimTiro", 0);

        if (Input.GetButton("Fire2"))
            estaMirando = true;
        else
            estaMirando = false;

        if(quantidadeBalas == PlayerPrefs.GetInt("Municao"))
            tempoRecarga = 0f;

        if (quantidadeBalas == 0)
        {         
            municoes.color = vermelho;

            municaoAtiva.SetActive(false);
            recargaAtiva.SetActive(true);
            if (tempoRecarga == 0)
                tempoRecarga = PlayerPrefs.GetFloat("Recarga");
            tempoRecarga -= Time.deltaTime;
            if (tempoRecarga <= 0)
                quantidadeBalas = PlayerPrefs.GetInt("Municao");
        }
    }

    void Atirar()
    {
        quantidadeBalas--;
        balasGastas++;
        flash.Play();
        tiro.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, alcance))
        {
            Alvo alvo = hit.transform.GetComponent<Alvo>();
            if(alvo != null)
            {
                alvo.LevarDano((int)dano);
            }

            animTiro.SetInteger("AnimTiro", 1);

            GameObject impactoGO = Instantiate(impactoEfeito, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactoGO, 2f);
        }
    }
}
