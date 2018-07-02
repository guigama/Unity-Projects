using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool gameOver = true;
    public GameObject player;

    private UImanager _UImanager;

    private void Start()
    {
        _UImanager = GameObject.Find("Canvas").GetComponent<UImanager>();
    }

    void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, new Vector3(0,0,0), Quaternion.identity);
                gameOver = false;
                _UImanager.HideTitleScreen();
            }
        }
    }
}
