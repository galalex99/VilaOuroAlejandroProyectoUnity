using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeEscene : MonoBehaviour
{
    public void MoveScene(int level)
    {
        SceneManager.LoadScene(level);

    }
}
