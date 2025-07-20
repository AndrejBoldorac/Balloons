using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text livesText;
    public int lives = 3;
    public PlayerController playerController;
    public GameObject gameOverText;
    public GameObject resetButton;
    public GameObject playButton;
    public GameObject titleText;
    public GameObject coveringPlane;
    public SpawnManager spawnManager;
    public bool gameOver = false;
    public bool gameInactive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameInactive)
        {
            livesText.text = "Lives: \n" + lives;
            if (lives <= 0)
            {
                gameOver = true;
                gameOverText.SetActive(true);
                resetButton.SetActive(true);
                gameInactive = true;
                spawnManager.spawningActive = false;
            }
        }
    }
    public void OnResetButtonClick()
    {
        gameOver = false;
        lives = 3;
        resetButton.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameInactive = true;
    }
    public void OnPlayButtonClick()
    {
        gameOver = false;
        gameInactive = false;
        playButton.SetActive(false);
        titleText.SetActive(false);
        coveringPlane.SetActive(false);
    }

}
