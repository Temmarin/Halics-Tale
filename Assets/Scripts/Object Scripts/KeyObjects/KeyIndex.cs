using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyIndex : MonoBehaviour
{
    public static KeyIndex Instance;
    
    private int numKey = 15;
    protected bool[] Keys = new bool[15];

    public int getNumberOfKeys()
    {
        return numKey;
    }
    
    public bool checkKey(int index)
    {
        if (index < numKey)
        {
            Debug.Log("Key Checked!");
            Debug.Log("Check Key at " + index + " is " + Keys[index]);
            return Keys[index];
        }
        return false;
    }

    public void updateKey(int index)
    {
        if (index < numKey)
        {
            Keys[index] = true;
            Debug.Log("Key Updated!");
        }
        Debug.Log("Update Key at " + index+ " is " + Keys[index]);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
