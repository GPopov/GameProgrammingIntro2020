using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public GameObject DestructionFx;
    public void ReceiveHit()
    {
        Instantiate(DestructionFx, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
