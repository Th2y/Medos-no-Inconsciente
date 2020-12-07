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
        Vector3 direcao = obj.player.transform.position - obj.transform.position;
        Vector3 disPlayer = new Vector3(obj.player.transform.position.x - obj.disMinSeguir, obj.transform.position.y, obj.transform.position.z);
        obj.naveMesh.destination = disPlayer;
        obj.distanciaPlayer = Vector3.Distance(obj.player.transform.position, obj.transform.position);
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, novaRotacao, Time.deltaTime * 1);

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
            if(obj.espereLaser <= 0)
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
        if (Alvo.levouTiro)
            obj.TransicaoParaEstado(obj.EstadoAtaqueDuplo);
        else if (dist >= 5)
            obj.TransicaoParaEstado(obj.EstadoPatrulha);
    }

    void Atacar(InimigoForte obj)
    {
        VidaPlayer.estaSendoAtacadoX2 = true;

        obj.laser.SetActive(true);
    }
}
