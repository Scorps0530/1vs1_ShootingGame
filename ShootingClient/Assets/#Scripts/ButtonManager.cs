using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private ServerNetwork serverNetwork;

    public InputField inputField_userName;

    public void SetUserNameAndLoadLoadToGameScene()
    {
        if(inputField_userName.text != "")
        {
            UsernameManager.instance.UserName = inputField_userName.text;
            SceneManager.LoadScene("Standby");
        }
        else
        {
            print("닉네임 입력이 안됨.");
        }
    }
}
