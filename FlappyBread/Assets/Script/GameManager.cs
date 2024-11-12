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
    public float delay4;
    public float tempoParaGerar2;
    public float tempoParaGerar4;
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
    public float speedP = 1;

    public bool isGamePaused;

    public AudioSource gMaudio;
    public AudioClip musFundo;

    public TextMeshProUGUI pontuacaoCanvas;
    public TextMeshProUGUI pontuacaoCanvasGameOver;

    public float delayPause;
    public float timeimagePause;
    public TextMeshProUGUI timeimagePausetxt;
    public GameObject delayimage;

    public int HighScore;
    public TextMeshProUGUI HighScoreCanvasGameOver;


    public GameObject escudoobj;

    //public InputField playerName;
    

    // Start is called before the first frame update
    void Start()
    {

        gMaudio = GetComponent<AudioSource>();
        //tempoParaGerar = Time.time + delay;
        tempoParaGerar2 = Time.time + delay2;
        tempoParaGerar4 = Time.time + delay4;
        tempoParaGerar3 = Time.time + delay3;
        
         //alt isso
    } 

    // Update is called once per frame
    void Update()
    {

        timeimagePause = delayPause - Time.time;
        pontuacaoCanvas.text = pontuacao.ToString();// + "/10";
        pontuacaoCanvasGameOver.text = pontuacao.ToString();
        HighScoreCanvasGameOver.text = HighScore.ToString();
        timeimagePausetxt.text = timeimagePause.ToString();

        if (isGameOver == true)
        {
            StartCoroutine("GameOver");
            GameOverSceneBttn.SetActive(true);
            pontuacaoimage.SetActive(false);
            pauseBttn.SetActive(false);
            
            gMaudio.Stop();
        }
        else
        {
            GameOverSceneBttn.SetActive(false);
            pontuacaoimage.SetActive(true);
            pauseBttn.SetActive(true);
            //gMaudio.Play();
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

        //GetComponent<Salvar>().CheckForHighScore(pontuacao, playerName.text);




        delay3 = Random.Range(4, 8);

        if (tempoParaGerar2 <= Time.time && isGameOver == false && isGamePaused == false && delayPause <= Time.time)
        {
            Instantiate(manteiga, new Vector3(19, Random.Range(-2, 2),0), Quaternion.identity);
            tempoParaGerar2 = Time.time + delay2;
        }if (tempoParaGerar4 <= Time.time && isGameOver == false && isGamePaused == false && delayPause <= Time.time)
        {
            Instantiate(escudoobj, new Vector3(19, Random.Range(-2, 2),0), Quaternion.identity);
            tempoParaGerar4 = Time.time + delay4;
        }
        

            if (tempoParaGerar <= Time.time && isGameOver == false && isGamePaused == false && delayPause <= Time.time)
        {
            Instantiate(enemy[Random.Range(0, enemy.Length)], new Vector3(16, Random.Range(-2,1), 0), Quaternion.identity);
            tempoParaGerar = Time.time + delay;
           
        }
        if(pontuacao >= upHarder)
        {
            speedX+= 0.5f;
            speedE+= 1.5f;
            speedP+= 0.2f;
            delay3 -= 0.1f;
            delay -= 0.1f;

            upHarder += 1;
            //isGameOver = true;
            
        }
        if (tempoParaGerar3 <= Time.time && isGameOver == false && isGamePaused == false && delayPause <= Time.time)
        {
            Instantiate(garfo, new Vector3(40, Random.Range(-6, 6), 0), Quaternion.identity);
            tempoParaGerar3 = Time.time + delay3;
        }
        if(pontuacao > HighScore)
        {
            SalvarScore();
        }
        

        MostrarScore();


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
    public void SalvarScore()
    {
        PlayerPrefs.SetInt("HighScore", pontuacao);
    }
    public void MostrarScore()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
    }
}
