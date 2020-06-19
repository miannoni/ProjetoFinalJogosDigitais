using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class quad_last : MonoBehaviour
{

    //private bool am_active = false;
    private GameObject parent;
    private int[] racers;
    private GameObject quad_other;

    // Start is called before the first frame update
    void Start()
    {
        int tmp1 = transform.GetSiblingIndex();
        int[] tmp2 = { 1, 0 };
        quad_other = transform.parent.gameObject.transform.GetChild(tmp2[tmp1]).gameObject;

        GameObject[] tmp = GameObject.FindGameObjectsWithTag("Racer");
        racers = new int[tmp.Length];
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void has_passed(GameObject player)
    {
        //if (am_active == true)
        //{

            //parent.SendMessage("has_passed", player);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Racer")
        {
            int[] tmp = { collision.gameObject.GetInstanceID(), 1 };
            quad_other.SendMessage("setOtherquad", tmp);
        }

    }
    
}
