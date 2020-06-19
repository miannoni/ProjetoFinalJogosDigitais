using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public int my_id = 0;
    private int current_cp_id = 0;

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

    void has_passed(GameObject player)
    {
        player.SendMessage("has_passed");
    }
}
