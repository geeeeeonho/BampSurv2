using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false; // 정적 변수로 전역 상태 관리
    public GameObject pauseMenuCanvas; // UI 패널 (예: EscPanel)

    void Start()
    {
        // 시작 시 패널이 꺼져 있도록 설정
        if (pauseMenuCanvas != null)
            pauseMenuCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        if (pauseMenuCanvas != null)
            pauseMenuCanvas.SetActive(false);

        Time.timeScale = 1f; // 시간 다시 흐르게
        GameIsPaused = false;
    }

    public void Pause()
    {
        if (pauseMenuCanvas != null)
            pauseMenuCanvas.SetActive(true);

        Time.timeScale = 0f; // 시간 정지
        GameIsPaused = true;
    }
}