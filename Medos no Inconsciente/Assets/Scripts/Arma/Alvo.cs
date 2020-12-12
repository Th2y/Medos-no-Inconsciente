using UnityEngine;
using UnityEngine.AI;

public class Alvo : MonoBehaviour
{
    public int vidaMax = 0;
    public int vidaAtual;
    public static bool podeAtirar = true;
    public bool levouTiro = false;
    public AudioSource morte, musicaDepoisMorteInimigo, pausarMusicaAntes;

    [SerializeField] private DissolveEffect dissolveEffect;
    [ColorUsageAttribute(true, true)]
    [SerializeField] private Color startDissolveColor;
    [SerializeField] private GameObject inimigo;
    [SerializeField] private SpriteRenderer cor;
    [SerializeField] private Color[] cores;

    private int i = 0;

    private void Start()
    {
        vidaAtual = vidaMax;
    }

    public void LevarDano(int dano)
    {
        levouTiro = true;
        vidaAtual -= dano;

        if (gameObject.CompareTag("PoderX1"))
            cor.color = cores[0];
        else if (gameObject.CompareTag("PoderX2"))
        {
            if (i == 0)
                cor.color = cores[i];
            else if (i == 1)
                cor.color = cores[i];
            else if (i == 2)
                cor.color = cores[i];
            else if (i == 3)
                cor.color = cores[i];
        }

        i++;
    }

    private void Update()
    {
        if (vidaAtual <= 0)
            Morte();
    }

    void Morte()
    {
        VidaPlayer.instancia.inimigo--;
        if (gameObject.CompareTag("PoderX1"))
            PlayerNaAreaDeAtaque.fracos--;
        else if (gameObject.CompareTag("PoderX2"))
            PlayerNaAreaDeAtaque.fortes--;
        
        morte.Play();
        if(VidaPlayer.instancia.inimigo <= 0)
        {
            pausarMusicaAntes.Pause();
            musicaDepoisMorteInimigo.Play();
            Medalhas.terminou = true;
            MouseCursorAparencia.MudarCursor(true);
        }
        inimigo.GetComponent<NavMeshAgent>().enabled = false;
        dissolveEffect.ComecarDissolver(.7f, startDissolveColor);
        Destroy(inimigo, 2f);
        vidaAtual = 1;
    }
}
