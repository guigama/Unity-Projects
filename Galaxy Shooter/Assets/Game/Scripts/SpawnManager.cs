using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    private GameObject enemyShipPrefab;
    [SerializeField]
    private GameObject[] powerups;

    private GameManager _gameManager;

	// Use this for initialization
	void Start ()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //StartCoroutine(EnemySpawnRoutine());
        //StartCoroutine(PowerUpsSpawnRoutine());
	}

    public void StartSpawnRoutines()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpsSpawnRoutine());
    }

    IEnumerator EnemySpawnRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            float RandomX = Random.Range(-7f, 7f);
            Instantiate(enemyShipPrefab, new Vector3(RandomX, 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator PowerUpsSpawnRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            int randomPowerup = Random.Range(0, 3);
            float RandomX = Random.Range(-7f, 7f);
            Instantiate(powerups[randomPowerup], new Vector3(RandomX, 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }




}
