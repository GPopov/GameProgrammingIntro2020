using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float MinSpeed = 0.5f;
    public float MaxSpeed = 1.5f;
    public float MinAngularSpeed = 0.5f;
    public float MaxAngularSpeed = 1.2f;
    public Vector3 InitialDirection = Vector3.zero;
    void Start()
    {
        if (InitialDirection.sqrMagnitude < Mathf.Epsilon)
        {
            Vector2 randomVelocity = Random.insideUnitCircle;
            InitialDirection = new Vector3(randomVelocity.x, 0, randomVelocity.y);
        }
        Debug.DrawRay(transform.position, InitialDirection, Color.red, 2.0f);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = InitialDirection * Random.Range(MinSpeed, MaxSpeed);
        rb.angularVelocity = Random.insideUnitSphere * Random.Range(MinAngularSpeed, MaxAngularSpeed);
    }
}
