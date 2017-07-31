using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTouch : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collides!!");
        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.0f, 0.0f, 1.0f);
        TouchManager.mTouchManager.mDrawTouch.SetSelectedPoint(other.gameObject);
        
    }
}
