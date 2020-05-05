using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ItemButtonSelectLevel : MonoBehaviour
{
    public Text txtLevel;
    public int level;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        txtLevel.text = "" + level;
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
}
