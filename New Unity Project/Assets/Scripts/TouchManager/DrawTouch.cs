using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTouch : MonoBehaviour {

    public GameObject linePrefab;
    private GameObject thisLine;
    private Vector3 startPosition;
    private Plane objectPlane;
    private List<GameObject> pointsSelected;
    private bool LastShapeCorect;


    private void Start()
    {
        LastShapeCorect = false;
        pointsSelected = new List<GameObject>();
        objectPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);

    }

    // Update is called once per frame
    void Update()
    {

        //This function can be use for Touch or mouse click
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
        {
            if(LastShapeCorect == true)
            {
                foreach (GameObject GO in pointsSelected)
                {
                    GO.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                }

                pointsSelected.Clear();
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

            Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);           //Use This for Mouse test

            float rayDistance;
            if (objectPlane.Raycast(mRay, out rayDistance))    //This check the contact of RayCast with plane and return the distance
            {
                thisLine.transform.position = mRay.GetPoint(rayDistance);
            }

        }
        else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
                     
           pointsSelected = LineTouch.GetCollidedObjects();

           Debug.Log("points selected = " + pointsSelected.ToString()); 
            // Check if the line makes the corect shape
            //if (TouchManager.mTouchManager.mTouchLogic.checkShapes(TouchLogic.Shapes.Triangle5X3YLeft, ref pointsSelected))
            if(TouchManager.mTouchManager.mTouchLogic.checkShapes(TouchManager.mTouchManager.GetCurrentShape().GetComponent<Shapes>().GetShpeType(), ref pointsSelected))
            {

               Debug.Log("Correct Shape");
               TouchManager.mTouchManager.DeleteCurrentShape(); //Delete current shape and Instantiate a new one


               Destroy(thisLine);

               foreach(GameObject GO in pointsSelected)
               {
                   GO.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
               }

                LastShapeCorect = true;

                //Add points to score
                UIManage.instance.AddScore(TouchManager.mTouchManager.GetCurrentShape().GetComponent<Shapes>().points);

                //Add points to score
                UIManage.instance.AddTime(TouchManager.mTouchManager.GetCurrentShape().GetComponent<Shapes>().timeBonus);




                //Call the winning animation or add points or ...

            }
           else
           {
               Debug.Log("Wrong Shape");

               //Destroi the line , may add some stuff in future to make player know that made mistake
               Destroy(thisLine);
               Debug.Log("GOs 2 size = " + pointsSelected.Count.ToString());
               foreach (GameObject GO in pointsSelected)
               {
                   GO.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
               }

               pointsSelected.Clear();
           }
           
               
        }
    }

    public void SetSelectedPoint(ref GameObject point)
    {
        Debug.Log(" -----------    "+point.name.ToString());


        pointsSelected.Add(point);
    }



}
