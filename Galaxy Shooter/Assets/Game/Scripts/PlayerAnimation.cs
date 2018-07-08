using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnimation : MonoBehaviour {

    private Animator _anim;
    private Player _player;

	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>();
        _player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        if(_player.isplayerOne == true)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _anim.SetBool("Turn_Left", true);
                _anim.SetBool("Turn_Right", false);
            }

            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                _anim.SetBool("Turn_Left", false);
                _anim.SetBool("Turn_Right", false);
            }

            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                _anim.SetBool("Turn_Right", true);
                _anim.SetBool("Turn_Left", false);
            }

            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                _anim.SetBool("Turn_Right", false);
                _anim.SetBool("Turn_Left", false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                _anim.SetBool("Turn_Left", true);
                _anim.SetBool("Turn_Right", false);
            }

            else if (Input.GetKeyUp(KeyCode.Keypad4))
            {
                _anim.SetBool("Turn_Left", false);
                _anim.SetBool("Turn_Right", false);
            }

            else if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                _anim.SetBool("Turn_Right", true);
                _anim.SetBool("Turn_Left", false);
            }

            else if (Input.GetKeyUp(KeyCode.Keypad6))
            {
                _anim.SetBool("Turn_Right", false);
                _anim.SetBool("Turn_Left", false);
            }
        }

        

    }
}
