using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
    }
}
