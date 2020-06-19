using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cp_wall : MonoBehaviour
{
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        //parent = transform.parent.gameObject;
        //print(parent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void isActive(bool active)
    {
        if (active)
        {
            GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0);
        } else
        {
            GetComponent<MeshRenderer>().material.color = new Color(255, 255, 255);
        }
    }

    void has_passed(GameObject player)
    {
        parent.SendMessage("has_passed", player);
    }
}
