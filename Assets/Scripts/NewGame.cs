using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour {

    public void NewGameOrc(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
