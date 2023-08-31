using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject manteiga;
    public GameObject garfo;
    public bool isGameOver;
    public float delay;
    private float tempoParaGerar;
    public float delay2;
    private float tempoParaGerar2;
    public int pontuacao = 1;
    private float tempoParaGerar3;
    public float delay3;
    public GameObject resumeBttn;

    public int upHarder;
    public float speedX;
    public float speedE;

    public bool isGamePaused;

    public AudioSource gMaudio;

    public TextMeshProUGUI pontuacaoCanvas;

    // Start is called before the first frame update
    void Start()
    {
       

        //tempoParaGerar = Time.time + delay;
        tempoParaGerar2 = Time.time + delay2;
        tempoParaGerar3 = Time.time + delay3;
    } 

    // Update is called once per frame
    void Update()
    {
        pontuacaoCanvas.text = pontuacao.ToString();// + "/10";

        if(isGameOver == true)
        {
            StartCoroutine("GameOver");
        }
        if(isGamePaused == true)
        {
            resumeBttn.SetActive(true);
        }
        else
        {
            resumeBttn.SetActive(false);
        }
        
        
        delay3 = Random.Range(2, 5);

        if (tempoParaGerar2 <= Time.time && isGameOver == false && isGamePaused == false)
        {
            Instantiate(manteiga, new Vector3(19, Random.Range(-2, 2),0), Quaternion.identity);
            tempoParaGerar2 = Time.time + delay2;
        }
        

            if (tempoParaGerar <= Time.time && isGameOver == false && isGamePaused == false)
        {
            Instantiate(enemy[Random.Range(0, enemy.Length)], new Vector3(16, Random.Range(-2,1), 0), Quaternion.identity);
            tempoParaGerar = Time.time + delay;
           
        }
        if(pontuacao >= upHarder)
        {
            speedX++;
            speedE++;
            upHarder = pontuacao + 10;
            //isGameOver = true;
        }
        if (tempoParaGerar3 <= Time.time && isGameOver == false && isGamePaused == false)
        {
            Instantiate(garfo, new Vector3(25, Random.Range(-3, 1.5f), 0), Quaternion.identity);
            tempoParaGerar3 = Time.time + delay3;
        }     
    }

    public void TrocarCena()
    {
        SceneManager.LoadScene(0);
    }
    public void TrocarCena2()
    {       
            SceneManager.LoadScene(1);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);

        TrocarCena2();
    }
    public void pauseGame()
    {
        isGamePaused = true;
    }
    public void volteGame()
    {
        isGamePaused = false;
    }
}
