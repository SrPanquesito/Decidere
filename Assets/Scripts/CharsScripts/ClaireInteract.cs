using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaireInteract : MonoBehaviour, Interactable
{   
    public Texture BoxTexture;              // Drag a Texture onto this item in the Inspector

    GUIContent content;
    GUIStyle style = new GUIStyle();
    
    Animator anim;
    string lbl = "";
    public float maxRange {get{return 5f;}}
    public void OnHoverStart(){
        lbl = "Presiona E para hablar con Claire";
    }
    public void OnInteract(){
        lbl = "Has hablado con Claire";
        anim = GetComponent<Animator>();

        anim.SetBool("acceptedMission", true);
        anim.SetBool("isWalking", true);
    }
    public void OnHoverEnd(){
       lbl = "";
    }
    void OnGUI() {
        style.alignment = TextAnchor.MiddleCenter;
        GUI.Box(new Rect(50, 200, Screen.width-100, Screen.height), lbl, style);
    }
}
