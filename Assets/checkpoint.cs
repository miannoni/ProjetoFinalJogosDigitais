using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class checkpoint : MonoBehaviour
{
    public int my_id = 0;
    public bool id_set = false;
    private int current_cp_id = 0;

    void Awake()
    {
        if (id_set == false) {
            my_id = GameObject.FindGameObjectsWithTag("checkpoint").Length - 1;
            id_set = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void set_current_cp(int cp_id)
    {
        current_cp_id = cp_id;
        BroadcastMessage("isActive", (my_id == current_cp_id));
    }

    void has_passed(GameObject racer)
    {
        racer.SendMessage("has_passed", my_id);
    }
}
