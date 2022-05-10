using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SwarmingEnemy : BaseEnemy 
{
    [SerializeField]
    private float swarmSpeed;
    private void Swarm() 
    {
        if(player.position.x > gameObject.position.x)
        {
            player.position.x -= swarmSpeed;
        }
        else
        {
            player.position.x += swarmSpeed;
        }
        if(player.position.y > gameObject.position.y)
        {
            player.position.y -= swarmSpeed;
        }
        else
        {
            player.position.y += swarmSpeed;
        }
    }


}