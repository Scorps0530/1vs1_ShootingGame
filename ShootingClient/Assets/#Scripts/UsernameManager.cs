using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsernameManager : MonoBehaviour
{
    public static UsernameManager instance = null;
    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }

    private string userName;
    public string UserName
    {
        get { return userName; }
        set
        {
            userName = value;
            print("userName setted: " + userName);
        }
    }
}
