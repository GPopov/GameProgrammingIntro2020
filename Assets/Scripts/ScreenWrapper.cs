using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{

    void Update()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        bool wrapped = false;
        for (int i = 0; i < 2; ++i)
        {
            if (viewportPos[i] < 0 || viewportPos[i] > 1)
            {
                viewportPos[i] = viewportPos[i] - Mathf.Floor(viewportPos[i]);
                wrapped = true;
            }
        }
        if (wrapped)
        {
            transform.position = Camera.main.ViewportToWorldPoint(viewportPos);
        }
    }
}
