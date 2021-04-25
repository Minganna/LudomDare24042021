using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator player;
    public Transform Cookie;
    public GameObject Cookie1;
    public GameObject Cookie2;
    public GameObject Cookie3;
    public MonsterManager Monster;
    public bool KeyReleased=false;
    public bool ReachedDestination=false;
    public int nextbiscuit=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(KeyReleased&&ReachedDestination)
        {
            player.SetBool("PlayerStretch", false);

        }
    }

    public void ChangeIdleState1()
    {
        
        if(Monster.BiscuitState[nextbiscuit] ==0)
        {
            player.SetInteger("state", 1);
            ReachedDestination = true;
            Cookie.gameObject.SetActive(false);
            Cookie1.SetActive(true);
        }
    }
    public void ChangeIdleState2()
    {
        
        if (Monster.BiscuitState[nextbiscuit] == 1)
        {
            player.SetInteger("state", 2);
            ReachedDestination = true;
            Cookie.gameObject.SetActive(false);
            Cookie2.SetActive(true);
        }
    }
    public void ChangeIdleState3()
    {
       
        if (Monster.BiscuitState[nextbiscuit] == 2)
        {
            player.SetInteger("state", 3);
            ReachedDestination = true;
            Cookie.gameObject.SetActive(false);
            Cookie3.SetActive(true);
        }
        


    }

    public void BackToNormal()
    {
        FindObjectOfType<SyncedSlider>().CanStretch = true;
        KeyReleased = false;
        ReachedDestination = false;
        player.SetBool("PlayerStretch", false);
        player.SetInteger("state", 0);
        Cookie.gameObject.SetActive(true);


    }

    public void DeactivateTempCookie()
    {
        if(Cookie3.activeSelf)
        {
            Cookie3.SetActive(false);
        }
        if(Cookie2.activeSelf)
        {
            Cookie2.SetActive(false);
        }
        if (Cookie1.activeSelf)
        {
            Cookie1.SetActive(false);
        }

    }




    
}
