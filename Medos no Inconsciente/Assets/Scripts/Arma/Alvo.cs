using UnityEngine;
using UnityEngine.AI;

public class Alvo : MonoBehaviour
{
    public int vidaMax = 50;
    public int vidaAtual;

    public VidaSlider vidaSlider;

    [SerializeField] private DissolveEffect dissolveEffect;

    [ColorUsageAttribute(true, true)]
    [SerializeField] private Color startDissolveColor;
    [SerializeField] private GameObject inimigo;
    [SerializeField] private GameObject canvas;

    private void Start()
    {
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
        Medalhas.terminou = true;
        inimigo.GetComponent<NavMeshAgent>().enabled = false;
        canvas.SetActive(false);
        dissolveEffect.ComecarDissolver(.7f, startDissolveColor);
        Destroy(inimigo, 2f);
    }
}
