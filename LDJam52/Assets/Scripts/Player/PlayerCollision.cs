using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerData pd;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        pd.currentHealth -= 10f;
    }
}
