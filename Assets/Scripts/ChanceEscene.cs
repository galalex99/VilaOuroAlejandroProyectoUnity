using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChanceEscene : MonoBehaviour
{
    public void MoveScene(int level)
    {
        SceneManager.LoadScene(level);

    }
}
