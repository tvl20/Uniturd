using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private Rigidbody2D myRigidBody;

    public float RoF;
    public int ShieldPower;
    public PowerUp PowerUp;

    private Vector3 mousePosition;
    private Vector3 relativePlayerLoc;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        speed = 4;
        mousePosition = Input.mousePosition;
        RoF = 1;
        ShieldPower = 0;
        PowerUp = PowerUp.None;
        relativePlayerLoc = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        /*
         * mouse is 0.0 bottom left corner
         * gameObj is 0.0 center of the screen
         */

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        relativePlayerLoc = myRigidBody.position;

        float newRotation = getNewRotation(relativePlayerLoc, mousePosition);
        myRigidBody.MoveRotation(newRotation * -1);
        Rotation = newRotation;
    }

    public void FixedUpdate()
    {
        //todo: make movement relative to the cursor/rotation
        //todo: make movement relative to cursor/rotation by way of forces

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
    }

    private float getNewRotation(Vector3 PlayerPos, Vector3 MousePos)
    {
        float angle = PlayerPos.z;
        float adjacent = 0.001f;
        float opposite = 0.001f;

        if (PlayerPos.x > MousePos.x && PlayerPos.y < MousePos.y) //top left
        {
            opposite = MousePos.y - PlayerPos.y;
            adjacent = PlayerPos.x - MousePos.x;
            angle = 0;
        }
        else if (PlayerPos.x < MousePos.x && PlayerPos.y < MousePos.y) //top right
        {
            adjacent = MousePos.y - PlayerPos.y;
            opposite = MousePos.x - PlayerPos.x;
            angle = 90;
        }
        else if (PlayerPos.x < MousePos.x && PlayerPos.y > MousePos.y) //bottom right
        {
            opposite = PlayerPos.y - MousePos.y;
            adjacent = MousePos.x - PlayerPos.x;
            angle = 180;
        }
        else if (PlayerPos.x > MousePos.x && PlayerPos.y > MousePos.y) //bottom left
        {
            adjacent = PlayerPos.y - MousePos.y;
            opposite = PlayerPos.x - MousePos.x;
            angle = 270;
        }

        angle += getAngle(adjacent, opposite);
        return angle;
    }

    private float getAngle(float adjacent, float opposite)
    {
        if (adjacent < 0.001f)
        {
            adjacent = 0.001f;
        }

        if (opposite < 0.001f)
        {
            opposite = 0.001f;
        }

        double tan = Math.Atan(opposite / adjacent);
        float angle = (float)(tan * (180 / Math.PI));
        return angle;
    }
}
