using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public GameObject bullet;

    public GameObject enemy;

    public float speed; 

    public List<GameObject> spawnPositions;

    
    
    // Use this for initialization
	void Start () 
    {
        StartCoroutine(SpawnEnemies(enemy));
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    private IEnumerator SpawnEnemies(GameObject _enemy)
    {
        while(true)
        {
            //new Vector2(Random.Range(-10.5f, 10.5f), Random.Range(-6.5f, 6.5f))
            
            GameObject clone = Instantiate(_enemy, spawnPositions[Random.Range(0, 9)].transform.position, Quaternion.identity) as GameObject;

            if (clone.transform.position.x > 0.0f)
                clone.GetComponent<SpriteRenderer>().flipX = true;

            //clone.transform.position = Vector2.MoveTowards(clone.transform.position, this.gameObject.transform.position, speed * Time.deltaTime);
            
            //clone.GetComponent<Rigidbody2D>().AddForce((this.gameObject.transform.position - clone.gameObject.transform.position).normalized * amount);
            
            yield return new WaitForSeconds(5f);
        }
    }
}
