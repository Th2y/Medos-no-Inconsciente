using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class InimigoForte : MonoBehaviour
{
    private ModoAbstratoForte estadoAtual;
    public Transform player;
    public Alvo alvo;
    public NavMeshAgent naveMesh;
    public float disMinSeguir, distanciaPlayer, distanciaAtaque, cronometroAtaque, tempoAtacar, espereLaser = 1f;
    public bool estaAtacando = false, areaAtaque = false, estaAtacandoDuplo = false;
    public GameObject laser;
    public Animator animInimigo;

    public ModoAbstratoForte EstadoAtual
    {
        get {return estadoAtual;}
    }

    public readonly ModoAtacarForte EstadoAtacar = new ModoAtacarForte();
    public readonly ModoAtaqueDuplo EstadoAtaqueDuplo = new ModoAtaqueDuplo();
    public readonly ModoPatrulharForte EstadoPatrulha = new ModoPatrulharForte();

    void Start()
    {
        TransicaoParaEstado(EstadoAtacar);
    }

    void Update()
    {
        estadoAtual.Update(this);
    }

    public void TransicaoParaEstado(ModoAbstratoForte estado)
    {
        estadoAtual = estado;
        estadoAtual.EstadoEntrada(this);
    }
}
