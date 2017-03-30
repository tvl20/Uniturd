using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public Vector2 bulletDirection;

    private Vector3 mousePosition;
    private Rigidbody2D myRigidBody;

    public float RoF;
    public int ShieldPower;
    public PowerUp PowerUp;

    public Transform bullet;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        mousePosition = Input.mousePosition;
        RoF = 1;
        ShieldPower = 0;
        PowerUp = PowerUp.None;
        RelativeEntityLoc = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RelativeEntityLoc = myRigidBody.position;

        float newRotation = getRotation(RelativeEntityLoc, mousePosition);
        myRigidBody.MoveRotation(newRotation * -1);
        Rotation = newRotation;


        if (Input.GetKeyUp("space"))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }

    public void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") > 0.5 || Input.GetAxisRaw("Vertical") < -0.5 
            || Input.GetAxisRaw("Horizontal") > 0.5 || Input.GetAxisRaw("Horizontal") < -0.5)
        {
            Vector3 movement = Vector3.zero;

            if (Input.GetAxisRaw("Vertical") > 0.5 || Input.GetAxisRaw("Vertical") < -0.5)
            {
                if (mousePosition.y < transform.position.y - 1 ||
                    mousePosition.y > transform.position.y + 1 ||
                    mousePosition.x < transform.position.x - 1 ||
                    mousePosition.x > transform.position.x + 1)
                {
                    movement += transform.right*Input.GetAxisRaw("Vertical")*speed*Time.deltaTime*-1;
                }
            }

            if (Input.GetAxisRaw("Horizontal") > 0.5 || Input.GetAxisRaw("Horizontal") < -0.5)
            {
                if (mousePosition.y < transform.position.y - 1 ||
                    mousePosition.y > transform.position.y + 1 ||
                    mousePosition.x < transform.position.x - 1 ||
                    mousePosition.x > transform.position.x + 1)
                {
                    movement += transform.up*Input.GetAxisRaw("Horizontal")*speed*Time.deltaTime*-1;
                }
            }

            myRigidBody.MovePosition(myRigidBody.position + (Vector2) movement);
        }
        else
        {
            myRigidBody.velocity = Vector2.zero;
        }
    }
}
