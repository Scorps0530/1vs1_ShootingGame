using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake() { if (!instance) instance = this; }

    public float speed;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Player.transform.Translate(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0);
        Vector2 v2 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Player.transform.position;
        Player.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg);

    }
}
