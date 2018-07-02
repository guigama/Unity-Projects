using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spanw_manager : MonoBehaviour {

    [SerializeField]
    private GameObject enemyShipPrefab;
    [SerializeField]
    private GameObject[] powerups;

    private GameManager _gameManager;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
	
    public void StartSpawnRoutines()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());
    }

	IEnumerator EnemySpawnRoutine()
    {
        Debug.Log("Antes do while: " + _gameManager.gameOver);
        while (_gameManager.gameOver == false)
        {
            
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
        Debug.Log("Depois do while: " + _gameManager.gameOver);
    }

    IEnumerator PowerupSpawnRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            int randomPowerup = Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(10.0f);
        }
    }
}
