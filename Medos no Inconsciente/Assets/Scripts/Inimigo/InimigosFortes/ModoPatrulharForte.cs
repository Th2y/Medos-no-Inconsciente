using UnityEngine;
using UnityEngine.AI;

public class ModoPatrulharForte : ModoAbstratoForte
{
    public override void EstadoEntrada(InimigoForte obj)
    {
        Debug.Log("Está funcionando o " + obj.EstadoAtual);
    }

    public override void Update(InimigoForte obj)
    {
        if (obj != null)
        {
            obj.animInimigo.SetBool("atacando", false);

            Vector3 disPlayer = new Vector3(obj.player.transform.position.x - obj.disMinSeguir, obj.transform.position.y, obj.transform.position.z);
            obj.naveMesh.destination = disPlayer;
            obj.distanciaPlayer = Vector3.Distance(obj.player.transform.position, obj.transform.position);

            if (obj.player)
            {
                float dist = Vector3.Distance(obj.player.position, obj.transform.position);
                if (obj.alvo.levouTiro)
                {
                    obj.estaAtacandoDuplo = true;
                    obj.TransicaoParaEstado(obj.EstadoAtaqueDuplo);
                }
                else if (dist < 5)
                    obj.TransicaoParaEstado(obj.EstadoAtacar);
            }
        }
    }
}
