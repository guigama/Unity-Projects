 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool canTripleShot = false;
    public bool speedBoostActive = false;
    public bool shieldActive = false;
    public int lives = 3;


    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShotPrefab;

    [SerializeField]
    private float _fireRate = 0.25f;

    [SerializeField]
    private GameObject _explosionPrefab;

    [SerializeField]
    private GameObject _shieldGameObject;

    private float _canFire = 0.0f;     

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private GameObject[] _engines;

    

    private UImanager _UImanager;
    private GameManager _gameManager;
    private Spanw_manager _spawnManager;
    private AudioSource _audioSource;

    private int hitCount = 0;


	// Use this for initialization
	void Start () {
        
        transform.position = new Vector3(0, 0, 0);

        _UImanager = GameObject.Find("Canvas").GetComponent<UImanager>();
        if(_UImanager != null)
        {
            _UImanager.UpdateLives(lives);
        }

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _spawnManager = GameObject.Find("Spanw_manager").GetComponent<Spanw_manager>();
        if(_spawnManager != null)
        {
            _spawnManager.StartSpawnRoutines();
        }

        _audioSource = GetComponent <AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        Movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
        }

        hitCount = 0;
            
	}

    //shotting =====================================
    private void Shoot()
    {
        if (Time.time > _canFire)
        {
            _audioSource.Play();
            if (canTripleShot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
                
            }
            else
            {
                Instantiate(_laserPrefab, transform.position +
                    new Vector3(0, 0.9f, 0), Quaternion.identity);
            }

            _canFire = Time.time + _fireRate;
        }
    }

    //movement===================================

    private void Movement()
    {
        //setting up player movements
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (speedBoostActive == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * _speed * 2 *horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * _speed * 2 *verticalInput);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * _speed * verticalInput);
        }

        
        //setting up horizontal boundaries
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        //setting up vertical boundaries
        if (transform.position.x > 9.3f)
        {
            transform.position = new Vector3(-9.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.3f)
        {
            transform.position = new Vector3(9.3f, transform.position.y, 0);
        }
    }

    //Damage top the player on colison =======================

    public void Damage()
    {
        
        if(shieldActive == true)
        {
            shieldActive = false;
            _shieldGameObject.SetActive(false);
            return;
        }

        hitCount++;

        if (hitCount == 1)
        {
            _engines[0].SetActive(true);
        }
        else if (hitCount == 2)
        {
            _engines[1].SetActive(true);
        }

        lives--;
        _UImanager.UpdateLives(lives);

        if (lives < 1)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _gameManager.gameOver = true;
            Debug.Log("Deve ser true: " +_gameManager.gameOver);
            _UImanager.ShowTitleScreen();
            Destroy(this.gameObject);
        }

    }

    //Power Ups ====================================

    public void ShieldOn()
    {
        shieldActive = true;
        _shieldGameObject.SetActive(true);
    }
    
    public void TripleShotPowerOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }

    public void SpeedBosterOn()
    {
        speedBoostActive = true;
        StartCoroutine(SpeedBosterDownRoutine());
    }

    public IEnumerator SpeedBosterDownRoutine()
    {
        yield return new WaitForSeconds(10.0f);
        speedBoostActive = false;
    }


}


