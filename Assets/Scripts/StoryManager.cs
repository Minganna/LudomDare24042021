using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    GameObject MenuItem;
    public List<GameObject> story = new List<GameObject>();
    int counter=0;
    public AudioSource ass;
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
            if (MenuItem.name == "Next")
            {
                
                if (Input.GetMouseButtonDown(0))
                {
                    if(counter < story.Count)
                    {
                        story[counter].SetActive(true);
                        counter += 1;
                        ass.Play(); 
                    }
                    else
                    {
                        SceneManager.LoadScene(2);
                    }
                }
               

            }
            else
            {
               
                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene(2);
                }
            }
        }
    }
}
