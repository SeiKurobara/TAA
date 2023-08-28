using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartCursorOn : MonoBehaviour
{
    public CursorState cursorState;

    void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        cursorState.CursorOn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
