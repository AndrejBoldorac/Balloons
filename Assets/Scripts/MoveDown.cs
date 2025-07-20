using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5.0f;
    private GameManager gameManager;
    public SpawnManager spawnManager;

    private float zDestroy = -10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((!gameManager.gameOver && spawnManager.spawningActive))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            if (transform.position.z < zDestroy && gameObject.CompareTag("Enemy") || transform.position.z < zDestroy && gameObject.CompareTag("Powerup"))
                Destroy(gameObject);
        }
    }

}
