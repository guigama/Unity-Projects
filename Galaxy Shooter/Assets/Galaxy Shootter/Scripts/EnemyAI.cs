using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private GameObject _enemyExplosion;

    [SerializeField]
    private AudioClip _clip;

    private UImanager _UImanager;
    private AudioSource _audioSource;

    void Start()
    {
        _UImanager = GameObject.Find("Canvas").GetComponent<UImanager>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "Laser")
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
            Instantiate(_enemyExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            _UImanager.UpdateScore();
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(other.gameObject);
            
        }
        else if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
            }

            Instantiate(_enemyExplosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
            

        }
    }

    // Update is called once per frame
    void Update () {

        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -7)
        {
            float randomX = Random.Range(-7, 7);
            transform.position = new Vector3(randomX, 7, 0);
        }
		
	}
}
