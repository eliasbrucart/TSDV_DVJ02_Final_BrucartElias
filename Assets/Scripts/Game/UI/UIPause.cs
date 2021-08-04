using UnityEngine;

public class UIPause : MonoBehaviour
{
    private ScenesManager sc;
    public GameObject pauseGO;
    void Start()
    {
        sc = ScenesManager.instanceScenesManager;
    }

    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            pauseGO.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseGO.SetActive(false);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        sc.ChangeScene("Menu");
    }
}
