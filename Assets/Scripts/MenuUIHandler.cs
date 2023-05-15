using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerNamePlaceHolder;

    private void Start()
    {
        playerNamePlaceHolder.enabled = false;
        playerNameText.text = GameManager.Instance.playerName;
        playerNameText.SetText(GameManager.Instance.playerName);
    }

    public void StartNew()
    {
        GameManager.Instance.currentPlayerName = playerNameText.text;
        GameManager.Instance.LoadHighScore();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }

}