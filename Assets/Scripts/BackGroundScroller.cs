using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit2D(Collider2D col)
    {
        if ( col.tag== "Player")
        {
            transform.position += 2 * Vector3.right * GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }
}
