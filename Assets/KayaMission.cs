using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBM.Watsson.Examples;

public class KayaMission : MonoBehaviour, Interactable
{
   
    public Texture BoxTexture;              // Drag a Texture onto this item in the Inspector

    GUIContent content;
    GUIStyle style = new GUIStyle();
    int[] curState = {0,1};
    Animator anim;

    string[] lbl = {"",
        "Presiona E para hablar con Kaya",
        "¿Qué pasa, hermano? ¿Tienes un par de hongos para caridad?",
        "Realmente me caerían bien ahora mismo",
        "Tú sí eres la onda, hermano"};
    
    public float maxRange {get{return 5f;}}

    public string voiceCommand = "hola";      // Comando de voz para interactuar
    private void xchg(){
        int temp;
        temp = curState[0]; 
        curState[0] = curState[1];
        curState[1] = temp;
    }

    public void OnHoverStart(){
        
        SpeechToText commandProcessor = GameObject.FindObjectOfType<SpeechToText>();
        commandProcessor.onVoiceCommandRecognized += OnVoiceCommandRecognized;
        xchg();
    }
    public void OnInteract(){
        anim = GetComponent<Animator>();
        anim.SetBool("isTalking", true);
        if (curState[0].Equals(3)) {
            curState[0] = 4;      
        }else{
            if (curState[0]<4) curState[0]++;
        }
        
    }
    public void OnHoverEnd(){
        SpeechToText commandProcessor = GameObject.FindObjectOfType<SpeechToText>();
        commandProcessor.onVoiceCommandRecognized = null;
        xchg();
    }
    void OnGUI() {
        style.alignment = TextAnchor.MiddleCenter;
        style.fontSize = 30;
        style.normal.textColor = Color.white;
        GUI.Box(new Rect(50, 200, Screen.width-100, Screen.height), lbl[curState[0]], style);
    }

    public void OnVoiceCommandRecognized(string command) {
        if (command.ToLower() == voiceCommand.ToLower())
        {
            anim = GetComponent<Animator>();

            OnInteract();
        }
    }
}
