using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, GameManager.instance.bDestoryTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(GameManager.instance.bSpeed * Time.deltaTime, 0, 0);

    }
}
