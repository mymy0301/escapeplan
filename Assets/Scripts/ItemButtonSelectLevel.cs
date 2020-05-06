using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ItemButtonSelectLevel : MonoBehaviour
{
    public Text txtLevel;
    public Text txtNextLevel;
    public int level;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        if (txtLevel!=null)
            txtLevel.text = "" + (level);
        if (txtNextLevel != null)
        {
            level = PlayerPrefs.GetInt("Level");
            txtNextLevel.text = "" + (level + 1);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TouchStartGame() {
        PlayerPrefs.SetInt("Level", level-1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("LoadGame");
    }

    public void NextGame()
    {
        level = PlayerPrefs.GetInt("Level");
        PlayerPrefs.SetInt("Level", level);
        if(level < 20)
        {
            SceneManager.LoadScene("LoadGame");
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
        
    }
}
