using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Entity
{
    public bool Piercing;

    private Player player;
    private Rigidbody2D myRigidBody;

    // Use this for initialization
    void Start()
    {
        speed = 15f;
        player = (Player)GameObject.Find("Player").GetComponent(typeof(Player));
        myRigidBody = GetComponent<Rigidbody2D>();

        if (player.PowerUp == PowerUp.Piercing)
        {
            Piercing = true;
        }
        
        myRigidBody.velocity = transform.right * speed * -1;
    }
}
