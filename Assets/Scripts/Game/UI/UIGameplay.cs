using TMPro;
using UnityEngine;

public class UIGameplay : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timeText;

    private GameManager gm;

    void Start()
    {
        gm = GameManager.instanceGameManager;
    }

    void Update()
    {
        scoreText.text = "Score: " + gm.score;
        timeText.text = "Time: " + gm.time.ToString("F0");
    }
}
