using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : Entity
{
    public int Size;
    private Rigidbody2D myRigidbody;
	
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

            if (Size > 0)
            {
                int rnd = Random.Range(1, 3);
                for (int i = 0; i < rnd; i++)
                {
                    float rotation = Random.Range(0f, 360f);
                    GameObject spawnAstroid = (GameObject)Instantiate(this.transform, this.transform.position, Quaternion.Euler(0f, 0f, rotation)).gameObject;
                    spawnAstroid.transform.localScale += new Vector3(-0.1f, -0.1f, 0);

                    Astroid spawnAstroidScript = spawnAstroid.GetComponent<Astroid>();
                    spawnAstroidScript.Size = Size - 1;
                    spawnAstroidScript.speed = 1.5f;
                    //for (int i = 0; i < spawnAstroidScript.Size; i++)
                    //{
                    //    spawnAstroidScript.speed += 0.5f;
                    //}

                    Rigidbody2D spawnAstroidRigidbody2D = spawnAstroid.GetComponent<Rigidbody2D>();
                    spawnAstroidRigidbody2D.velocity = spawnAstroid.transform.position * spawnAstroidScript.speed * -1;
                }
            }

            Destroy(this.gameObject);
        }
    }
}
