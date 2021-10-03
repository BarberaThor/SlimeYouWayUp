using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool gameover;

    public Text win;
    public Text timebeaten;
    public Text timer;
    public Text retry;
    public float t;
    public GameObject player;
    int t2;

    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            if (timer.gameObject.activeInHierarchy)
                timer.gameObject.SetActive(false);
            else
                timer.gameObject.SetActive(true);
        }

        if (gameover)
        {
            win.text = "YOU DID IT!!";
            timebeaten.text = "YOU ENDED THE GAME IN " + t2 + " SECONDS!";
            retry.text = "PRESS 'BACKSPACE' TO PLAY AGAIN! ";

            if (Input.GetKeyDown("backspace"))
            {
                gameover = false;
                t = 0;
                t2 = 0;
                player.transform.position = new Vector3(90, -5, 0);
                win.text = "";
                timebeaten.text = "";
                retry.text = "";
            }
        }
        else
        {
            t += Time.deltaTime;
            t2 = (int)t;
            timer.text = t2 + "";
        }

    }

    public void Finish()
    {
        gameover = true;
    }
}
