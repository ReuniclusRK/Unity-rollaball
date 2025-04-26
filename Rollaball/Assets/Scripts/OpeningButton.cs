using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningButton : MonoBehaviour
{
    //　スタートボタンを押したら実行する
    public void StartGame()
    {
        Debug.Log(PlayerPrefs.GetInt("TOTAL SCORE", 0));

        PlayerPrefs.SetInt("TOTAL SCORE", 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene("MiniGame");
    }
}