using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private BoxCollider2D groundCollider;
    private float spawnPosX;
    private float spawnPosY;
    private float halfHeight;
    private float halfWidth;
    
    private void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
        spawnPosX = halfWidth + 2f;
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while(true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(2.5f);
        }
    }

    private void SpawnObstacle()
    {
        GameObject obj = Instantiate(obstaclePrefab, new Vector3(spawnPosX, groundCollider.bounds.max.y, 0), Quaternion.identity);
        float halfHeight = obj.GetComponent<BoxCollider2D>().bounds.size.y / 2f;
        obj.transform.position = new Vector3(spawnPosX, groundCollider.bounds.max.y + halfHeight, 0);
        obj.GetComponent<Obstacle>().Init(gameManager);
    }
}
