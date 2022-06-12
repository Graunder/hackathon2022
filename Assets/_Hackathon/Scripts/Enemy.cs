using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    
    public Color targetColor;
    public Color targetColor2;
    public bool mix = false;

    private Color colorToCompare;
    [SerializeField]
    private MeshRenderer rendr;
    [SerializeField]
    private GameObject particles;
    private GameObject spawner;

    private void Start() {
        // GetComponent<MeshRenderer>().material.color = targetColor;
        spawner = GameObject.Find("Spawner");
        if(mix){
            Color newColor = Color.Lerp(targetColor, targetColor2, 0.5f);
            rendr.material.color = newColor;
            rendr.material.SetColor("_EmissionColor", newColor);
            colorToCompare = newColor;
        }else{
            rendr.material.color = targetColor;
            rendr.material.SetColor("_EmissionColor", targetColor);
            colorToCompare = targetColor;
        }
    }

    private void OnCollisionEnter(Collision other) {
        // Debug.Log($"OnCollisionEnter - CompareTag {other.gameObject.CompareTag("Projectile")}");
        // Debug.Log($"OnCollisionEnter - Colors other: {other.gameObject.GetComponentInChildren<MeshRenderer>().material.color}");
        // Debug.Log($"OnCollisionEnter - Colors target color: {targetColor}");
        if(other.gameObject.CompareTag("Projectile") && other.gameObject.GetComponentInChildren<MeshRenderer>().material.color == colorToCompare){
            Instantiate(particles, other.transform.position, Quaternion.identity);
            spawner.GetComponent<Spawner>().UpdateScore();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
