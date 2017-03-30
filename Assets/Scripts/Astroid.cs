using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : Entity
{
    public int Size;
    private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start ()
	{
	    myRigidbody = GetComponent<Rigidbody2D>();

        myRigidbody.velocity = transform.right * speed * -1;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (transform.position.y > 8.5f ||
            transform.position.y < -8.5f ||
            transform.position.x > 11f ||
            transform.position.x < -11f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Bullet(Clone)")
        {
            print("A bullet has hit an astroid");
            Destroy(this.gameObject);
        }
    }
}
