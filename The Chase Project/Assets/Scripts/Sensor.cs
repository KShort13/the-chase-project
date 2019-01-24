using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : EnemyController {
    public static bool isActive;
	// Use this for initialization
	void Start () {
        isActive = false;
	}
	
	void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            isActive = false;
        }
    }
}
