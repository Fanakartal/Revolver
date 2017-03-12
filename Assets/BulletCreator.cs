using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletCreator : MonoBehaviour {


    //public GameObject scoreText;

    public static int score;
    // Use this for initialization
	void Start () 
    {
        //score = 0;
        
        //Destroy(this.gameObject, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            score++;
            
            //scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
            
            Destroy(this.gameObject);
        }
    }
}
