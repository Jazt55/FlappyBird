using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float forcaPulo;
    public GameManager gM;
    public AudioSource playersom;
    public AudioClip facaSom, puloSom, garfoSom,mantSom, chaoSom;
    int somFoi;
    public ParticleSystem playerFx;

    //public AudioClip

    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.AddForce(new Vector2(0,  4), ForceMode2D.Impulse);
        playersom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && gM.isGameOver == false && gM.isGamePaused == false && gM.delayPause <= Time.time)
        {
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            playersom.PlayOneShot(puloSom);
        }
        if (gM.isGamePaused == true)
        {
            playerRb.gravityScale = 0;
            playerRb.velocity = Vector2.zero;
        }
        if(gM.isGamePaused == false && gM.delayPause <= Time.time)
        {
            playerRb.gravityScale = 1.2f;
        }  
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstaculo" && somFoi== 0)
        {
            gM.isGameOver = true;
            playersom.PlayOneShot(facaSom);
            somFoi++;
        }
        if (collision.gameObject.tag == "chao" && somFoi == 0)
        {
            gM.isGameOver = true;
            playersom.PlayOneShot(chaoSom);
            somFoi++;
        }
        if (collision.gameObject.tag == "garfo" && somFoi == 0)
        {
            gM.isGameOver = true;
            playersom.PlayOneShot(garfoSom);
            somFoi++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Manteiga")
        {
            gM.pontuacao++;
            playerFx.Play();
            playersom.PlayOneShot(mantSom);
        }
    }
    public void pulo()
    {
        if(gM.isGameOver == false && gM.isGamePaused == false && gM.delayPause <= Time.time)
        {
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            playersom.PlayOneShot(puloSom);
        }        
    }
}
