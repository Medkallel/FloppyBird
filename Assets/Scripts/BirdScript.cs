using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour {
    private Rigidbody2D rb2d;
    public float speed = 15f;
    public bool isDead;
    public GameObject ReplayButton;
    public GameObject PlayButton;
    public Text scoreText;
   public new AudioSource audio ;
    [SerializeField]
    private float flapForce = 125f;
    public int delay;
    public int score = 0;
    public GameObject game;
    public GameObject over;
   
    public AudioClip flap;
    public AudioClip point;
    public AudioClip lose;
	// Use this for initialization
	void Start () {
        PlayButton.SetActive(true);
        Time.timeScale = 0;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.right * speed * Time.deltaTime;
        ReplayButton.SetActive(false);
        game.SetActive(false);
        over.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)&& !isDead || Input.GetKeyDown("space")&&!isDead)
        {
            rb2d.velocity = Vector2.right * speed * Time.deltaTime;
            rb2d.AddForce(Vector2.up * flapForce);
            audio.clip = flap;
            audio.Play();
            if (Input.GetKeyDown("space"))
            {
                unFreeze();
            }
         

        }
        
	}
    private void OnCollisionEnter2D(Collision2D col)
    {
        die();
      
    }
  
    void die()
    {
        game.SetActive(true);
        over.SetActive(true);
        isDead = true;
        rb2d.velocity = Vector2.zero;
        audio.clip = lose;
        audio.Play();
        GetComponent<Animator>().SetBool("isDead", true);
        ReplayButton.SetActive(true);
        game.SetActive(true);
        over.SetActive(true);
     

    }
    public void replay()
    {
        score = 0;
        SceneManager.LoadScene(0);
        game.SetActive(false);
        over.SetActive(false);
    }
    public void unFreeze()
    {
        Time.timeScale = 1;
        PlayButton.SetActive(false);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Score")
        {
            audio.clip = point;
            audio.PlayOneShot(point,0.7f);
            score++;
            speed = speed +  5;
            scoreText.text = score.ToString();


        }


    }
    }



