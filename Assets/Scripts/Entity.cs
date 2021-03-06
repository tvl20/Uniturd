﻿using System;
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
}
