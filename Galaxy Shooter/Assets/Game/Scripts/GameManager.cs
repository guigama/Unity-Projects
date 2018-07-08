using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool isCoopMode = false;
    public bool gameOver = true;
    public bool isGamePaused = false;

    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject _coopPlayers;

    [SerializeField]
    private GameObject _pauseMenuPanel;

    private UIManager _uiManager;
    private SpawnManager _spawnManager;

    private Animator _PauseAnimator;

	// Use this for initialization
	void Start () {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _PauseAnimator = GameObject.Find("Pause_Menu_Panel").GetComponent<Animator>();
        _PauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
	}

    void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(isCoopMode == false)
                {
                    Instantiate(Player, new Vector3(0, 0, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(_coopPlayers, new Vector3(0, 0, 0), Quaternion.identity);
                }
                
                gameOver = false;
                _uiManager.HideTitleScreen();
                _spawnManager.StartSpawnRoutines();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main_Menu");
            }
        }


        
        if (Input.GetKeyDown(KeyCode.P))
        {

            isGamePaused = true;
            _pauseMenuPanel.SetActive(true);
            _PauseAnimator.SetBool("IsPaused", true);
            Time.timeScale = 0;
        }


    }

    public void ResumeGame()
    {
        isGamePaused = false;
        _pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }


}
