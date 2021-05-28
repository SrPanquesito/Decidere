using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBM.Watsson.Examples;

public class ClaireInteract : MonoBehaviour, Interactable
{   
    public Texture BoxTexture;              // Drag a Texture onto this item in the Inspector

    GUIContent content;
    GUIStyle style = new GUIStyle();
    
    Animator anim;
    string lbl = "";
    public float maxRange {get{return 5f;}}

    public string voiceCommand = "hola";      // Comando de voz para interactuar

    public void OnHoverStart(){
        SpeechToText commandProcessor = GameObject.FindObjectOfType<SpeechToText>();
        commandProcessor.onVoiceCommandRecognized += OnVoiceCommandRecognized; 
        lbl = "Presiona E para hablar con Claire";
    }
    public void OnInteract(){
        lbl = "Has hablado con Claire";
        anim = GetComponent<Animator>();

        Debug.Log("Mejor hablame.");

        anim.SetBool("acceptedMission", true);
        anim.SetBool("isWalking", true);
    }
    public void OnHoverEnd(){
        SpeechToText commandProcessor = GameObject.FindObjectOfType<SpeechToText>();
        commandProcessor.onVoiceCommandRecognized = null;
       lbl = "";
    }
    void OnGUI() {
        style.alignment = TextAnchor.MiddleCenter;
        GUI.Box(new Rect(50, 200, Screen.width-100, Screen.height), lbl, style);
    }

    public void OnVoiceCommandRecognized(string command) {
        if (command.ToLower() == voiceCommand.ToLower())
        {
            lbl = "Has hablado con Claire";
            anim = GetComponent<Animator>();

            Debug.Log("Dijiste hola para interactuar con Claire");

            anim.SetBool("acceptedMission", true);
            anim.SetBool("isWalking", true);
        }
    }
}
