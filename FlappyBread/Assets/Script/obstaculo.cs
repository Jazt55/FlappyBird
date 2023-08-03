using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculo : MonoBehaviour
{
    public float speedE;
    private GameManager gM;
    
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        

        
        if(gM.isGameOver == false)
        {
            transform.position = new Vector3(transform.position.x - speedE * Time.deltaTime, transform.position.y, transform.position.z);
        }
            

        if(transform.position.x <= -12)
        {
            Destroy(gameObject);
        }

    }
}
