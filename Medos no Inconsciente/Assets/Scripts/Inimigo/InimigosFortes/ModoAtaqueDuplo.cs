using UnityEngine;
using UnityEngine.AI;

public class ModoAtaqueDuplo : ModoAbstratoForte
{
    public override void EstadoEntrada(InimigoForte obj)
    {
        Debug.Log("Está funcionando o " + obj.EstadoAtual);
    }

    public override void Update(InimigoForte obj)
    {
        if (obj != null)
        {
            if (obj.areaAtaque && obj.estaAtacandoDuplo)
            {
                obj.animInimigo.SetBool("atacandoDuplo", true);
                obj.espereLaser -= Time.deltaTime;
                if (obj.espereLaser <= 0)
                {
                    obj.estaAtacando = false;
                    obj.espereLaser = 1f;
                }

                Atacar(obj);
                Atacar(obj);
                obj.alvo.levouTiro = false;
                obj.animInimigo.SetBool("atacandoDuplo", false);
                obj.laser.SetActive(false);
                obj.estaAtacandoDuplo = false;
            }
            else if(!obj.estaAtacandoDuplo)
            {
                float dist = Vector3.Distance(obj.player.position, obj.transform.position);
                if (dist >= 5)
                    obj.TransicaoParaEstado(obj.EstadoPatrulha);              
            }
        }
    }

    void Atacar(InimigoForte obj)
    {
        VidaPlayer.instancia.LevarDano(5);
        obj.laser.SetActive(true);
    }
}
