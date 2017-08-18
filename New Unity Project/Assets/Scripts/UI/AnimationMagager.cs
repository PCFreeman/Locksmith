using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMagager : MonoBehaviour {

    private Animation mAnime;
    Vector3 pp;
    public static AnimationMagager mAnimation = null;
    int mPoint;
    int mTimebonus;
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
        mAnime = GetComponent<Animation>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void TimeAnimation(ref GameObject point, ref GameObject currentshape)
    { 
        // get point position
        // play animation to correct position
        Vector3 pp = point.transform.position;
        mAnime.transform.position = pp;
        mAnime.Play("PlusTime");

        mPoint=currentshape.GetComponent<Shapes>().points;
        mPoint.ToString();

        
    }
    void ScoreAnimation(ref GameObject point, ref GameObject currentshape)
    {
        // get point position
        // play animation to correct position

    }
}
