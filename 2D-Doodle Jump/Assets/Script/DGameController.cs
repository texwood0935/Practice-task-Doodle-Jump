using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DGameController : MonoBehaviour {
    public static DGameController instance;
    public Text scoretext;
    public Text scoretext2;
    public Text highscoretext;
    public int itscore;
    public GameObject GameOverText;                 // game over UI
    public GameObject Playagain;
    public GameObject Highscore;
    public GameObject DPlayer;
    public GameObject Score;
    //public GameObject Play;
    //public DFootPlatePool FPP;
    //public DPlayerController PlayC;

    private bool isGameover = false;
    private int score;
    private int highscore;

    public bool IsGameover
    {
        get { return isGameover; }
        set { isGameover = value; }
    }
    // Use this for initialization
    private void Awake()
    {
        GameOverText.SetActive(false);
        Playagain.SetActive(false);
        Highscore.SetActive(false);
        //HighscoreText.SetActive(false);
        Score.SetActive(false);
        //ScoreText.SetActive(false);
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //Play.SetActive(true);
        //FPP.enabled = false;
        //PlayC.enabled = false;
    }
    void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (isGameover == true )
        {
            Destroy(DPlayer.gameObject, 1);
            GameOver();
            if(DPlayAgain.IsPlayAgain)
            {
                DPlayAgain.IsPlayAgain = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }
        //if(DPlay.isPlay)
        {
            //Play.SetActive(false);
            //FPP.enabled = true;
        }
        scoretext.text = score.ToString();
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag!="UI"&&collision.tag !="Player")
           Destroy(collision.gameObject);
        if(collision.tag=="Player")
           isGameover = true;
        Debug.Log(isGameover.ToString());
    }
    public void Addscore()
    {
        score += itscore;
        Debug.Log(score.ToString());
    }
    public void GameOver()
    {
        GameOverText.SetActive(true);
        Playagain.SetActive(true);
        Highscore.SetActive(true);
        //HighscoreText.SetActive(true);
        Score.SetActive(true);
        //ScoreText.SetActive(true);
        scoretext2.text = score.ToString();
        highscore = WhichIsHighScore(score);
        PlayerPrefs.SetInt("highscore", highscore);
        highscoretext.text = highscore.ToString();
        Destroy(Camera.main.gameObject);
    }
    private int WhichIsHighScore(int score)
    {
        int i;
        if (PlayerPrefs.HasKey("highscore"))
            i = PlayerPrefs.GetInt("highscore") > score ? PlayerPrefs.GetInt("highscore") : score;
        else
            i = score;
        return i;
    }
}
 