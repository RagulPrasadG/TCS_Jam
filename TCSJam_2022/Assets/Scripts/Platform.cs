using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject[]  subPlatforms;
    [SerializeField] private GameObject clockPrefab;
    [SerializeField] private GameObject spikePrefab;

    [SerializeField] Material normalMaterial;
    private void Awake()
    {
        int randIndex1 = Random.Range(0, subPlatforms.Length);
        Instantiate(clockPrefab, subPlatforms[randIndex1].transform.position, Quaternion.identity);  // Randomised Clock placements

        
        int randIndex2 = Random.Range(0, subPlatforms.Length);
        if(randIndex2 != randIndex1)
        Instantiate(spikePrefab, subPlatforms[randIndex2].transform.position, spikePrefab.transform.rotation); // Randomised Spike placements

        foreach (GameObject obj in subPlatforms)
        {
            obj.GetComponent<MeshRenderer>().material =  normalMaterial; // Reset color changes to the platform
        }

    }
}
