using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed = 0.1f;
    public float MouseDistanceThreshold = 0.15f;
    // Update is called once per frame
    private void Start()
    {
        AsteroidSpawner.Instance.RegisterPlayer(gameObject);
    }
    private void OnDestroy()
    {
        AsteroidSpawner.Instance.UnregisterPlayer(gameObject);
    }
    void Update()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        float depth = Camera.main.transform.position.y - transform.position.y;
        Vector3 mouseScreenSpacePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth);
        Vector3 mouseWorldSpacePos = Camera.main.ScreenToWorldPoint(mouseScreenSpacePos);

        Vector3 displacement = new Vector3(horizontalAxis, 0, verticalAxis) * Time.deltaTime * PlayerSpeed;
        displacement = transform.rotation * displacement;

        float sqrDistanceToMouse = (mouseWorldSpacePos - transform.position).sqrMagnitude;
        if (sqrDistanceToMouse < MouseDistanceThreshold * MouseDistanceThreshold)
            return;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(transform.position + displacement);

        Vector3 lookAt = mouseWorldSpacePos - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookAt);
        rb.MoveRotation(rotation);

        Weapon weapon = GetComponent<Weapon>();
        if (Input.GetButton("Fire1"))
        {
            weapon.Shoot();
        }
    }
}
