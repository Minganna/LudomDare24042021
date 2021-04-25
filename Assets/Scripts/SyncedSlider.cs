using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyncedSlider : MonoBehaviour
{
    public Slider slider;
    public Slider CookieSlider;
    public AudioSource audios;
    private bool damagetaken = false;
    private bool Victory = false;
    private bool keypressed = false;
    public Animator player;
    bool TippingCookie=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Mathf.Lerp(0, 1, ConductorClass.instance.loopPositionInAnalog);
        if(TippingCookie)
        {
            CookieSlider.value += 0.1f*Time.deltaTime;
        }
        else
        {
            CookieSlider.value =0.0f;
        }
        if(slider.value<0.1f)
        {
            damagetaken = false;
            Victory = false;
            keypressed = false;

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.SetBool("PlayerStretch", true);
            TippingCookie = true;
            if (slider.value > 0.4f && slider.value < 0.6f && !Victory)
            {
                //Victory = true;
                audios.pitch -= 0.05f;
                //Debug.Log("point + 1");
            }
        }
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            FindObjectOfType<Player>().KeyReleased = true;
            TippingCookie = false;
            if (FindObjectOfType<Player>().nextbiscuit< FindObjectOfType<MonsterManager>().numberOfBiscuit)
            {
                FindObjectOfType<Player>().nextbiscuit += 1;
            }
            else
            {
                FindObjectOfType<Player>().nextbiscuit = 0;
            }
                
        }
        if (slider.value>0.9f&&!damagetaken&&!Victory)
        {
            damagetaken = true;
            audios.pitch += 0.05f;
           // Debug.Log("damage+1");


        }
    }
}
