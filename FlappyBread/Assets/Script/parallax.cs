using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public float speed;
    private GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -10.5)
        {
            transform.position = new Vector2(8.1f, transform.position.y);
        }
        if (gM.isGameOver == false && gM.isGamePaused == false && gM.delayPause <= Time.time)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            
        }
        
    }
}
