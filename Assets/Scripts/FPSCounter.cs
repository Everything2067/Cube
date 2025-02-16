using System;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    float oldTime;
    float timeSinceExec;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceExec += Time.deltaTime;
        if (timeSinceExec - oldTime >= 1) {
            /*
            int fps = (int)(Time.frameCount / timeSinceExec);
            GetComponent<TextMeshProUGUI>().text = Convert.ToString(fps) + " FPS";
            oldTime = timeSinceExec;
            */
            int fps = (int)(1f / Time.deltaTime);
            GetComponent<TextMeshProUGUI>().text = Convert.ToString(fps) + " FPS";
            oldTime = timeSinceExec;
        }
    }

    void frameCount() {
        
        
        
    }
}
