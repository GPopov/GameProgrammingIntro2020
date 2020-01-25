using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public string TagToHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagToHit))
        {
            DamageReceiver receiver = collision.gameObject.GetComponent<DamageReceiver>();
            if (receiver)
            {
                receiver.ReceiveHit(gameObject);
            }
        }
    }
}
