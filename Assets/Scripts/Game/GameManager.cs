using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public float time;
    public int destroyedBoxes;
    public float distance;

    [SerializeField] private int scorePerBox;

    static public GameManager instanceGameManager;
    static public GameManager Instance { get { return instanceGameManager; } }

    private void Awake()
    {
        if (instanceGameManager != this || instanceGameManager != null)
            Destroy(this.gameObject);
        else
            instanceGameManager = this;
        DontDestroyOnLoad(gameObject);
    }

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
