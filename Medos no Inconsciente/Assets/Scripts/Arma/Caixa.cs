using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixa : MonoBehaviour
{
    [SerializeField] private GameObject caixa;
    public static Caixa instancia;

    private void Start()
    {
        instancia = this;
    }

    public void Destruir()
    {
        Destroy(caixa);
    }
}
