using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text labelTiempo;
    float tiempo = 120;
    ChangeEscene cambioEscena;
    // Start is called before the first frame update
    void Start()
    {
        cambioEscena = new ChangeEscene();
        labelTiempo.text = tiempo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        tiempo -=  Time.deltaTime;
        labelTiempo.text = ((int) tiempo).ToString();
        if (tiempo < 0) {
            cambioEscena.MoveScene(3);
        }
    }


}
