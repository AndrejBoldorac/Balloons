using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 15.0f;
    private Rigidbody playerRb;
    private float zBound = 7;
    private float xBound = 16;
    public GameManager gameManager;
    private bool isInvincible = false;
    public AudioSource audioSource;
    public AudioClip[] effects;
    public SpawnManager spawnManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        ConstrainPlayerPosition();
    }
    void MovePlayer()
    {
        if (!gameManager.gameOver && spawnManager.spawningActive)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        }
    }
    void ConstrainPlayerPosition()
    {
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        else if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        if (transform.position.x > xBound)
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        else if (transform.position.x < -xBound)
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !isInvincible)
        {
            if (gameManager.lives == 1)
                audioSource.PlayOneShot(effects[2]); // ded sound effect
            else
                audioSource.PlayOneShot(effects[1]); // hit sound effect
            StartCoroutine(HitCooldown());
            Destroy(other.gameObject);
            gameManager.lives--;
            

        }
        if (other.gameObject.CompareTag("Powerup"))
        {
            audioSource.PlayOneShot(effects[0]); // powerup sound effect
            Collider powerUpCollider = other.GetComponent<Collider>();
            if(powerUpCollider != null)
                powerUpCollider.enabled = false;
            gameManager.lives++;
            Destroy(other.gameObject, 0.1f);
        }
    }
    private IEnumerator HitCooldown()
    {
        isInvincible = true;
        yield return new WaitForSeconds(2f);
        isInvincible = false;
    }
}
