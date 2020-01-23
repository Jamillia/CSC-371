using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedText : MonoBehaviour
{
    TextMeshPro speedText;
    public float speedMeter;
    public float maxSpeedMeter;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        speedMeter = 0;
        speedText = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (maxSpeedMeter < speedMeter)
        {
            maxSpeedMeter = Mathf.Round(speedMeter);
        }
        speedMeter = Mathf.Sqrt(
            Mathf.Pow(player.GetComponent<Rigidbody2D>().velocity.x, 2) +
            Mathf.Pow(player.GetComponent<Rigidbody2D>().velocity.y, 2));
        speedMeter = Mathf.Round(speedMeter);
        speedText.text = "Speed: " + speedMeter.ToString() + "\n" +
                         "Max Speed: " + maxSpeedMeter.ToString();
    }
}
