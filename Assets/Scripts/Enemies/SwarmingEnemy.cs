using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwarmingEnemy : BaseEnemy
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
            transform.position += Vector3.right * swarmSpeed * Time.fixedDeltaTime;
        }
        else
        {
            transform.position += Vector3.left * swarmSpeed * Time.fixedDeltaTime;
        }
        if (player.position.y > transform.position.y)
        {
            transform.position += Vector3.up * swarmSpeed * Time.fixedDeltaTime;
        }
        else
        {
            transform.position += Vector3.down * swarmSpeed * Time.fixedDeltaTime;
        }
    }


}