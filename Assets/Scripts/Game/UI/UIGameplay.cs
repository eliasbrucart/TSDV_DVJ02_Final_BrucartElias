using UnityEngine;

public class UIGameplay : MonoBehaviour
{
    private GameManager gm;
    private ScenesManager sc;
    void Start()
    {
        gm = GameManager.instanceGameManager;
        sc = ScenesManager.instanceScenesManager;
    }

    void Update()
    {
        
    }

    public void PauseGame()
    {
        if(Time.timeScale == 1)
        {
            sc.ChangeSceneAdditive("Pause");
            Time.timeScale = 0;
        }
    }
}
