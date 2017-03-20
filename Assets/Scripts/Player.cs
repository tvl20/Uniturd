using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float RoF;
    public int ShieldPower;
    public float Direction;
    public PowerUp PowerUp;

    private Vector3 mousePosition;

	// Use this for initialization
	void Start ()
	{
	    mousePosition = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {
        mousePosition = Input.mousePosition;
    }
}
