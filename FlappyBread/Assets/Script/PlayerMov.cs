using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float forcaPulo;
    public GameManager gM;
    public AudioClip facaSom;
    public AudioClip puloSom;
    public AudioClip garfoSom;
    public AudioClip chaoSom;
    int somFoi;
    public ParticleSystem playerFx;

    //public AudioClip

    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.AddForce(new Vector2(0,  4), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && gM.isGameOver == false && gM.isGamePaused == false)
        {
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            gM.gMaudio.PlayOneShot(puloSom);
        }
        if (gM.isGamePaused == true)
        {
            playerRb.gravityScale = 0;
            playerRb.velocity = Vector2.zero;
        }
        else
        {
            playerRb.gravityScale = 1;
        }  
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstaculo" && somFoi== 0)
        {
            gM.isGameOver = true;
            gM.gMaudio.PlayOneShot(facaSom);
            somFoi++;
        }
        if (collision.gameObject.tag == "chao" && somFoi == 0)
        {
            gM.isGameOver = true;
            gM.gMaudio.PlayOneShot(chaoSom);
            somFoi++;
        }
        if (collision.gameObject.tag == "garfo" && somFoi == 0)
        {
            gM.isGameOver = true;
            gM.gMaudio.PlayOneShot(garfoSom);
            somFoi++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Manteiga")
        {
            gM.pontuacao++;
            playerFx.Play();
        }
    }
    public void pulo()
    {
        if(gM.isGameOver == false && gM.isGamePaused == false)
        {
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            gM.gMaudio.PlayOneShot(puloSom);
        }        
    }
}
