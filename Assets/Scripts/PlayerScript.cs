using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10f;
    private float minX = -2.55f;
    private float maxX = 2.55f;

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 targetPosition = transform.position;

        if (h > 0)
        {
            // Move right
            targetPosition.x += speed * Time.deltaTime;

            if (targetPosition.x > maxX)
            {
                targetPosition.x = maxX;
            }
        }
        else if (h < 0)
        {
            // Move left
            targetPosition.x -= speed * Time.deltaTime;

            if (targetPosition.x < minX)
            {
                targetPosition.x = minX;
            }
        }

        transform.position = targetPosition;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bomb")
        {
            Time.timeScale = 0f; // Pause the game
        }
    }
}
