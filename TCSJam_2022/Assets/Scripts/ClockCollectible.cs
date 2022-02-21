using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockCollectible : MonoBehaviour
{
    private float boostrate;
    private void Start()
    {
        boostrate = Random.Range(3, 10);
    }
    private void Update()
    {
        this.transform.Rotate(new Vector3(0f, 100f * Time.deltaTime , 0f));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameTimer += boostrate;
            Destroy(this.gameObject);
        }

    }
}
