using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager ins;
    public Node currentNode;
    void Awake()
    {
        ins = this;
    }
    
}
