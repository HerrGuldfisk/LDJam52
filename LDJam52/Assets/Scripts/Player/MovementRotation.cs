using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementRotation : MonoBehaviour
{
    PlayerData playerData;
    public Rigidbody2D rb;

    float rotateDir;

    private void Start()
    {
        rb.angularDrag = 2f;
    }

    void OnRotate(InputValue val)
    {
        rotateDir = val.Get<float>();
    }

    private void Update()
    {
        if (GameManager.Instance.gameState == GameState.Default)
        {
            rb.AddTorque(rotateDir * Time.deltaTime * 100);
        }
    }
}
