using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{

    GameObject MenuItem;
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            MenuItem = hit.collider.gameObject;
            if (MenuItem.name == "Back")
            {
                if (Input.GetMouseButtonDown(0))
                {
                        SceneManager.LoadScene(0);
                }
            }
        }
        else
        {
            MenuItem = null;
        }
    }
}
