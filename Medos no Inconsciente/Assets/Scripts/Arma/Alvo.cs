using UnityEngine;
using UnityEngine.AI;

public class Alvo : MonoBehaviour
{
    public int vidaMax = 0;
    public int vidaAtual;
    public static bool podeAtirar = true;

    public VidaSlider vidaSlider;
    public AudioSource morte, musicaDepoisMorteInimigo, pausarMusicaAntes;

    [SerializeField] private DissolveEffect dissolveEffect;

    [ColorUsageAttribute(true, true)]
    [SerializeField] private Color startDissolveColor;
    [SerializeField] private GameObject inimigo;
    [SerializeField] private GameObject canvas;

    private void Start()
    {
        if (gameObject.CompareTag("PoderX1"))
            vidaMax = 30;
        else if (gameObject.CompareTag("PoderX2"))
            vidaMax = 50;
        else
            vidaMax = 100;

        vidaAtual = vidaMax;
        vidaSlider.MaxVida(vidaMax);
    }

    public void LevarDano(int dano)
    {
        vidaAtual -= dano;
        vidaSlider.EscolherVida(vidaAtual);
    }

    private void Update()
    {
        if (vidaAtual <= 0f)
        {
            Morte();
        }
    }

    void Morte()
    {
        morte.Play();
        if(gameObject.CompareTag("PoderX2"))
        {
            pausarMusicaAntes.Pause();
            musicaDepoisMorteInimigo.Play();
            Medalhas.terminou = true;
        }
        inimigo.GetComponent<NavMeshAgent>().enabled = false;
        canvas.SetActive(false);
        dissolveEffect.ComecarDissolver(.7f, startDissolveColor);
        Destroy(inimigo, 2f);
    }
}
