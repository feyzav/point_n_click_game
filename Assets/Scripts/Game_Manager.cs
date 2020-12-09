using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager ins;

    //Makes a variable not show up in the inspector but be serialized.
    [HideInInspector]
    public Node currentNode;
    
    void Awake()
    {
        ins = this;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
        {
            currentNode.GetComponent<Prop>().loc.Arrive();
        }
    }
}
