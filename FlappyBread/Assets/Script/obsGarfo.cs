using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsGarfo : MonoBehaviour
{

    
    private GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        



        if ( gM.isGamePaused == false && gM.delayPause <= Time.time)
        {
            transform.position = new Vector3(transform.position.x - gM.speedE * Time.deltaTime, transform.position.y, transform.position.z);
        }


        if (transform.position.x <= -18)
        {
            Destroy(gameObject);
        }
         
    }
}
