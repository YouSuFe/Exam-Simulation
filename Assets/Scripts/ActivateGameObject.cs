using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gameObjects;

    public void ActivateGameobject()
    {
        foreach(var gameObject in gameObjects)
        {
            gameObject.SetActive(true);
        }
    }

    public void DeactivateGameobject()
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
    }
}
