using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyncedSlider : MonoBehaviour
{
    public Slider slider;
    public AudioSource audios;
    private bool damagetaken = false;
    private bool Victory = false;
    private bool keypressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Mathf.Lerp(0, 1, ConductorClass.instance.loopPositionInAnalog);
        if(slider.value<0.1f)
        {
            damagetaken = false;
            Victory = false;
            keypressed = false;

        }
        if (Input.GetKeyDown(KeyCode.UpArrow)&&!keypressed)
        {
            keypressed = true;
            if (slider.value > 0.4f && slider.value < 0.6f && !Victory)
            {
                Victory = true;
                audios.pitch -= 0.05f;
                Debug.Log("point + 1");
            }
        }
        if (slider.value>0.9f&&!damagetaken&&!Victory)
        {
            damagetaken = true;
            audios.pitch += 0.05f;
            Debug.Log("damage+1");


        }
    }
}
