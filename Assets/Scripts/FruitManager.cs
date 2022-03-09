using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    public void TodasFrutasRecogidas() {
        if (transform.childCount == 1) {
            Debug.Log("Todas frutas recogidas");
        }
    }
}
