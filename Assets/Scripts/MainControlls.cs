using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControlls : MonoBehaviour {

    public Camera m_camera;
    [SerializeField]
    protected Rigidbody2D player;
    protected Vector2 pointerPos;
    protected Vector2 playerPos;
    protected Vector2 worldScreen;
    public static float maxWidth;
    protected bool directionL;


    void Start () {
        if (m_camera == null)
        {
            m_camera = Camera.main;
        }
        worldScreen = m_camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        maxWidth = worldScreen.x;
    }

    void FixedUpdate()
    {
        pointerPos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        playerPos = new Vector2(pointerPos.x, 0.0f);
        float worldScreen = Mathf.Clamp(playerPos.x, -maxWidth, maxWidth);
        playerPos = new Vector2(worldScreen, playerPos.y);
        player.position = playerPos;

        if (Input.GetAxis("Mouse X") < 0 && directionL)
        {
            Flip();
        }
        else if (Input.GetAxis("Mouse X") > 0 && !directionL)
        {
            Flip();
        }
    }

    private void Flip()
    {
        directionL = !directionL;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
