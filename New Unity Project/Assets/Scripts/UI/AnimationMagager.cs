using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMagager : MonoBehaviour {

    Vector3 pp;
    private Animation pTime;
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;
    public GameObject t5;
    public GameObject t6;
    public GameObject t7;
    public GameObject t8;
    public GameObject t9;

    public static AnimationMagager mAnimation = null;
    int mPoint;
    int mTimebonus;
    int m1, m2;

 
    private void Awake()
    {

        //Check if instance already exist
        if (mAnimation == null)
        {
            //if not, set instance to this
            mAnimation = this;
        }
        else if (mAnimation != this) //If instance already exists and it's not this:
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a TouchManager.
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        pTime = GetComponent<Animation>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void TimeAnimation(ref GameObject point, ref GameObject currentshape)
    { 
        // get point position
        // play animation to correct position
        Vector3 pp = point.transform.position;
        mTimebonus = currentshape.GetComponent<Shapes>().points;
        m1 = mTimebonus.ToString()[0];
        m2 = mTimebonus.ToString()[1];

        if(m1==0)
        {
            Debug.Log("No time for this shape");
        }
        else if(m1==1)
        {
            GameObject P1 = Instantiate(t1, pp,transform.rotation);
            pTime["1"].time = 5.0f;
            P1.GetComponent<Animation>().Play();
            
        }
    }
    void ScoreAnimation(ref GameObject point, ref GameObject currentshape)
    {
        // get point position
        // play animation to correct position

    }
}
