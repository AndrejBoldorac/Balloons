using UnityEngine;

public class MusicLogic : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip[] tracks;
    public GameManager gameManager;
    public SpawnManager spawnManager;

    private bool hasSwitchedToGameOverMusic = false;
    private bool isPlayingLoadingMusic = false;
    private bool isPlayingMainMusic = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManager.gameOver && !spawnManager.spawningActive && !isPlayingLoadingMusic)
        {
            isPlayingLoadingMusic = true;
            musicSource.clip = tracks[0];
            musicSource.loop = true;
            musicSource.Play();
        }
        else if (!gameManager.gameOver && spawnManager.spawningActive && !isPlayingMainMusic)
        {
            isPlayingMainMusic = true;
            musicSource.clip = tracks[1];
            musicSource.loop = true;
            musicSource.Play();
        }
        else if (gameManager.gameOver && !hasSwitchedToGameOverMusic && !spawnManager.spawningActive)
        {
            hasSwitchedToGameOverMusic = true;
            musicSource.clip = tracks[2];
            musicSource.loop = false;
            musicSource.Play();
        }
    }
}
