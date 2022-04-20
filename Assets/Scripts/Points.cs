using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    private static int points;
    private static int highScore;
    // private static int highScore;
    public Text pointsText;
    public Text HighScore;
    void Update() {
        points = Food.points;
        highScore = Food.highScore;
        pointsText.text = "Points : " +points;
        HighScore.text = "HighScore : " + highScore;
    }
}
