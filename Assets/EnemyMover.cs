using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour {

	
    private float speed = 1.5f;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0,0), speed * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
            Destroy(this.gameObject);

        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
