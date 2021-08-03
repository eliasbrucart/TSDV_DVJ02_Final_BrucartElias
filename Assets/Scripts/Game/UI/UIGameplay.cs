using TMPro;
using UnityEngine;

public class UIGameplay : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timeText;

    private GameManager gm;
    private ScenesManager sc;
    void Start()
    {
        gm = GameManager.instanceGameManager;
        sc = ScenesManager.instanceScenesManager;
    }

    void Update()
    {
        scoreText.text = "Score: " + gm.score;
        timeText.text = "Time: " + gm.time.ToString("F0");
    }

    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            sc.ChangeSceneAdditive("Pause");
            Time.timeScale = 0;
        }
    }
}
