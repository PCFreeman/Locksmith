using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawTouch : MonoBehaviour {

    public GameObject linePrefab;
    public GameObject lineColliderPrefab;
    private GameObject thisLine;
    private List<GameObject> lineColliders;
    private Vector3 startPosition;
    private Plane objectPlane;
    //private List<GameObject> pointsSelected;
    private bool LastShapeCorect;


    public void Initialize()
    {
        LastShapeCorect = false;
        //pointsSelected = new List<GameObject>();
        objectPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);

        lineColliders = new List<GameObject>();

    }

    // Update is called once per frame
    public void update()
    {

        //This function can be use for Touch or mouse click
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
        {
            if(LastShapeCorect == true)
            {
                foreach (GameObject GO in TouchManager.mTouchManager.pointsSelected)
                {
                    GO.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                }

                TouchManager.mTouchManager.pointsSelected.Clear();
                LastShapeCorect = false;
            }


            thisLine = (GameObject)Instantiate(linePrefab, this.transform.position, Quaternion.identity);

            Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);           //Use This for Mouse test

            float rayDistance;
            if (objectPlane.Raycast(mRay, out rayDistance))    //This check the contact of RayCast with plane and return the distance
            {
                startPosition = mRay.GetPoint(rayDistance);
            }
        }
        else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || (Input.GetMouseButton(0)))
        {
            GameObject coll = (GameObject)Instantiate(lineColliderPrefab, this.transform.position, Quaternion.identity);
               
            Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);           //Use This for Mouse test

            float rayDistance;
            if (objectPlane.Raycast(mRay, out rayDistance))    //This check the contact of RayCast with plane and return the distance
            {
                
                thisLine.transform.position = mRay.GetPoint(rayDistance);

                //coll.GetComponent<BoxCollider>().

            }


            lineColliders.Add(coll);


        }
        else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {

            TouchManager.mTouchManager.pointsSelected = LineTouch.GetCollidedObjects();

           Debug.Log("points selected = " + TouchManager.mTouchManager.pointsSelected.ToString()); 
            // Check if the line makes the corect shape
            //if (TouchManager.mTouchManager.mTouchLogic.checkShapes(TouchLogic.Shapes.Triangle5X3YLeft, ref pointsSelected))
            if(TouchManager.mTouchManager.mTouchLogic.checkShapes(TouchManager.mTouchManager.GetCurrentShape().GetComponent<Shapes>().GetShpeType(), ref TouchManager.mTouchManager.pointsSelected))
            {
                GameObject curShape = new GameObject();
                GameObject firstPoint = new GameObject();

                curShape = TouchManager.mTouchManager.GetCurrentShape();
                firstPoint = TouchManager.mTouchManager.pointsSelected[0];

                Debug.Log("..........." +curShape.name);
                Debug.Log("***********" + firstPoint.name);

                //AnimationMagager.mAnimation.ScoreAnimation( ref firstPoint, ref curShape);
                //AnimationMagager.mAnimation.TimeAnimation(ref firstPoint, ref curShape);

               Debug.Log("Correct Shape");
               TouchManager.mTouchManager.DeleteCurrentShape(); //Delete current shape and Instantiate a new one


               Destroy(thisLine);

               foreach(GameObject GO in TouchManager.mTouchManager.pointsSelected)
               {
                   GO.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
               }

                LastShapeCorect = true;

                //Add points to score
                UIManage.instance.AddScore(TouchManager.mTouchManager.GetCurrentShape().GetComponent<Shapes>().points);

                //Add points to score
                UIManage.instance.AddTime(TouchManager.mTouchManager.GetCurrentShape().GetComponent<Shapes>().timeBonus);


                TouchManager.mTouchManager.mColliders.mCurrentShape = TouchManager.mTouchManager.GetCurrentShape();


                TouchManager.mTouchManager.mColliders.pointCount = 0;
                //Reset Collidrrs size

                //Call the winning animation or add points or ...

            }
           else
           {
               Debug.Log("Wrong Shape");

               //Destroi the line , may add some stuff in future to make player know that made mistake
               Destroy(thisLine);
               Debug.Log("GOs 2 size = " + TouchManager.mTouchManager.pointsSelected.Count.ToString());
               foreach (GameObject GO in TouchManager.mTouchManager.pointsSelected)
               {
                   GO.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
               }

                TouchManager.mTouchManager.pointsSelected.Clear();

                TouchManager.mTouchManager.mColliders.pointCount = 0;
                //Reset Colliders size
            }


        }
    }

    public void SetSelectedPoint(ref GameObject point)
    {
        Debug.Log(" -----------    "+point.name.ToString());


        TouchManager.mTouchManager.pointsSelected.Add(point);
    }

    private float GetPointsDistance(Vector3 initialPos, Vector3 finalPos)
    {
        float xDistance = finalPos.x - initialPos.x;
        float yDistance = finalPos.y - initialPos.y;

        return Mathf.Sqrt((xDistance* xDistance) + (yDistance* yDistance));
        
    }

    private float GetRotation(Vector3 initialPos, Vector3 finalPos)
    {
        float xDistance = finalPos.x - initialPos.x;
        float yDistance = finalPos.y - initialPos.y;

        return Mathf.Atan2(yDistance, xDistance) * 180 / Mathf.PI; ;

    }


}
