using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public List<InputField> inputFieldList;
    public InputField portInputfield;
    public InputField ipInputfield;

    private void OnEnable() {
        loadAllSettings();
    }


    private void loadAllSettings(){
        //inputFieldList[0].text = PlayerPrefs.GetString("Enter");
        inputFieldList[0].text = PlayerPrefs.GetString("command_1");
        inputFieldList[1].text = PlayerPrefs.GetString("command_2");
        inputFieldList[2].text = PlayerPrefs.GetString("command_3");
        inputFieldList[3].text = PlayerPrefs.GetString("command_4");


        portInputfield.text = PlayerPrefs.GetInt("portSend").ToString();
        ipInputfield.text = PlayerPrefs.GetString("ipSend");
    }

    public void saveAllSettings(){
        //PlayerPrefs.SetString("Enter", inputFieldList[0].text);
        PlayerPrefs.SetString("command_1", inputFieldList[0].text);
        PlayerPrefs.SetString("command_2", inputFieldList[1].text);
        PlayerPrefs.SetString("command_3", inputFieldList[2].text);
        PlayerPrefs.SetString("command_4", inputFieldList[3].text);

        int portValue;
        if (int.TryParse(portInputfield.text, out portValue))
        {
            PlayerPrefs.SetInt("portSend", portValue);
        }

        PlayerPrefs.SetString("ipSend", ipInputfield.text);
    }
}
