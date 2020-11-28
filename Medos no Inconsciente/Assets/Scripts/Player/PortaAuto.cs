using UnityEngine;

public class PortaAuto : MonoBehaviour
{
    public GameObject portaAberta, portaFechada;
    public GameObject portaAtual;
    public GameObject inimigo;

    public static bool ganhou;

    public float velocidade = 2f;

    private Vector3 posInicial;
    private int numObjDentro;

    public AudioSource porta;

    void Start()
    {
        ganhou = false;
        numObjDentro = 0;
        posInicial = portaFechada.transform.localPosition;
    }

    void Update()
    {
        if (numObjDentro > 0)
        {
            portaFechada.transform.localPosition = Vector3.Lerp(portaFechada.transform.localPosition, portaAberta.transform.localPosition, velocidade * Time.deltaTime);
        }
        else
            portaFechada.transform.localPosition = Vector3.Lerp(portaFechada.transform.localPosition, posInicial, velocidade * Time.deltaTime);              
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            porta.Play();
            numObjDentro++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        numObjDentro--;
        if (numObjDentro < 0)
            numObjDentro = 0;
    }
}
