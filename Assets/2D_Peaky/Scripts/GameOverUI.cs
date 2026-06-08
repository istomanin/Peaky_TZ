using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private PlayerInteraction playerInteraction;


    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        playerInteraction.PlayerMovement.DisableMovement();


    }

    public void RestartGame()
    {
        playerInteraction.SaveHistory();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
