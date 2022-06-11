using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class ColorIndicator : MonoBehaviour
{
    [SerializeField]
    private SnapZone snapR;
    [SerializeField]
    private SnapZone snapL;
    [SerializeField]
    private MeshRenderer meshRend;

    private void FixedUpdate() {
        if(snapL.HeldItem != null && snapR.HeldItem != null){
            ChangeIndicatorColor(
                snapL.HeldItem.GetComponent<ColorCanister>().canisterColor,
                snapR.HeldItem.GetComponent<ColorCanister>().canisterColor
            );
        }else if(snapL.HeldItem != null){
            ChangeIndicatorColor(
                snapL.HeldItem.GetComponent<ColorCanister>().canisterColor
            );
        }else if(snapR.HeldItem != null){
            ChangeIndicatorColor(
                snapR.HeldItem.GetComponent<ColorCanister>().canisterColor
            );
        }else{
            ChangeIndicatorColor();
        }
    }

    private void ChangeIndicatorColor(Color? color1 = null, Color? color2 = null){
        if(color1 != null && color2 != null){
            meshRend.material.color = Color.Lerp((Color)color1, (Color)color2, 0.5f);
        }else if(color1 != null){
            meshRend.material.color = (Color)color1;
        }else{
            meshRend.material.color = Color.white;
        }
    }
    
}
