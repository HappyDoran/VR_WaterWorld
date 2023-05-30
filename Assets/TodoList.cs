using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TodoList : MonoBehaviour
{
    public TextMeshProUGUI textField;

    // Start is called before the first frame update
    void Start()
    {
        textField.text = "1.Take a shower \n 2. Watch Tv";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
