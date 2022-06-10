using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    [SerializeField]
    private SnapZone snapR;
    [SerializeField]
    private SnapZone snapL;
    [SerializeField]
    private GameObject projectile;
    private Color projectileColor;
    private Color colorWhite = Color.white;

    public Material[] colorCombinations;

    public void Shoot(){
        GetNewProjectile();
        // Debug.Log($"Shoot - Color: {snapR.HeldItem.GetComponent<ColorCanister>().canisterColor}");
        projectile.GetComponentInChildren<MeshRenderer>().material.color = projectileColor;
    }

    private void GetNewProjectile(){

        if(snapL.HeldItem != null && snapR.HeldItem != null){
            ChangeProjectileColor(
                snapL.HeldItem.GetComponent<ColorCanister>().canisterColor,
                snapR.HeldItem.GetComponent<ColorCanister>().canisterColor
            );
            // Debug.Log($"Colors - snapL: {snapL.HeldItem.GetComponent<ColorCanister>().canisterColor}, snapR: {snapR.HeldItem.GetComponent<ColorCanister>().canisterColor}");
        }else if(snapL.HeldItem != null){
            ChangeProjectileColor(
                snapL.HeldItem.GetComponent<ColorCanister>().canisterColor
            );
            // Debug.Log($"Colors - snapL: {snapL.HeldItem.GetComponent<ColorCanister>().canisterColor}");
        }else if(snapR.HeldItem != null){
            ChangeProjectileColor(
                snapR.HeldItem.GetComponent<ColorCanister>().canisterColor
            );
            // Debug.Log($"Colors - snapR: {snapR.HeldItem.GetComponent<ColorCanister>().canisterColor}");
        }else{
            ChangeProjectileColor();
            
        }

    }

    private void ChangeProjectileColor(Color? color1 = null, Color? color2 = null){
        if(color1 != null && color2 != null){
            projectileColor = Color.Lerp((Color)color1, (Color)color2, 0.5f);
        }else if(color1 != null){
            projectileColor = (Color)color1;
        }else{
            projectileColor = Color.white;
            Debug.Log("Colors - none = white");
        }

        // switch(color1, color2){
        //     // case ("", ""):
        //     //     break;
        //     case ("Blue", ""):
        //         break;
        //     case ("Red", ""):
        //         break;
        //     case ("Yellow", ""):
        //         break;
        //     default: 
        //         projectileMaterial = colorCombinations[0];
        //         break;
        // }
    }

}
