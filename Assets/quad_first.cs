using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quad_first : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Racer")
        {
            print("colidiu");
            parent.SendMessage("has_passed", other.gameObject);
        }
    }

}
