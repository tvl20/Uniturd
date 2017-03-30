using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public float speed;
    public float Rotation;

    public Vector2 HorizontalMovementVector = new Vector2(0, 0);
    public Vector2 VerticalMovementVector = new Vector2(0, 0);

    protected Vector3 RelativeEntityLoc;
    
    public float getRotation(Vector3 PlayerPos, Vector3 MousePos)
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
