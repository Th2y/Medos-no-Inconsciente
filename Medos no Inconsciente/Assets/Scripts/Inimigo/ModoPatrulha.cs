using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModoPatrulha : InimigoAbstrato
{
    public override void EnterState(InimigoScript obj)
    {
        throw new System.NotImplementedException();
    }

    public override void OutState(InimigoScript obj)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(InimigoScript obj)
    {
        obj.transform.position = new Vector3(Mathf.PingPong(Time.time * obj.speed, 5), obj.transform.position.y, obj.transform.position.z);

        if (obj.player)
        {
            float dist = Vector3.Distance(obj.player.position, obj.transform.position);

            if (dist < 5)
            {
                obj.TransitionToState(obj.FollowState);
            }
        }
    }
}
