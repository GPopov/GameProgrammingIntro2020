using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public GameObject DestructionFx;
    public float DestructionFXTimeToLive = 4;
    public GameObject ObjectToSpawnOnDeath;
    public float SpawnDistance = 2;
    public float DeflectionAngle = 45;
    public bool DebugDraw = false;
    public uint ScoreOnDeath = 5;

    public void ReceiveHit(GameObject damageDealer)
    {
        if (ObjectToSpawnOnDeath != null)
        {
            Vector3 hitDirection = transform.position - damageDealer.transform.position;
            hitDirection.Normalize();

            if (DebugDraw)
            {
                Debug.DrawLine(damageDealer.transform.position, transform.position, Color.red, 2.0f);
            }
            SpawnDeathObject(hitDirection, -DeflectionAngle);
            SpawnDeathObject(hitDirection, DeflectionAngle);
        }

        GameObject fx = Instantiate(DestructionFx, transform.position, transform.rotation);
        Destroy(fx, DestructionFXTimeToLive);
        Destroy(gameObject);
        GameStateController.Instance.IncrementPlayerScore(ScoreOnDeath);
    }
    private void SpawnDeathObject(Vector3 hitDirection, float angle)
    {
        Vector3 spawnDirection = Quaternion.AngleAxis(angle, Vector3.up) * hitDirection;
        Vector3 spawnPosition = transform.position + spawnDirection * SpawnDistance;
        if (DebugDraw)
        {
            Debug.DrawLine(transform.position, spawnPosition, Color.green, 2.0f);
        }

        GameObject spawnedObject = Instantiate(ObjectToSpawnOnDeath, spawnPosition, Random.rotation);
        var asteroidMovementController = spawnedObject.GetComponent<AsteroidController>();
        if (asteroidMovementController)
        {
            asteroidMovementController.InitialDirection = spawnDirection;
        }
    }
}
