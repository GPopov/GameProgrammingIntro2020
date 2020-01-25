using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLabelController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text txt = GetComponent<Text>();
        txt.text += GameStateController.Instance.PlayerScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
