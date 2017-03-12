using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharController : MonoBehaviour {

    public GameObject bullet;
    public GameObject bulletPoint;
    private GameObject _bulletClone;

    public float speed;

    private Quaternion turnDegree;
    private float degree;

    float vectorX;
    float vectorY;
    private float zRotation;

    public GameObject scoreText;
    public GameObject deadText;
    
    // Use this for initialization
	void Start () 
    {
        degree = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            BulletCreator.score = 0;
            SceneManager.LoadScene(0);
        }
        
        scoreText.GetComponent<Text>().text = "Score: " + BulletCreator.score;
        //if (degree >= 360.0f)
        //    degree = 0.0f;
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            degree += 90.0f;
            turnDegree = Quaternion.Euler(0.0f, 0.0f, degree);
            //this.gameObject.transform.Rotate(0.0f, 0.0f, 90.0f);

        }

        if(Input.GetKeyDown(KeyCode.RightControl))
        {
            _bulletClone = Instantiate(bullet, bulletPoint.transform.position, Quaternion.identity) as GameObject;

            zRotation = this.gameObject.transform.eulerAngles.z * Mathf.Deg2Rad;
            vectorX = Mathf.Cos(zRotation);
            vectorY = Mathf.Sin(zRotation);
            //Debug.Log("X: " + vectorX + "Y: " + vectorY);
            //_bulletClone.GetComponent<Rigidbody2D>().AddForce(transform.forward)
            _bulletClone.transform.rotation = this.gameObject.transform.rotation;
            _bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(vectorX * speed, vectorY * speed);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, turnDegree, Time.deltaTime * 3.0f);
	
	}

    void OnCollisioonEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("girdi");
            deadText.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator RotateSmoothly(float p)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 90.0f), Time.deltaTime * 2.0f);

        yield return new WaitForSeconds(p);
    }
}
