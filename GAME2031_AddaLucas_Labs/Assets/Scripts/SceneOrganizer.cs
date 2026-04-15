using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneOrganizer : MonoBehaviour
{
    public static SceneOrganizer Instance;

    private int oldScore;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RegisterButtons();
    }

    public void RegisterButtons()
    {
        Button playButton = GameObject.Find("PlayButton")?.GetComponent<Button>();
        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(OnPlayPressed);
        }

            Button exitButton = GameObject.Find("ExitButton")?.GetComponent<Button>();
        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(OnExitPressed);
        }
    }

    void OnPlayPressed()
    {
        Debug.Log("Play button pressed");
        SceneManager.LoadScene("GameScene");
    }

    void OnExitPressed()
    {
        Debug.Log("Exit button pressed");
        SceneManager.LoadScene("MainMenu");
    }

    public void SetPreviousScore(int prevScore)
    {
        oldScore = prevScore;
    }

    public int GetPreviousScore()
    {
        return oldScore;
    }
}
