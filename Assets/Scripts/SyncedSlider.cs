using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyncedSlider : MonoBehaviour
{
    public Slider slider;
    public Slider CookieSlider;
    public AudioSource audios;
    private bool checkedstatus = false;
    private bool Victory = false;
    private bool keypressed = false;
    public Animator player;
    bool TippingCookie=false;
    public bool CanStretch = true;
    public bool GameOver = false;
    public List<KeyCode> logickey=new List<KeyCode>();
    public Image KeySprite;
    public List<Sprite> KeySp = new List<Sprite>();
    int keychoosed;
    float counter = 0.0f;
    bool considerUp = true;
    // Start is called before the first frame update
    void Start()
    {
        keychoosed = Random.Range(0, logickey.Count);
        KeySprite.sprite = KeySp[keychoosed];
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameOver)
        {
            slider.value = Mathf.Lerp(0, 3, ConductorClass.instance.loopPositionInAnalog);
       
        if(TippingCookie)
        {

           
                Debug.Log(counter);
            CookieSlider.value += 0.1f*Time.deltaTime;
            if(CookieSlider.value== CookieSlider.maxValue)
                {
                    counter += 0.01f * Time.deltaTime;
                    if(counter > 0.02f)
                    {
                        considerUp = false;
                        FindObjectOfType<MonsterManager>().WrongAnswer();
                        TippingCookie = false;
                        counter = 0;
                        CheckUp();
                    }
                    
                }
        }
        else
        {
            
            CookieSlider.value =0.0f;
        }
        if(slider.value<0.1f)
        {
            checkedstatus = false;
            Victory = false;
            keypressed = false;

        }
        StretchingLogic();
        if (slider.value>2.99&&!checkedstatus)
        {
            checkedstatus = true;
            FindObjectOfType<MonsterManager>().CheckForVictory();
        }
        }

    }

    private void StretchingLogic()
    {
        
        if (Input.GetKeyDown(logickey[keychoosed]))
        {
            player.SetBool("PlayerStretch", true);
            TippingCookie = true;
            CanStretch = false;
            considerUp = true;
        }
        if (Input.GetKeyUp(logickey[keychoosed])&&considerUp)
        {
            if (CookieSlider.maxValue - CookieSlider.value < 10 * CookieSlider.maxValue / 100)
            {
                FindObjectOfType<MonsterManager>().CorrectAnswer();
            }
            else
            {
                FindObjectOfType<MonsterManager>().WrongAnswer();
            }
            CheckUp();
        }
    }

    private void CheckUp()
    {
        keychoosed = Random.Range(0, logickey.Count);
        KeySprite.sprite = KeySp[keychoosed];
        
        if (FindObjectOfType<Player>().nextbiscuit < FindObjectOfType<MonsterManager>().numberOfBiscuit)
        {
            FindObjectOfType<Player>().nextbiscuit += 1;
        }
        else
        {
            FindObjectOfType<Player>().nextbiscuit = 0;
        }
        FindObjectOfType<Player>().KeyReleased = true;


        TippingCookie = false;
    }
}
