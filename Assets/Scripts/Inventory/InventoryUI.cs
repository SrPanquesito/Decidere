using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

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

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        _inventory = Inventory.InventoryInstance;
        _inventory.onChange += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown(inventoryButton))
        {
            panel.SetActive(!panel.activeSelf);
            if (panel.activeSelf)
            {
                UpdateUI();
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

    void UpdateUI() 
    {
        Debug.Log("Actualizando inventario...");
        Slot[] slots = GetComponentsInChildren<Slot>();
        Item[] toolItems = _inventory.GetAllItemsByType(ItemType.Tool);

        if (toolItems.Length > 0 && slots.Length != 0)
            slots[0].SetItem(toolItems[0], toolItems.Length);
    }
}