using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator player;
    public Transform Cookie;
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
        }
    }
    public void ChangeIdleState2()
    {
        
        if (Monster.BiscuitState[nextbiscuit] == 1)
        {
            player.SetInteger("state", 2);
            ReachedDestination = true;
        }
    }
    public void ChangeIdleState3()
    {
       
        if (Monster.BiscuitState[nextbiscuit] == 2)
        {
            player.SetInteger("state", 3);
            ReachedDestination = true;
        }
        Cookie.gameObject.SetActive(false);
        Cookie3.SetActive(true);


    }

    public void BackToNormal()
    {
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
    }




    
}
