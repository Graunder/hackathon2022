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

    public void Shoot(){
        GetColor();
        Debug.Log("Shoot");
    }

    private void GetColor(){

        if(snapL.HeldItem != null && snapR.HeldItem != null){
            Debug.Log($"Colors - snapL: {snapL.HeldItem.GetComponent<ColorCanister>().colorName}, snapR: {snapR.HeldItem.GetComponent<ColorCanister>().colorName}");
        }

    }

}
