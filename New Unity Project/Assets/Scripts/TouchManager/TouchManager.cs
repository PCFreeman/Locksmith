using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {

    public static TouchManager mTouchManager = null;
    
    public TouchLogic mTouchLogic;




    private void Awake()
    {
        //Check if instance already exist
        if (mTouchManager == null)
        { 
            //if not, set instance to this
            mTouchManager = this;
        }
        else if (mTouchManager != this) //If instance already exists and it's not this:
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a TouchManager.
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);
    }



    // Use this for initialization
    void Start () {
        Debug.Log("[TouchManager]Manager successfully started.");

        mTouchLogic = new TouchLogic();
        Debug.Log("TouchLogic   " + mTouchLogic.ToString());
    }
	
	// Update is called once per frame
	void Update () {
		



	}

    void OnApplicationQuit()
    {
        Debug.Log("[TouchManager]Manager successfully finished.");




    }

}
