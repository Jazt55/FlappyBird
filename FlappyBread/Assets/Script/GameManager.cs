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
    
    public GameObject pauseSceneBttn;
    public GameObject GameOverSceneBttn;
    public GameObject pontuacaoimage;
    public GameObject pauseBttn;

    public GameObject touchpulo;

    public int upHarder;
    public float speedX;
    public float speedE;

    public bool isGamePaused;

    public AudioSource gMaudio;

    public TextMeshProUGUI pontuacaoCanvas;
    public TextMeshProUGUI pontuacaoCanvasGameOver;

    public float delayPause;
    public float timeimagePause;
    public TextMeshProUGUI timeimagePausetxt;
    public GameObject delayimage;

    // Start is called before the first frame update
    void Start()
    {
       

        //tempoParaGerar = Time.time + delay;
        tempoParaGerar2 = Time.time + delay2;
        tempoParaGerar3 = Time.time + delay3;
        
         //alt isso
    } 

    // Update is called once per frame
    void Update()
    {

        timeimagePause = delayPause - Time.time;
        pontuacaoCanvas.text = pontuacao.ToString();// + "/10";
        pontuacaoCanvasGameOver.text = pontuacao.ToString();
        timeimagePausetxt.text = timeimagePause.ToString();

        if (isGameOver == true)
        {
            StartCoroutine("GameOver");
            GameOverSceneBttn.SetActive(true);
            pontuacaoimage.SetActive(false);
            pauseBttn.SetActive(false);
        }
        else
        {
            GameOverSceneBttn.SetActive(false);
            pontuacaoimage.SetActive(true);
            pauseBttn.SetActive(true);
        }

        if(isGamePaused == true)
        {
            pauseSceneBttn.SetActive(true);
            
            touchpulo.SetActive(false);
        }
        else
        {
            
            pauseSceneBttn.SetActive(false);
            
            touchpulo.SetActive(true);
            
        }
        
        

        

        
        delay3 = Random.Range(4, 8);

        if (tempoParaGerar2 <= Time.time && isGameOver == false && isGamePaused == false && delayPause <= Time.time)
        {
            Instantiate(manteiga, new Vector3(19, Random.Range(-2, 2),0), Quaternion.identity);
            tempoParaGerar2 = Time.time + delay2;
        }
        

            if (tempoParaGerar <= Time.time && isGameOver == false && isGamePaused == false && delayPause <= Time.time)
        {
            Instantiate(enemy[Random.Range(0, enemy.Length)], new Vector3(16, Random.Range(-2,1), 0), Quaternion.identity);
            tempoParaGerar = Time.time + delay;
           
        }
        if(pontuacao >= upHarder)
        {
            speedX++;
            speedE+= 3;
            upHarder += 2;
            //isGameOver = true;
            
        }
        if (tempoParaGerar3 <= Time.time && isGameOver == false && isGamePaused == false && delayPause <= Time.time)
        {
            Instantiate(garfo, new Vector3(25, Random.Range(-3, 1.5f), 0), Quaternion.identity);
            tempoParaGerar3 = Time.time + delay3;
        }     
    }

    public void TrocarCenaInicio()
    {
        SceneManager.LoadScene(0);
    }
    public void TrocarCenaInstrucoes()
    {       
            SceneManager.LoadScene(1);
    }
    public void TrocarCenaGame()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        
        
    }
    public void pauseGame()
    {
        isGamePaused = !isGamePaused;
        
    }
    public void volteGame()
    {
        isGamePaused = false;
        //delayPause = Time.time + 3f;
        
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
