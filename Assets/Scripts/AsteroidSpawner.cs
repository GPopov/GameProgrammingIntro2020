using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    public GameObject AsteroidPrefab;
    public uint AsteroidsCount = 5;
    void Start()
    {
        float depth = Camera.main.transform.position.y - transform.position.y;
        for (uint i = 0; i < AsteroidsCount; ++i)
        {
            Vector3 viewportPos = new Vector3(Random.value, Random.value, depth);
            Vector3 position = Camera.main.ViewportToWorldPoint(viewportPos);
            Instantiate(AsteroidPrefab, position, Random.rotation);
        }
    }


}
