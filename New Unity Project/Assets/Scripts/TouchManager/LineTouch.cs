﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTouch : MonoBehaviour {

    private static List<GameObject> GOs = new List<GameObject>();

    private bool check = false;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collides line =  " + other.name);


            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.0f, 0.0f, 1.0f);

            GOs.Add(other.gameObject);

            TouchManager.mTouchManager.mColliders.mCurrentPoint = other.gameObject;
            TouchManager.mTouchManager.mColliders.pointCount += 1; 

            check = true;



        //TouchManager.mTouchManager.mDrawTouch.SetSelectedPoint(ref other.gameObject);
    }
    

   

    public static List<GameObject> GetCollidedObjects()
    {
        Debug.Log("GOs size = " + GOs.Count.ToString());
      
        return GOs;
    }
    


}
