using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerNetwork : MonoBehaviour
{
    private SocketIOComponent socket;
    private GameManager gameManager;
    private Standby standby;

    void Start()
    {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        gameManager = GetComponent<GameManager>();
        standby = GetComponent<Standby>();

        socket.On("open", TestOpen);
        socket.On("error", TestError);
        socket.On("close", TestClose);

        socket.On("playGame", OnPlayGame);
    }

    #region 송신 이벤트 처리

    // 새로운 사용자 접속 송신 이벤트
    public void JoinNewUser()
    {
        print(UsernameManager.instance.UserName);
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("userName", UsernameManager.instance.UserName);
        JSONObject jObject = new JSONObject(data);
        socket.Emit("joinNewUser", jObject);
    }

    #endregion

    #region 수신 이벤트 처리

    private void OnPlayGame(SocketIOEvent e)
    {
        standby.PlayGame();
    }

    public void TestOpen(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
    }

    public void TestError(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
    }

    public void TestClose(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
    }

    #endregion
}
