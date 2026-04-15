using UnityEngine;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] TMP_Text previousScoreText;
    [SerializeField] GameObject mainMenuParent;
    [SerializeField] GameObject rulesParent;

    void Start()
    {
        int score = SceneOrganizer.Instance.GetPreviousScore();
        previousScoreText.text = $"Previous Score: {score}";

        mainMenuParent.SetActive(true);
        rulesParent.SetActive(false);
    }

    public void OpenMainMenu()
    {
        mainMenuParent.SetActive(true);
        rulesParent.SetActive(false);
    }

    public void OpenRulesMenu()
    {
        mainMenuParent.SetActive(false);
        rulesParent.SetActive(true);
    }
}
