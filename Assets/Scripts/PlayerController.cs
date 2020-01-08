using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed = 0.1f;
    // Update is called once per frame
    void Update()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        float depth = Camera.main.transform.position.y - transform.position.y;
        Vector3 mouseScreenSpacePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth);
        Vector3 mouseWorldSpacePos = Camera.main.ScreenToWorldPoint(mouseScreenSpacePos);
        transform.LookAt(mouseWorldSpacePos);

        Vector3 displacement = new Vector3(horizontalAxis, 0, verticalAxis) * Time.deltaTime * PlayerSpeed;
        displacement = transform.rotation * displacement;
        transform.position += displacement;
    }
}
