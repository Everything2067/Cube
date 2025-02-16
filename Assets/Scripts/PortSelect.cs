using System;
using System.Collections.Generic;
using System.IO.Ports;
using TMPro;
using UnityEngine;

public class PortSelect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Define required variables
        TMP_Dropdown portSelect = GameObject.Find("/Canvas/Port Select").GetComponent<TMP_Dropdown>();
        string[] PortNames = SerialPort.GetPortNames();
        int PortNamesLen = PortNames.Length;


        // Get port numbers
        int[] PortNamesInt = new int[PortNamesLen];
        for (int i=0; i<PortNamesLen; i++) {
            PortNamesInt[i] = Convert.ToInt16(PortNames[i].Substring(3));
        }

        // Sort the port numbers
        Array.Sort(PortNamesInt);

        // Then concatenate "COM" and print to log
        string[] PortNamesSorted = new string[PortNamesLen];
        for (int i=0; i<PortNamesLen; i++) {
            PortNamesSorted[i] = "COM" + Convert.ToString(PortNamesInt[i]);
            Debug.Log(PortNamesSorted[i]);
        }

        // Convert the array to a list
        var PortNamesLst = new List<string>();
        PortNamesLst.AddRange(PortNamesSorted);
        portSelect.AddOptions(PortNamesLst);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
