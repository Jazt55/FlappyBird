using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemy;
    public bool isGameOver;
    public float delay;
    private float tempoParaGerar;

    // Start is called before the first frame update
    void Start()
    {
        tempoParaGerar = Time.time + delay;
    }

    // Update is called once per frame
    void Update()
    {
        delay = Random.Range(2, 5);

        if (tempoParaGerar <= Time.time && isGameOver == false)
        {
            Instantiate(enemy[Random.Range(0, enemy.Length)], new Vector3(16, 0, 0), Quaternion.identity);
            tempoParaGerar = Time.time + delay;
        }
    }
}
