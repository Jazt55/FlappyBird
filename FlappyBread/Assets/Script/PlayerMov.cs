using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float forcaPulo;
    public GameManager gM;
    
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && gM.isGameOver == false)
        {
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstaculo")
        {
            gM.isGameOver = true;
        }
    }
}
