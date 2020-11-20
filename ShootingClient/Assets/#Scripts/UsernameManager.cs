using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsernameManager : MonoBehaviour
{
    public static UsernameManager instance;
    void Awake() { if (!instance) instance = this; }

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
