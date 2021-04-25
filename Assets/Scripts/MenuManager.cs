using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    GameObject MenuItem;
    public List<Sprite>menuSprites=new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            MenuItem = hit.collider.gameObject;
            if(MenuItem.name== "Play")
            {
                MenuItem.GetComponent<SpriteRenderer>().sprite = menuSprites[0];
                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene(1);
                }

            }
            else
            {
                MenuItem.GetComponent<SpriteRenderer>().sprite = menuSprites[3];
                if (Input.GetMouseButtonDown(0))
                {
                    Application.Quit();
                }
            }
        }
        else
        {
            if(MenuItem)
            {
                if (MenuItem.name == "Play")
                {
                    MenuItem.GetComponent<SpriteRenderer>().sprite = menuSprites[1];
                }
                else
                {
                    MenuItem.GetComponent<SpriteRenderer>().sprite = menuSprites[2];
                }
            }
           
        }
    }
}
