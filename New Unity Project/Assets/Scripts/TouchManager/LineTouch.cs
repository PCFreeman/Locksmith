using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTouch : MonoBehaviour {

    private static List<GameObject> GOs = new List<GameObject>();


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collides!!");
        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.0f, 0.0f, 1.0f);

        GOs.Add(other.gameObject);

        

        //TouchManager.mTouchManager.mDrawTouch.SetSelectedPoint(ref other.gameObject);
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    other.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.0f, 0.0f, 1.0f);
    //
    //    GOs.Add(other.gameObject);
    //
    //}

    public static List<GameObject> GetCollidedObjects()
    {
        Debug.Log("GOs size = " + GOs.Count.ToString());
      
        return GOs;
    }
    


}
