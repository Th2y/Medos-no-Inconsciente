using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Inimigo : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent naveMesh;
    private float distanciaPlayer, distanciaAtaque1 = 40f, distanciaAtaque2 = -40f, cronometroAtaque = 5f;
    public bool estaAtacando = false;
    private int quantBalas = 5;
    public GameObject laser;

    void Start()
    {        
        naveMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 distanciajogador = new Vector3(player.transform.position.x - 30, player.transform.position.y, player.transform.position.z);
        naveMesh.destination = distanciajogador;
        distanciaPlayer = Vector3.Distance(player.transform.position, transform.position);

        //if (!estaAtacando)
            //laser.SetActive(false);

        if (distanciaPlayer <= distanciaAtaque1 || distanciaPlayer <= distanciaAtaque2)
            estaAtacando = true;

        if (estaAtacando && quantBalas > 0)
        {
            cronometroAtaque -= Time.deltaTime;
        }
        if (cronometroAtaque <= 0)
        {
            Atacar();
            cronometroAtaque = 5f;
        }
    }

    void Atacar()
    {
        VidaPlayer.estaSendoAtacado = true;
        quantBalas--;
        //laser.SetActive(true);
        Invoke("Fim", 4f);
    }

    void Fim()
    {
        estaAtacando = false;
    }
}
