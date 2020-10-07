using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour {

    [SerializeField] private Material material;

    private float dissolverMontante;
    private float dissolverVelocidade;
    public bool estaDissolvendo;

    private void Start() 
    {
        if (material == null) 
            material = transform.Find("Corpo").GetComponent<MeshRenderer>().material;
    }

    private void Update() 
    {
        if (estaDissolvendo) 
        {
            dissolverMontante = Mathf.Clamp01(dissolverMontante + dissolverVelocidade * Time.deltaTime);
            material.SetFloat("_DissolveAmount", dissolverMontante);
        } 
        else 
        {
            dissolverMontante = Mathf.Clamp01(dissolverMontante - dissolverVelocidade * Time.deltaTime);
            material.SetFloat("_DissolveAmount", dissolverMontante);
        }
    }

    public void ComecarDissolver(float dissolveSpeed, Color dissolveColor) 
    {
        estaDissolvendo = true;
        material.SetColor("_DissolveColor", dissolveColor);
        this.dissolverVelocidade = dissolveSpeed;
    }

    public void PararDissolver(float dissolveSpeed, Color dissolveColor) 
    {
        estaDissolvendo = false;
        material.SetColor("_DissolveColor", dissolveColor);
        this.dissolverVelocidade = dissolveSpeed;
    }
}
