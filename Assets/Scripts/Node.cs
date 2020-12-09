using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Node : MonoBehaviour
{
    public Transform cameraPosition;
    public List<Node> reachableNodes = new List<Node>();

    [HideInInspector]
    public Collider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();   
    }

    void OnMouseDown()
    {       
        Arrive ();
      
    }

    public void Arrive()
    {
        //leave existing currentNode
        if (Game_Manager.ins.currentNode != null)
            Game_Manager.ins.currentNode.Leave();
        //set current node
        Game_Manager.ins.currentNode = this;
        //move the camera
        Sequence seq = DOTween.Sequence();
        seq.Append(Camera.main.transform.DOMove(cameraPosition.position, 1.0f));
        seq.Join(Camera.main.transform.DORotate(cameraPosition.rotation.eulerAngles, 1.0f));

        //Camera.main.transform.position = cameraPosition.position;
        //Camera.main.transform.rotation = cameraPosition.rotation;
        //turn off our own collider
        if (col != null)
            col.enabled = false;
        //turn on all reachable node's colliders
        foreach(Node node in reachableNodes)
        {
            if (node.col != null)
            {
                node.col.enabled = true;
            }
        }
        
    }
    void Leave()
    { 
        //turn off all node's reachable colliders.
        foreach (Node node in reachableNodes)
        {
            if (node.col != null)
            {
                node.col.enabled = false;
            }
        }
    }
}
