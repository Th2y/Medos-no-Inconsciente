using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    public CharacterController controle;

    public float velocidade = 12f;
    public float gravidade = -9.81f;
    public float alturaPulo = 3f;

    public Transform checarChao;
    public float distanciaChao = 0.4f;
    public LayerMask chaoMascara;

    Vector3 veloz;
    bool estaNoChao;

    void Start()
    {
        
    }

    void Update()
    {
        estaNoChao = Physics.CheckSphere(checarChao.position, distanciaChao, chaoMascara);
        if(estaNoChao && veloz.y < 0)
        {
            veloz.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 mover = transform.right * x + transform.forward * z;

        controle.Move(mover * velocidade * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && estaNoChao)
        {
            veloz.y = Mathf.Sqrt(alturaPulo * -2f * gravidade);
        }

        veloz.y += gravidade * Time.deltaTime;

        controle.Move(veloz * Time.deltaTime);
    }
}
