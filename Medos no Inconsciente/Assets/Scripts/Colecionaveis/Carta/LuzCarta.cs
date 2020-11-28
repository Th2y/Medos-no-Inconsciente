using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzCarta : MonoBehaviour
{
    public static LuzCarta instancia;
    public GameObject luz;

    private void Start()
    {
        instancia = this;
    }

    public void ApagarCarta()
    {
        Destroy(luz);
    }
}
