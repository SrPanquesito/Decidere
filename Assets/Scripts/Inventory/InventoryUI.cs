using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using IBM.Watsson.Examples;

public class InventoryUI : MonoBehaviour
{
    private Inventory _inventory;
    public GameObject panel;
    public GameObject menuCanvas;
    public string inventoryButton = "InventoryJoystick";
    public string exitButton = "ExitButton";
    public string pauseButton = "PauseButton";
    public string resumeButton = "ResumeButton";

    public string voiceCommand = "inventario";
    public Animator animInventoryController;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
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
                animInventoryController.SetBool("Open", true);
            }
            else // Close inventory 
            {
                animInventoryController.SetBool("Open", false);
            }
        }

        // Menu interactions
        if (CrossPlatformInputManager.GetButtonDown(pauseButton)) {
            menuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        if (CrossPlatformInputManager.GetButtonDown(resumeButton)) {
            menuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }
        if (CrossPlatformInputManager.GetButtonDown(exitButton)) {
            Application.Quit();
        }
    }

    public void OnVoiceCommandRecognized(string command) {
        if (command.ToLower() == voiceCommand.ToLower())
        {
            panel.SetActive(!panel.activeSelf);
            if (panel.activeSelf) // Open inventory
            {
                UpdateUI();
                animInventoryController.SetBool("Open", true);
            }
            else // Close inventory 
            {
                animInventoryController.SetBool("Open", false);
            }
        }
    }

    void UpdateUI() 
    {
        Debug.Log("Actualizando inventario...");
        Slot[] slots = GetComponentsInChildren<Slot>();
        Item[] toolItems = _inventory.GetAllItemsByType(ItemType.Tool);

        if (toolItems.Length > 0 && slots.Length != 0)
            slots[0].SetItem(toolItems[0], toolItems.Length);
    }
}
