using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SwarmingEnemy : BaseEnemy
{
    [SerializeField]
    private float swarmSpeed;
    protected override void Start()
    {
        base.Start();
    }
    private void FixedUpdate()
    {
        if (player.position.x > transform.position.x)
        {
            player.position += Vector3.left;
        }
        else
        {
            player.position += Vector3.right;
        }
        if (player.position.y > transform.position.y)
        {
            player.position += Vector3.down;
        }
        else
        {
            player.position += Vector3.up;
        }
    }


}