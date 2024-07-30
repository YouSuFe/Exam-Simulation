using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab : MonoBehaviour
{
    // Prefab class to handle gameobjects via inspector
    [System.Serializable]
    public class PrefabMapping
    {
        [SerializeField] private GameObject emptyObject;
        [SerializeField] private GameObject prefab;
        private GameObject instantiatedObject;

        public GameObject EmptyObject => emptyObject;
        public GameObject Prefab => prefab;
        public GameObject InstantiatedObject { get => instantiatedObject; set => instantiatedObject = value; }
    }

    [SerializeField]
    private PrefabMapping[] prefabMappings;

    // Method that creates prefab on the scene
    public void InstantiatePrefabs()
    {
        foreach(var mapping in prefabMappings)
        {
            if (mapping.EmptyObject != null && mapping.Prefab != null)
            {
                var instantiatedObject = Instantiate(mapping.Prefab, mapping.EmptyObject.transform.position, mapping.EmptyObject.transform.rotation);
                mapping.InstantiatedObject = instantiatedObject;
                instantiatedObject.SetActive(true); // Initially set inactive
            }
        }
    }

    // Activate prefab on scene
    public void ActivatePrefab(int index)
    {
        if (index >= 0 && index < prefabMappings.Length && prefabMappings[index].InstantiatedObject != null)
        {
            prefabMappings[index].InstantiatedObject.SetActive(true);
        }
    }

    // Deactivate prefab on scene
    public void DeactivatePrefab(int index)
    {
        if (index >= 0 && index < prefabMappings.Length && prefabMappings[index].InstantiatedObject != null)
        {
            prefabMappings[index].InstantiatedObject.SetActive(false);
        }
    }
}
