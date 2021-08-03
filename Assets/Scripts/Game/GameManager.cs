using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public float time;
    public int destroyedBoxes;
    public float distance;

    public Player player;

    [SerializeField] private int scorePerBox;

    static public GameManager instanceGameManager;
    static public GameManager Instance { get { return instanceGameManager; } }

    private ScenesManager sc;

    private void Awake()
    {
        if (instanceGameManager != this && instanceGameManager != null)
            Destroy(this.gameObject);
        else
            instanceGameManager = this;
        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Bomb.CollisionWithBox += AddScore;
        Bomb.CollisionWithBox += IncreaseDestroyedBoxes;
        sc = ScenesManager.instanceScenesManager;
    }

    void Update()
    {
        time -= Time.deltaTime;
        distance = player.distanceTraveled;
        CheckGameOver();
    }

    private void AddScore()
    {
        score += scorePerBox;
    }

    private void IncreaseDestroyedBoxes()
    {
        destroyedBoxes++;
    }

    private bool OutOfTime()
    {
        if (time <= 0.0f)
        {
            return true;
        }
        return false;

    }

    private void CheckGameOver()
    {
        if (OutOfTime())
            sc.ChangeScene("GameOver");
    }

    private void OnDisable()
    {
        Bomb.CollisionWithBox -= AddScore;
        Bomb.CollisionWithBox -= IncreaseDestroyedBoxes;
    }
}
