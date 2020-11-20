using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake() { if (!instance) instance = this; }

    public GameObject player;
    public GameObject bullet;
    public Transform firepoint;

    public float pSpeed;
    public float bSpeed;
    public float bDestoryTime;
    public float pHp;
    public float eHp;

    Vector3 MousePosition;
    
    void Start()
    {
    }
   
    void Update()
    {
        Move();
        FireBullet();

        if (pHp <= 0)
        {

        }
    }

    private void Move()
    {
        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        player.transform.position = Vector2.MoveTowards(player.transform.position, MousePosition, pSpeed);
        Vector2 v2 = MousePosition - player.transform.position;
        player.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg);
    }

    private void FireBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firepoint.position, firepoint.rotation);
        }
    }
}
