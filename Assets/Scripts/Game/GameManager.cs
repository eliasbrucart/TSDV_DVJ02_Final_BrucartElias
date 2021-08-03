using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public float time;
    public int destroyedBoxes;
    public float distance;

    [SerializeField] private int scorePerBox;


    void Start()
    {
        Bomb.CollisionWithBox += AddScore;
    }

    void Update()
    {
        time -= Time.deltaTime;
        OutOfTime();
    }

    private void AddScore()
    {
        score += scorePerBox;
    }

    private void OutOfTime()
    {
        if (time <= 0.0f)
            time = 0.0f;
    }

    private void OnDisable()
    {
        Bomb.CollisionWithBox -= AddScore;
    }
}
