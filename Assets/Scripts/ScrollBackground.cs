using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position; // (16.5, 0, 11)
        if (gameObject.CompareTag("Plane"))
            repeatWidth = GetComponent<MeshCollider>().bounds.size.z / 2; // 25
        else if (gameObject.CompareTag("Wall"))
        {
            repeatWidth = transform.localScale.z / 2; //

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
