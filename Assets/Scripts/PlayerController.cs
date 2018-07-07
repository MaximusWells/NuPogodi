using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public static int life;
    public static int collectedEggs;
    public Text lifesLeft;
    public Text haveEggs;
    public Button restart;
    Image resButton;
    public Button exit;
    Image exitButton;
//    public AudioSource _audio;

    private void Awake()
    {
//        _audio = GetComponent<AudioSource>();
        resButton = restart.GetComponent<Image>();
        exitButton = exit.GetComponent<Image>();
        Time.timeScale = 1;
        resButton.enabled = false;
        exitButton.enabled = false;
    }

    // Use this for initialization
    void Start () {
        collectedEggs = 0;
        life = 3;
        Calculate();
    }
	
	// Update is called once per frame
	void Update () {
		if (life <= -1)
        {
            GameOver();
        }
	}

    private void GameOver()
    {
        Time.timeScale = 0;
        resButton.enabled = true;
        exitButton.enabled = true;
    }

    public void Calculate()
    {
        haveEggs.text = "Score: " + collectedEggs.ToString();
        lifesLeft.text = "❤: " + life.ToString();
        if (life == -1)
        {
            lifesLeft.text = "♡";
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Egg"))
        {
            collectedEggs++;
            Calculate();
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.CompareTag("GoldenEgg"))
        {
            GameManager.instance.soundSource.Play();
            life++;
            Calculate();
            Destroy(collider.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Bomb"))
        {
            if (collider.gameObject.CompareTag("Bomb"))
            {
                life--;
                Calculate();
                collider.gameObject.tag = "Untagged";
            }
            collider.gameObject.GetComponent<Animator>().SetBool("Explode", true);
            collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collider.gameObject.transform.position.x, 1f);
            Destroy(collider.gameObject, 0.2f);
        }
    }
}
