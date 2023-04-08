using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float MoveSpeed;

    public void Move(Vector2 direction)
    {
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
}
