using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float RoF;
    public int ShieldPower;
    public PowerUp PowerUp;

    private Vector3 mousePosition;
    private Vector3 relativePlayerLoc;

    // Use this for initialization
    void Start ()
	{
	    mousePosition = Input.mousePosition;
	    RoF = 1;
	    ShieldPower = 0;
        PowerUp = PowerUp.None;
        relativePlayerLoc = transform.position; //player position with origin in bottom left cornor
        relativePlayerLoc.x += 512;
        relativePlayerLoc.y += 384;
    }
	
	// Update is called once per frame
	void Update () {
        /*
         * mouse is 0.0 bottom left corner
         * gameObj is 0.0 center of the screen
         */
        mousePosition = Input.mousePosition;

        relativePlayerLoc = transform.position; //player position with origin in bottom left cornor
	    relativePlayerLoc.x += 512; //half the total width
	    relativePlayerLoc.y += 384; //half the total height

        float newRotation = getNewRotation(relativePlayerLoc, mousePosition);
        transform.Rotate(0, 0, (newRotation - Rotation)*-1); // * -1 ohterwise its mirrored
        Rotation = newRotation;
    }

    private float getNewRotation(Vector3 PlayerPos, Vector3 MousePos)
    {
	    float angle = PlayerPos.z;
	    float adjacent = 1;
	    float opposite = 1;
        
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
        if (adjacent < 0.1f)
        {
            adjacent = 0.25f;
        }

        if (opposite < 0.1f)
        {
            opposite = 0.25f;
        }

        double tan = Math.Atan(opposite / adjacent);
        float angle = (float)(tan * (180 / Math.PI));
        return angle;
    }
}
