using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject manteiga;
    public bool isGameOver;
    public float delay;
    private float tempoParaGerar;
    public float delay2;
    private float tempoParaGerar2;

    // Start is called before the first frame update
    void Start()
    {
        //tempoParaGerar = Time.time + delay;
        tempoParaGerar2 = Time.time + delay2;

    }

    // Update is called once per frame
    void Update()
    {

        //delay = Random.Range(2, 5);
        if (tempoParaGerar2 <= Time.time && isGameOver == false)
        {
            Instantiate(manteiga, new Vector3(19, Random.Range(-2, 2),0), Quaternion.identity);
            tempoParaGerar2 = Time.time + delay2;
        }


            if (tempoParaGerar <= Time.time && isGameOver == false)
        {
            Instantiate(enemy[Random.Range(0, enemy.Length)], new Vector3(16, 0, 0), Quaternion.identity);
            tempoParaGerar = Time.time + delay;
        }
    }
}
