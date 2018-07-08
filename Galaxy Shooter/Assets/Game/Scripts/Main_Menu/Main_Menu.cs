using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {

    public void LoadSinglePlayerGame()
    {
        Debug.Log("Single player on");
        SceneManager.LoadScene("Single_player");
    }

    public void CoOpGame()
    {
        Debug.Log("Co-op player on");
        SceneManager.LoadScene("Co-Op_Mode");

    }




}
