using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float playerYPos;

    private void Start()
    {
        playerYPos = transform.position.y;
    }

    void Update()
    {
        if(GameManager.Instance.gameStarted && Input.GetMouseButtonDown(0))
        {
            PositionSwitch();
        }
    }

    void PositionSwitch()
    {
        playerYPos = -playerYPos;

        transform.position = new Vector3(transform.position.x, playerYPos, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            GameManager.Instance.UpdateLife();
        }
    }
}
