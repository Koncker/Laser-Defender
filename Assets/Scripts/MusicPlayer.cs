using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    // This makes it so that there is only 1 of it. This is a singleton.
    static MusicPlayer instance = null;

    // Use this for initialization
    void Start ()
    {
        // Since instance is null - We go to else ->. Now, since instance does not = null - It destroys itself. This will not happen in other scenes where it doesn't exist.
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Duplicate music player self-destructing!");
        }
        // Therefore, instance is now the static and the only one that is meant to exist. This will only run once as we have DontDestroyOnLoad.
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
	}
}
