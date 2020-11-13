using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
where T: MonoBehaviour
{
    private static T _instance;

    public static T instance {
        get {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if (_instance == null) {
                    Debug.LogError("Can't find " + typeof(T) + "!");
                }
            }

            return _instance;
        }
    }
}
