using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FruitManager : MonoBehaviour
{
    ChangeEscene cambioEscena;
    public Text FrutasRestantes;
    private void Start()
    {
        cambioEscena = new ChangeEscene();
    }
    private void Update()
    {
        FrutasRestantes.text = transform.childCount.ToString();
        if (transform.childCount == 0)
        {
            cambioEscena.MoveScene(2);
        }
    }
}
