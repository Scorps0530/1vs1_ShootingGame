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

        socket.On("gotInfo", OnGotInfo);
        socket.On("enemyShoot", OnEnemyShoot);
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

    // 게임 현황 송신 이벤트
    public void GiveInfo()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("x", GameManager.instance.player.transform.position.x.ToString());
        data.Add("y", GameManager.instance.player.transform.position.y.ToString());
        data.Add("r", GameManager.instance.player.transform.rotation.z.ToString());
        data.Add("hp", GameManager.instance.pHp.ToString());
        JSONObject jObject = new JSONObject(data);
        socket.Emit("recievedInfo", jObject);
    }

    // 총알 발사 이벤트
    public void Shoot()
    {
        socket.Emit("shoot");
    }

    #endregion

    #region 수신 이벤트 처리
     
    // Game 시작
    private void OnPlayGame(SocketIOEvent obj)
    {
        standby.PlayGame();
    }

    // enemy의 정보를 받기
    private void OnGotInfo(SocketIOEvent obj)
    {

        GameManager.instance.SetEnemyInfo(obj.data.GetField("x").f, obj.data.GetField("y").f, obj.data.GetField("r").f, obj.data.GetField("hp").f);
    }

    // 적이 총을 쐈을 때
    private void OnEnemyShoot(SocketIOEvent e)
    {
        //Instantiate(pBullet, firepoint.position, firepoint.rotation);
        gameManager.EFireBullet();
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
