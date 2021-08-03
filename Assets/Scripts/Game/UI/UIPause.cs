using UnityEngine;

public class UIPause : MonoBehaviour
{
    private ScenesManager sc;
    void Start()
    {
        sc = ScenesManager.instanceScenesManager;
    }

    void Update()
    {
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        sc.UnloadSceneAsy("Pause");
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        sc.ChangeScene("Menu");
    }
}
