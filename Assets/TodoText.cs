using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TodoText : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle Todo1;
    public Toggle Todo2;
    public Toggle Todo3;
    public Toggle Todo4;    
    void Start()
    {
        Todo1.isOn = false;
        Todo2.isOn = false;
        Todo3.isOn = false;
        Todo4.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
