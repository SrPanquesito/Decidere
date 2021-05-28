using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot3D : MonoBehaviour
{
    public Item item;
    public Image image;
    public Sprite defaultSprite;
    public GameObject defaultModel;
    private MeshRenderer defaultModelRenderer;
    public string meshReserved;

    public Text counterText;
    public TextMesh counterText3D;
    public int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        defaultModelRenderer = defaultModel.GetComponent<MeshRenderer>();
    }

    public void SetItem(Item item, int count) 
    {
        this.item = item;
        counter = count;
        if(image != null) 
        {
            image.sprite = item.icon;
        }
        if(counterText != null)
        {
            counterText.text = counter.ToString();
        }
        if(defaultModelRenderer != null)
        {
            defaultModelRenderer.enabled = true;
        }
        if(counterText3D != null)
        {
            counterText3D.text = counter.ToString();
        }
    }

    public void Clear() 
    {
        this.item = null;
        image.sprite = defaultSprite;
        defaultModelRenderer.enabled = false;
        counterText3D.text = "";
    }

    public void UseItem()
    {
        if (this.item != null)
        {
            item.Use();
            if (counter > 0)
                counter--;
            if (counterText != null)
                counterText.text = counter.ToString();
            if(counterText3D != null)
                counterText3D.text = counter.ToString();
            if (counter == 0) {
                defaultModelRenderer.enabled = false;
            }
        }
    }
}
