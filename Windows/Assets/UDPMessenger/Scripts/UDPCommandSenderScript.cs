using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UDPStartCommandSenderScript : MonoBehaviour
{
    public UDPClient INSUDPClient;
    private int btnIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void sendUDPStartCommand(int _index)
    {
        this.btnIndex = _index;
        switch (_index)
        {
            case 0:
                INSUDPClient.SendValue(PlayerPrefs.GetString("command_1"));
                break;
            case 1:
                INSUDPClient.SendValue(PlayerPrefs.GetString("command_2"));
                break;
            case 2:
                INSUDPClient.SendValue(PlayerPrefs.GetString("command_3"));
                break;
            case 3:
                INSUDPClient.SendValue(PlayerPrefs.GetString("command_4"));
                break;
        }
    }

    private void sendUDPEndCommand()
    {
        CancelInvoke("sendUDPEndCommand");
        switch (this.btnIndex)
        {
            case 0:
                INSUDPClient.SendValue(PlayerPrefs.GetString("Btn_1_UDPEndCommandEN"));
                break;
            case 1:
                INSUDPClient.SendValue(PlayerPrefs.GetString("Btn_2_UDPEndCommandEN"));
                break;
            case 2:
                INSUDPClient.SendValue(PlayerPrefs.GetString("Btn_3_UDPEndCommandEN"));
                break;
            case 3:
                INSUDPClient.SendValue(PlayerPrefs.GetString("Btn_4_UDPEndCommandEN"));
                break;
            case 4:
                INSUDPClient.SendValue(PlayerPrefs.GetString("Btn_5_UDPEndCommandEN"));
                break;
            case 5:
                INSUDPClient.SendValue(PlayerPrefs.GetString("Btn_6_UDPEndCommandEN"));
                break;
            case 6:
                INSUDPClient.SendValue(PlayerPrefs.GetString("Btn_1_UDPEndCommandAR"));
                break;
            case 7:
                INSUDPClient.SendValue(PlayerPrefs.GetString("Btn_2_UDPEndCommandAR"));
                break;
            case 8:
                INSUDPClient.SendValue(PlayerPrefs.GetString("Btn_3_UDPEndCommandAR"));
                break;
            case 9:
                INSUDPClient.SendValue(PlayerPrefs.GetString("Btn_4_UDPEndCommandAR"));
                break;
            case 10:
                INSUDPClient.SendValue(PlayerPrefs.GetString("Btn_5_UDPEndCommandAR"));
                break;
            case 11:
                INSUDPClient.SendValue(PlayerPrefs.GetString("Btn_6_UDPEndCommandAR"));
                break;
        }
    }

    

    
}
