using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    public bool dataApplied = true;
    public void savedDataApplied()
    {
        dataApplied = true;
    }

    public void startDataApplied()
    {
        dataApplied = false;
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
