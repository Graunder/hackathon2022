using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    [SerializeField]
    private GameObject particles;

    private GameObject spawner;

    private void Start() {
        spawner = GameObject.Find("Spawner");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("enemy")){
            Instantiate(particles, other.transform.position, Quaternion.identity);
            spawner.GetComponent<Spawner>().UpdateLives();
            Destroy(other.gameObject);
        }
    }
}
