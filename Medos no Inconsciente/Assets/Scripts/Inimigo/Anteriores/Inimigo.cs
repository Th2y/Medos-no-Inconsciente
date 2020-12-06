using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Inimigo : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent naveMesh;
    private float distanciaPlayer, distanciaAtaque = 20f, cronometroAtaque = 5f;
    public bool estaAtacando = false;
    public GameObject laser;
    public bool podeAtacar = false;
    [SerializeField] private Animator animInimigo;

    void Start()
    {        
        naveMesh = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        Vector3 direcao = player.transform.position - transform.position;
        Vector3 distanciajogador = new Vector3(player.transform.position.x - 30, player.transform.position.y, player.transform.position.z);
        naveMesh.destination = distanciajogador;
        distanciaPlayer = Vector3.Distance(player.transform.position, transform.position);

        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        transform.rotation = Quaternion.Slerp(transform.rotation, novaRotacao, Time.deltaTime * 1);

        if (podeAtacar)
        {
            if (distanciaPlayer <= distanciaAtaque && distanciaPlayer >= distanciaAtaque - 10)
                estaAtacando = true;

            if (!estaAtacando)
                laser.SetActive(false);
            else
                cronometroAtaque -= Time.deltaTime;

            if (cronometroAtaque <= 0)
            {
                Atacar();
                cronometroAtaque = 5f;
            }
        }        
        else
            laser.SetActive(false);
    }

    void Atacar()
    {
        animInimigo.SetBool("atacando", true);
        if (gameObject.CompareTag("PoderX1"))
            VidaPlayer.estaSendoAtacadoX1 = true;
        else if(gameObject.CompareTag("PoderX2"))
            VidaPlayer.estaSendoAtacadoX2 = true;

        laser.SetActive(true);
        Invoke("Fim", 4f);
        animInimigo.SetBool("atacando", false);
    }

    void Fim()
    {
        estaAtacando = false;
    }
}
