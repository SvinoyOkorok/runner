using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float destroyDistance = -20f;
    private GameManager gameManager;

    private void Update()
    {
        MoveObstacle();
        DestroyObstacle();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameManager.Lose();
        }
    }

    public void Init(GameManager manager)
    {
        gameManager = manager;
    }

    private void MoveObstacle()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void DestroyObstacle()
    {
        if(transform.position.x <= destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
