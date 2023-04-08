using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameObject lastObjectHit;
    CircleCollider2D circleCollider;
    public Vector2 velocity = new Vector2(4, 3);

    GameController gameController;

    public AudioClip OnWallHitAudio;
    public AudioClip OnPaddleHitAudio;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        gameController = FindObjectOfType<GameController>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, circleCollider.radius, velocity, (velocity * Time.deltaTime).magnitude);
        foreach (RaycastHit2D hit in hits)
        {
            if(hit.collider != circleCollider && hit.transform.gameObject != lastObjectHit)
            {
                //Debug.Log("Hit -> " + hit.transform.name);
                lastObjectHit = hit.transform.gameObject;
                velocity = Vector2.Reflect(velocity, hit.normal);

                if (hit.transform.GetComponent<Paddle>())
                {
                    velocity.y = Mathf.Abs(velocity.y);
                    gameController.AudioController.PlayClip(OnPaddleHitAudio);
                }

                if (hit.transform.GetComponent<Block>())
                {
                    hit.transform.GetComponent<Block>().OnHit();
                }

                gameController.AudioController.PlayClip(OnWallHitAudio);
            }
        }

        if(transform.position.y < -Camera.main.orthographicSize)
        {
            gameController.BallLost();
        }
    }
}
