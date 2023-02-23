using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static private Text _UI_TEXT;
    static private int _SCORE = 1000;

    private Text txtcom;

    void Awake (){
        _UI_TEXT = GetComponent<Text>();

        if (PlayerPrefs.HasKey("Highscore")){
            SCORE = PlayerPrefs.GetInt("Highscore");
        }
        PlayerPrefs.SetInt("Highscore", SCORE);
    }

    static public int SCORE{
        get {return _SCORE;}
        private set {
            _SCORE = value;
            PlayerPrefs.SetInt("Highscore", value);
            if ( _UI_TEXT != null){
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE( int scoreToTry){
        if ( scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
        
    }
    [Tooltip("Check this box to reset the Highscore in PlayerPrefs")]
    public bool resetHighScorenow = false;

    void OnDrawGizmos(){
        if ( resetHighScorenow){
            resetHighScorenow = false;
            PlayerPrefs.SetInt("Highscore", 1000);
            Debug.LogWarning("PlayerPrefs Highscore reset to 1,000");
        }
    }
}
