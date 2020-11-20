using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Standby : MonoBehaviour
{
    // Standby 스크립트를 text에 넣어준다

    private ServerNetwork serverNetwork;


    public Text Alert;

    private void Start()
    {
        serverNetwork = GetComponent<ServerNetwork>();
        print(UsernameManager.instance.UserName);
        Invoke("JoinNewUser", 1f);
    }

    public void PlayGame()
    {
        StartCoroutine(StartGame());
    }

    public IEnumerator StartGame()
    {
        Alert.text = "플레이어 찾음!";
        yield return new WaitForSeconds(2f);

    }

    // 현재 사용자 접속 알림을 서버로 전송
    private void JoinNewUser()
    {
        print("hi");
        serverNetwork.JoinNewUser();
    }
     
}
