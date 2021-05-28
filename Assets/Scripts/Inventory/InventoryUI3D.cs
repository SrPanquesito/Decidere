using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using IBM.Watsson.Examples;

public class InventoryUI3D : MonoBehaviour
{
    private Inventory _inventory;
    public GameObject panel;
    public string inventoryButton = "InventoryJoystick";

    public string voiceCommand = "inventario";

    // Start is called before the first frame update
    void Start()
    {
        _inventory = Inventory.InventoryInstance;
        _inventory.onChange += UpdateUI;

        SpeechToText commandProcessor = GameObject.FindObjectOfType<SpeechToText>();
        commandProcessor.onVoiceCommandRecognized += OnVoiceCommandRecognized; 
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown(inventoryButton))
        {
            panel.SetActive(!panel.activeSelf);
            if (panel.activeSelf) // Open inventory
            {
                UpdateUI();
            }
        }
    }

    public void OnVoiceCommandRecognized(string command) {
        if (command.ToLower() == voiceCommand.ToLower())
        {
            panel.SetActive(!panel.activeSelf);
            if (panel.activeSelf) // Open inventory
            {
                UpdateUI();
            }
        }
    }

    void UpdateUI() 
    {
        Debug.Log("Actualizando inventario...");
        Slot3D[] meshes = GetComponentsInChildren<Slot3D>();
        Item[] toolItems = _inventory.GetAllItemsByType(ItemType.Tool);

        if (toolItems.Length > 0 && meshes.Length != 0) {
            if (meshes[0].meshReserved == toolItems[0].meshReserved) {
                meshes[0].SetItem(toolItems[0], toolItems.Length);
            }
        }
    }
}
