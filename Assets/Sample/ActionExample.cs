using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class ActionExample : MonoBehaviour
{

    public UnityAction ballCreated;

    private void Start()
    {
        ballCreated += CreateBall;
        ballCreated.Invoke();
    }

    void CreateBall()
    {
        print("ball created!");
    }

}
