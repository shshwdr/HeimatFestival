using Language.Lua;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        updateInventory();
        EventPool.OptIn("dialogEnd", updateInventory);
    }



    public void updateInventory()
    {
        var allItems = PixelCrushers.DialogueSystem.DialogueLua.GetAllItems();

        int i = 0;
        var cells = GetComponentsInChildren<InventoryCell>(true);
        foreach (var item in allItems.Keys)
        {
            if (PixelCrushers.DialogueSystem.DialogueLua.GetItemField(item.Value.ToString(), "Amount").asInt > 0)
            {
                cells[i].gameObject.SetActive(true);
                cells[i].GetComponent<InventoryCell>().init(PixelCrushers.DialogueSystem.DialogueLua.GetItemField(item.Value.ToString(), "Display Name").asString,
                    PixelCrushers.DialogueSystem.DialogueLua.GetItemField(item.Value.ToString(), "Description").asString,
                    Resources.Load<Sprite>("items/" + item.Value.ToString())
                    );
                i++;
            }
            //  print(((LuaTable)item).GetValue("DisplayName"));
        }
        for (; i < cells.Length; i++)
        {
            cells[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
