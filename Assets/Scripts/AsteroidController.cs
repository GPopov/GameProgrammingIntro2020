using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float MinSpeed = 0.5f;
    public float MaxSpeed = 1.5f;
    public float MinAngularSpeed = 0.5f;
    public float MaxAngularSpeed = 1.2f;
    void Start()
    {
        Vector2 randomVelocity = Random.insideUnitCircle * Random.Range(MinSpeed, MaxSpeed);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(randomVelocity.x, 0, randomVelocity.y);
        rb.angularVelocity = Random.insideUnitSphere * Random.Range(MinAngularSpeed, MaxAngularSpeed);
    }
}
