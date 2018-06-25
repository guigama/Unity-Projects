 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private float _fireRate = 0.25f;

    private float _canFire = 0.0f;     

    [SerializeField]
    private float _speed = 5.0f;

	// Use this for initialization
	void Start () {
        Debug.Log("Hello World");
        transform.position = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {

        Movement();

        Shoot();


	}

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (Time.time > _canFire)
            {
                Instantiate(_laserPrefab, transform.position +
                new Vector3(0, 0.9f, 0), Quaternion.identity);

                _canFire = Time.time + _fireRate;
            }

        }
    }


    private void Movement()
    {
        //setting up player movements
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * _speed * verticalInput);


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
}
