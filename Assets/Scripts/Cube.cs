using System;
using System.ComponentModel.Composition;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    float xSpeed = 0;
    float ySpeed = 0;
    float zSpeed = 0;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(
            Time.deltaTime * xSpeed,
            Time.deltaTime * ySpeed,
            Time.deltaTime * zSpeed
        );
    }

    void OnConnectionEvent(bool status)
    {
        GameObject Ground = GameObject.Find("/Ground");
        GameObject Wall1 = GameObject.Find("/Wall 1");
        GameObject Wall2 = GameObject.Find("/Wall 2");

        if (status) {
            Material green = Resources.Load("Materials/Green", typeof(Material)) as Material;
            Ground.GetComponent<MeshRenderer>().material = green;
            Wall1.GetComponent<MeshRenderer>().material = green;
            Wall2.GetComponent<MeshRenderer>().material = green;
        } else {
            Material red = Resources.Load("Materials/Red", typeof(Material)) as Material;
            Ground.GetComponent<MeshRenderer>().material = red;
            Wall1.GetComponent<MeshRenderer>().material = red;
            Wall2.GetComponent<MeshRenderer>().material = red;
        }
    }

    void OnMessageArrived(string msg)
    {
        string[] args = msg.Split(',');
        if (string.Equals(args[0], "rs")) {             // Rotation Speed
            xSpeed = (float)Convert.ToDouble(args[1]);
            ySpeed = (float)Convert.ToDouble(args[2]);
            zSpeed = (float)Convert.ToDouble(args[3]);
        } else if (string.Equals(args[0], "ea")) {      // Euler Angle
            transform.eulerAngles = new Vector3(
                (float)Convert.ToDouble(args[1]),
                (float)Convert.ToDouble(args[2]),
                (float)Convert.ToDouble(args[3])
            );
        } else if (string.Equals(args[0], "cl")) {      // Colour
            //Material custom = new Material(Shader.Find("Universal Render Pipeline/Lit"));            
            GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(
                map((float)Convert.ToDouble(args[1]), 0, 255, 0, 1),
                map((float)Convert.ToDouble(args[2]), 0, 255, 0, 1),
                map((float)Convert.ToDouble(args[3]), 0, 255, 0, 1),
                1f
            ));
            /*
            custom.SetFloat(Shader.PropertyToID("_WorkflowMode"), 0f);
            custom.SetFloat(Shader.PropertyToID("_Cull"), 0f);
            custom.SetFloat(Shader.PropertyToID("_Smoothness"), 0f);
            GetComponent<MeshRenderer>().material = custom;
            */
        }
    }

    public void Disconnect()
    {
        SerialController serial = GameObject.Find("/Cube/SerialController").GetComponent<SerialController>();
        serial.enabled = false;
        serial.portName = "";
        serial.enabled = true;
    }
    public void Connect()
    {
        SerialController serial = GameObject.Find("/Cube/SerialController").GetComponent<SerialController>();
        TextMeshProUGUI PortSelect = GameObject.Find("/Canvas/Port Select/Label").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI BaudRateSelect = GameObject.Find("/Canvas/Baud Rate Select/Label").GetComponent<TextMeshProUGUI>();
        serial.enabled = false;
        serial.portName = PortSelect.text;
        serial.baudRate = Convert.ToInt32(BaudRateSelect.text);
        serial.enabled = true;
    }

    float map(float x, float in_min, float in_max, float out_min, float out_max) {
      return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }
}