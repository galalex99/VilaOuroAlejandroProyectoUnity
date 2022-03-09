using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerrar : MonoBehaviour
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
