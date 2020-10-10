using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    private LineRenderer lr;
    public Transform player;

    public AudioSource laser;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, player.position);

        Vector3 dir = transform.position - player.position;
    }
}




/*using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    private LineRenderer lr;
    public GameObject inimigo;

    public AudioSource laser;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Vector3 posicaoAlvo = inimigo.transform.position;
        posicaoAlvo.z -= 2;
        Vector3 direcao = (posicaoAlvo - inimigo.transform.position).normalized;
        direcao.y = 0;

        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direcao, out hit, 20))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
        }

        else lr.SetPosition(1, posicaoAlvo);


        Debug.DrawLine(inimigo.transform.position, direcao * 2);
    }
}*/