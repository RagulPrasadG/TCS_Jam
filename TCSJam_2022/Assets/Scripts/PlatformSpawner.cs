using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    const int SPAWN_OFFSETX = 48;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Vector3 newSpawnPos = this.transform.parent.position;
            newSpawnPos.x += SPAWN_OFFSETX;
            GameObject tempPlatform = Instantiate(platformPrefab, newSpawnPos, Quaternion.identity);
            GameManager.instance.AddPlatforms(tempPlatform);
            Destroy(this);
        }
    }
}
