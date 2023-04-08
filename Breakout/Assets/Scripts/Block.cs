using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hits = 1;
    public int scoreValue = 100;

    GameController gameController;

    public AudioClip OnBreackAudio;
    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }
    public void OnHit()
    {
        hits--;

        if (hits <= 0)
        {
            gameController.AddScore(scoreValue);
            gameController.AudioController.PlayClip(OnBreackAudio);
            Instantiate(gameController.ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
