using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text timerText;
    [SerializeField] GameObject gameOverUI;

    public PlayerController player;

    private int score;
    private int health;
    private float timer;

    public bool isAlive;

    void Start()
    {
        UpdateHealth(player.health);
        UpdateScore(0);
        isAlive = true;
        timer = 30.0f;
        Initialize();
    }

    private void Initialize()
    {
        gameOverUI.SetActive(false);
        SceneOrganizer.Instance.RegisterButtons();
    }

    private void Update()
    {
        if (player.health > 0 && timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F2");
        }

        if (timer <= 0)
        {
            GameOver();
        }
    }

    private void OnEnable()
    {
        player.takeDamage += UpdateHealth;
        player.playerDeath += GameOver;
    }

    private void OnDisable()
    {
        player.takeDamage -= UpdateHealth;
        player.playerDeath -= GameOver;
    }

    public void IncreaseTime()
    {
        timer += 2.0f;
    }

    public void UpdateScore(int newScore)
    {
        this.score = newScore;
        scoreText.text = $"Score: {newScore}";
    }

    public void IncrementScore(int incrementor)
    {
        UpdateScore(this.score + incrementor);
    }

    public void UpdateHealth(int newHealth)
    {
        health = newHealth;
        healthText.text = $"HP: {health}";
    }

    private void GameOver()
    {
        isAlive = false;

        SceneOrganizer.Instance.SetPreviousScore(score);

        Debug.Log($"Final Score: {score}");
        StartCoroutine(GameOverUI());
    }

    IEnumerator GameOverUI()
    {
        yield return new WaitForSeconds(3.0f);
        gameOverUI.SetActive(true);
    }
}
