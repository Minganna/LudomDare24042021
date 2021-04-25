using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
    public List<int> BiscuitState = new List<int>();
    Player player;
    public int numberOfBiscuit = 2;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        BiscuitState[0] = 0;
        BiscuitState[1] = 1;
        BiscuitState[2] = 2;


    }

    // Update is called once per frame
    void Update()
    {
        if(BiscuitState[player.nextbiscuit]==0)
        {
            slider.maxValue = 0.2f;
        }
        if (BiscuitState[player.nextbiscuit] == 1)
        {
            slider.maxValue = 0.5f;
        }
        if (BiscuitState[player.nextbiscuit] == 2)
        {
            slider.maxValue = 1.0f;
        }
    }
}
