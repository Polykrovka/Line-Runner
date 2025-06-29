using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {

        transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);

        if (transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }
}
