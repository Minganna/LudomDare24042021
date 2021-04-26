using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MonsterManager : MonoBehaviour
{
    public List<int> BiscuitState = new List<int>();
    Player player;
    public int numberOfBiscuit = 2;
    public Slider slider;
    public List<bool> CookieCoorect = new List<bool>();
    public AudioSource audios;
    public List<Sprite> CookiesSprites;
    public List<SpriteRenderer> CookieRenderes;
    public int TurnSurvived = 0;
    public TextMeshProUGUI HighScore;
    public AudioSource Bite;
    public AudioSource Trombone;
    public List<SpriteRenderer> CheckMark=new List<SpriteRenderer>();
    public List<Sprite> CorrectOrWrong=new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<Player>();
        BiscuitState[0] = 0;
        BiscuitState[1] = 1;
        BiscuitState[2] = 2;
        CookieCoorect[0] = false;
        CookieCoorect[1] = false;
        CookieCoorect[2] = false;
        CookieRenderes[0].sprite = CookiesSprites[0];
        CookieRenderes[1].sprite = CookiesSprites[1];
        CookieRenderes[2].sprite = CookiesSprites[2];
        HighScore.text = "Cookie Rounds Score: " + TurnSurvived;


    }

    // Update is called once per frame
    void Update()
    {
        if(BiscuitState[player.nextbiscuit]==0)
        {
            slider.maxValue = 0.1f;
        }
        if (BiscuitState[player.nextbiscuit] == 1)
        {
            slider.maxValue = 0.2f;
        }
        if (BiscuitState[player.nextbiscuit] == 2)
        {
            slider.maxValue = 0.3f;
        }
    }

    public void CorrectAnswer()
    {
        CheckMark[player.nextbiscuit].gameObject.SetActive(true);
        CheckMark[player.nextbiscuit].sprite=CorrectOrWrong[0];
        Bite.Play();
        CookieCoorect[player.nextbiscuit] = true;
        this.GetComponent<Animator>().SetBool("Angry", false);
        this.GetComponent<Animator>().SetBool("Happy",true);
    }

    public void WrongAnswer()
    {
        CheckMark[player.nextbiscuit].gameObject.SetActive(true);
        CheckMark[player.nextbiscuit].sprite = CorrectOrWrong[1];
        Trombone.Play();
        CookieCoorect[player.nextbiscuit] = false;
        this.GetComponent<Animator>().SetBool("Happy", false);
        this.GetComponent<Animator>().SetBool("Angry", true);
    }

    public void CheckForVictory()
    {
        TurnSurvived += 1;
        HighScore.text = "Cookie Rounds Score: " + TurnSurvived;
        this.GetComponent<Animator>().SetBool("Angry", false);
        this.GetComponent<Animator>().SetBool("Happy", false);
        int VictoryCount=0;
        foreach(bool gotit in CookieCoorect)
        {
            if(gotit)
            {
                VictoryCount += 1;
            } 
        }
        for(int i=0;i<CookieCoorect.Count;i++)
        {
            CookieCoorect[i] = false;
        }

        if (VictoryCount==3)
        {
            if(audios.pitch > 0.8)
            {
                audios.pitch -= 0.1f;
            }
        }
        else
        {
            if(audios.pitch<1)
            {
                audios.pitch = 1;
            }
            else
            {
                audios.pitch += 0.1f;
            }
                        
        }
        if(audios.pitch>1.2f)
        {
            FindObjectOfType<SyncedSlider>().GameOver = true;
            SceneManager.LoadScene(3);

        }
        else
        {
            RestartGame();
        }
       

    }

    void RestartGame()
    {
        FindObjectOfType<Player>().nextbiscuit = 0;
        FindObjectOfType<Player>().KeyReleased = false;
            for (int i = 0; i < BiscuitState.Count; i++)
            {
                CheckMark[i].gameObject.SetActive(false);
                int Rand = Random.Range(0, 2);
                BiscuitState[i] = Rand;
                CookieRenderes[i].sprite = CookiesSprites[Rand];
            }

    }

}
