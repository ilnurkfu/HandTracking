using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjects;

    [SerializeField] private GameObject secondGameObject;

    public void SwitchObject()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].SetActive(false);
        }
        secondGameObject.SetActive(true);
    }
    
}
