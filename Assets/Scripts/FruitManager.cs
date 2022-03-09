using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FruitManager : MonoBehaviour
{
    public Text FrutasRestantes;
    private void Update()
    {
        FrutasRestantes.text = transform.childCount.ToString();
        if (transform.childCount == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
