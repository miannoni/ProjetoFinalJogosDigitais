using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quad_first : MonoBehaviour
{
    private bool am_active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void isActive(bool active)
    {
        am_active = active;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (am_active)
        {
            if (collision.gameObject)
        }
    }
}
