using UnityEngine;

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

    private void Start()
    {
        municaoAtiva.SetActive(true);
        recargaAtiva.SetActive(false);
        instancia = this;
        quantidadeBalas = PlayerPrefs.GetInt("Municao", Loja.instancia.atualMunicao);
        tempoRecarga = 0;
    }

    void Update()
    {
        if(quantidadeBalas > 0)
        {
            municaoAtiva.SetActive(true);
            recargaAtiva.SetActive(false);
        }

        balasUsadas = balasGastas;

        mostrarTempoRecarga = (int)tempoRecarga;

        if (Input.GetButtonUp("Fire1"))
        {
            if (quantidadeBalas > 0 && !Menu.menuAberto)
                Atirar();
        }
        if (Input.GetButton("Fire2"))
            estaMirando = true;
        else
            estaMirando = false;

        if(quantidadeBalas == PlayerPrefs.GetInt("Municao"))
            tempoRecarga = 0f;

        if (quantidadeBalas == 0)
        {
            municaoAtiva.SetActive(false);
            recargaAtiva.SetActive(true);
            if (tempoRecarga == 0)
                tempoRecarga = PlayerPrefs.GetFloat("Recarga", Loja.instancia.atualRecarga);
            tempoRecarga -= Time.deltaTime;
            if (tempoRecarga <= 0)
                quantidadeBalas = PlayerPrefs.GetInt("Municao", Loja.instancia.atualMunicao);
        }
    }

    void Atirar()
    {
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

            GameObject impactoGO = Instantiate(impactoEfeito, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactoGO, 2f);
        }

        quantidadeBalas--;
    }
}
