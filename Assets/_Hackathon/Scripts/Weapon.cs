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
    [SerializeField]
    private Transform projectileSpawnPos;
    
    private Color projectileColor;
    private float velocity = 700f;

    public void Shoot(){
        GetNewProjectile();
        // projectile.GetComponentInChildren<MeshRenderer>().material.color = projectileColor;

        GameObject newProjectile = Instantiate(projectile, projectileSpawnPos.position, Quaternion.identity);
        newProjectile.GetComponentInChildren<MeshRenderer>().material.color = projectileColor;
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPos.forward * velocity);
        
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
            // Debug.Log("Colors - none = white");
        }
    }

}
