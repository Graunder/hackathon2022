using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatSheet : MonoBehaviour
{

    public Color color1;
    public Color color2;

    // Start is called before the first frame update
    void Start()
    {
        Color newColor = Color.Lerp(color1, color2, 0.5f);
        MeshRenderer renderer =  gameObject.GetComponent<MeshRenderer>();
        renderer.material.color = newColor;
        renderer.material.SetColor("_EmissionColor", newColor);
    }

}
