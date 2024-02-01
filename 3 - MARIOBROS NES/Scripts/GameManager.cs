using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int lives;
    [SerializeField] private int coins;

    private void Start()
    {
        lives = 3;
        coins = 0;

        Application.targetFrameRate = 60;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(1);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives--;

        if (lives > 0) {
            SceneManager.LoadScene(1);
        } else {
            GameOver();
        }
    }

    public void AddCoin()
    {
        coins++;

        if (coins == 100)
        {
            coins = 0;
            AddLife();
        }
    }

    public void AddLife()
    {
        lives++;
    }
}
