using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlFinal : MonoBehaviour
{
    ChangeEscene cambioEscena;

    public void Start()
    {
        cambioEscena=new ChangeEscene();
    }

    public void Exit() {
        Application.Quit();
    }

    public void Retry() {
        cambioEscena.MoveScene(1);
    }
}
