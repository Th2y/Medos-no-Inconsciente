using UnityEngine;
using UnityEngine.AI;

public class ModoAtacarForte : ModoAbstratoForte
{
    public override void EstadoEntrada(InimigoForte obj)
    {
        Debug.Log("Está funcionando o " + obj.EstadoAtual);
    }

    public override void Update(InimigoForte obj)
    {
        if (obj != null)
        {
            Vector3 disPlayer = new Vector3(obj.player.transform.position.x - obj.disMinSeguir, obj.transform.position.y, obj.transform.position.z);
            obj.naveMesh.destination = disPlayer;
            obj.distanciaPlayer = Vector3.Distance(obj.player.transform.position, obj.transform.position);

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
            if (obj.alvo.levouTiro)
            {
                obj.estaAtacandoDuplo = true;
                obj.TransicaoParaEstado(obj.EstadoAtaqueDuplo);
            }
            else if (dist >= 5)
                obj.TransicaoParaEstado(obj.EstadoPatrulha);
        }
    }

    void Atacar(InimigoForte obj)
    {
        VidaPlayer.instancia.LevarDano(20);

        obj.laser.SetActive(true);
    }
}
