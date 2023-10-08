using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;

    [SerializeField] float maxV;
    Vector3 direction;

    void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + (direction * maxV));
    }

    public void SetDirection(Vector3 vector)
    {
        direction = vector;
    }
}
