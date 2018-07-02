using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private int powerupID; //0 = tiple shot, 1 = spped boost, 2 = shields

    [SerializeField]
    private AudioClip _clip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);

            if (player != null)
            {
                if(powerupID == 0)
                {
                    player.TripleShotPowerOn();
                }
                else if(powerupID == 1)
                {
                    player.SpeedBosterOn();
                }
                else if(powerupID == 2)
                {
                    player.ShieldOn();
                }
                
            }
            Destroy(this.gameObject);
        }
 
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if(transform.position.y < -8)
        {
            Destroy(this.gameObject);
        }
	}
}
