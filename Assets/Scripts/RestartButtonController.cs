using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// later on, teach interface
public class RestartButtonController : MonoBehaviour, InteractiveButton
{

    public UnityEvent gameRestart;

    public void ButtonClick()
    {
        gameRestart.Invoke();
    }

}
