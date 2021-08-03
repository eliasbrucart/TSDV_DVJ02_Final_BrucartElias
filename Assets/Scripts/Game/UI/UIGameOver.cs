using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text destroyedBoxesText;
    public TMP_Text distanceText;

    private GameManager gm;
    void Start()
    {
        gm = GameManager.instanceGameManager;
    }

    void Update()
    {
        scoreText.text = "Score: " + gm.score;
        destroyedBoxesText.text = "Destroyed Boxes: " + gm.destroyedBoxes;
        distanceText.text = "Tank distance traveled: " + gm.distance;
    }
}
