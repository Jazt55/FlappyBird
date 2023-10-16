using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsMov : MonoBehaviour
{
    public float direcao;
    public float speedY;
    
    public float tempo;
    public float delay = 1;
    private GameManager gM;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        tempo = Time.time + delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (gM.isGameOver == false && gM.isGamePaused == false && gM.delayPause <= Time.time)
        {
            transform.position = new Vector3(transform.position.x - gM.speedX * Time.deltaTime, transform.position.y, transform.position.z);
            transform.position = new Vector3(transform.position.x, transform.position.y + speedY * direcao * Time.deltaTime, transform.position.z);
        }

        if (transform.position.x <= -18)
        {
            Destroy(gameObject);
        }

        
        
            
        

        if (tempo <= Time.time )
        {
            direcao = direcao *-1;
            tempo = Time.time + delay;
        }                           
    }
}
