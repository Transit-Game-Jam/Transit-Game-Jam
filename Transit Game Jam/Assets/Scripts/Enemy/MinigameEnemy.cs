using UnityEngine;
using Random = UnityEngine.Random;

public class MinigameEnemy : MonoBehaviour
{
    public PlayerController player;
    public float speed = 5f;
    private Vector2 direction;
    private Vector2[] startDirection = { Vector2.down, Vector2.left, Vector2.right, Vector2.up };
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = FindFirstObjectByType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        int randomIndex = Random.Range(0, startDirection.Length);
        direction = startDirection[randomIndex];
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        rb.linearVelocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        float randomX = Random.Range(0.1f, 1f);
        float randomY = Random.Range(0.1f, 1f);

        if (collision.transform.CompareTag("Player"))
        {
            player.playerHealth -= 1f;
            Debug.Log(player.playerHealth);
        }
        else if (collision.contactCount > 0)
        {
            direction = collision.GetContact(0).normal + new Vector2(randomX, randomY);
            Debug.Log(direction);
        }
    }
}
