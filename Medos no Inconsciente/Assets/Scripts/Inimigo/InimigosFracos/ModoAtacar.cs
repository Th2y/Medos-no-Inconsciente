using UnityEngine;
using UnityEngine.AI;

public class ModoAtacar : ModoAbstrato
{
    public override void EstadoEntrada(InimigoFraco obj)
    {
        Debug.Log("Está funcionando o " + obj.EstadoAtual);
    }

    public override void Update(InimigoFraco obj)
    {
        if (obj != null)
        {
            if (!obj.estaAtacando)
            {
                obj.animInimigo.SetBool("atacando", false);
                obj.laser.SetActive(false);
                obj.cronometroAtaque -= Time.deltaTime;
            }
            else
            {
                obj.animInimigo.SetBool("atacando", true);
                obj.espereLaser -= Time.deltaTime;
                if (obj.espereLaser <= 0)
                {
                    obj.estaAtacando = false;
                    obj.espereLaser = 1f;
                }
            }

            if (obj.cronometroAtaque <= 0 && obj.areaAtaque)
            {
                obj.estaAtacando = true;
                Atacar(obj);
                obj.cronometroAtaque = obj.tempoAtacar;
            }

            float dist = Vector3.Distance(obj.player.position, obj.transform.position);
            if (dist >= 5)
                obj.TransicaoParaEstado(obj.EstadoPatrulha);
        }
    }

    void Atacar(InimigoFraco obj)
    {
        VidaPlayer.instancia.LevarDano(10);

        obj.laser.SetActive(true);
    }
}
