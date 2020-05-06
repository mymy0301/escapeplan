﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [Header("NamePopup")]
    public NamePopup namePopup;
    [Header("RankPopup")]
    public RankPopup rankPopup;
    public Text LevelText;
    public Text NameText;
    public Text ModeButton;


    public string RateURL, MoreURL;
    // Start is called before the first frame update
    void Start()
    {
        if (namePopup != null)
        {
            namePopup.OnChangeName += OnChangeName;
        }

        //PlayerPrefs.SetInt("Level", 8);
        int CurrentLevel = PlayerPrefs.GetInt("Level", 0);
        LevelText.text = "LEVEL : " + (CurrentLevel+1);

        if (NameText != null)
        {
            NameText.text = "" + Config.GetUserName();
        }

        if(PlayerPrefs.GetString("MODE")== null)
        {
            PlayerPrefs.SetString("MODE", "EASY");
        }
        ModeButton.text = PlayerPrefs.GetString("MODE");
        

        if (PlayerPrefs.GetString("MODE") == "HARD")
        {
            isHard = true;
        }
        else
        {
            isHard = false;
        }
    }


    public void RateUS() {
        Application.OpenURL(RateURL);
    }
  
    public void MoreGames() {
        Application.OpenURL(MoreURL);

    }



    // Update is called once per frame
    void Update()
    {
        
    }
    bool isHard;
    public void StartGame() {
        if (isHard)
        {
            PlayerPrefs.SetString("MODE", "EASY");
            isHard = !isHard;
            ModeButton.text = "EASY";
        }
        else
        {
            PlayerPrefs.SetString("MODE", "HARD");
            isHard = !isHard;
            ModeButton.text = "HARD";
        }
        
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    public void TouchChangeName() {
        ShowPopupChangeName();
    }

    public void ShowPopupChangeName() {
        namePopup.gameObject.SetActive(true);
    }

    public void OnChangeName() {
        NameText.text = "" + Config.GetUserName();
    }

    public void TouchRank() {
        ShowPopupRank();
    }

    public void ShowPopupRank()
    {
        rankPopup.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        if (namePopup != null) {
            namePopup.OnChangeName -= OnChangeName;
        }
    }
}
