using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    public GameObject detailPanel;
    string displayName;
    string description;
    public Image image;
    public void OnPointerEnter()
    {
        detailPanel.SetActive(true);
        detailPanel.GetComponentsInChildren<Text>()[0].text = displayName;
        detailPanel.GetComponentsInChildren<Text>()[1].text = description;

    }
    public void OnPointerExit()
    {

        detailPanel.SetActive(false);
    }

    public void init(string n,string des, Sprite spr) { 
        displayName = n; 
        description = des;
        image.sprite = spr;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
