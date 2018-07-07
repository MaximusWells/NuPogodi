using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour {

    public static CollectableObject getAccess;

    public GameObject egg;
    public GameObject bomb;
    public bool golden;
    public bool explode;
    public Animator bombAnimator;
    public Rigidbody2D bombRb;

    void Start()
    {
        explode = false;
        bombAnimator = bomb.GetComponent<Animator>();
        bombRb = bomb.GetComponent<Rigidbody2D>();
    }

    public void Exploding()
    {
        explode = true;
        bombAnimator.SetBool("Explode", true);
        bombRb.velocity = new Vector2(bomb.transform.position.x, 1f);
        Destroy(bomb, 0.2f);
        if (explode == true)
        {
            PlayerController.life--;
        }
    }
}
