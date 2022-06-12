using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]
    private GameObject particles;

    private void OnTriggerEnter(Collider other) {
        // Instantiate(particles, other.transform.position, Quaternion.identity);
        Destroy(other.gameObject);
    }
}
