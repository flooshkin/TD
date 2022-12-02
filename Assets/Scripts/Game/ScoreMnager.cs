using UnityEngine;
using UnityEngine.UI;

public class ScoreMnager : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text HighScoreText;

    public static float score;
    private int highScore;
    
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        highScore = (int) score;
        ScoreText.text = "SCORE: " + highScore.ToString();
        if(PlayerPrefs.GetInt("score") <= highScore)
            PlayerPrefs.SetInt("score", highScore);

        HighScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("score").ToString();
    }
}
