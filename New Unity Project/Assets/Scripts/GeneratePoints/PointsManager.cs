using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour {

    public int numberLines;
    public int numberPointsInLine;
    public bool isMovingUp;
    public bool isMovingSides;

    public GameObject pointsAreaPrefab;
    public GameObject pointsLinesPrefab;
    public GameObject pointsPrefab;

    private GameObject pointsArea;
    private List<GameObject> pointsLines;       // This controls the lines structures, not content
    private List<List<GameObject>> points;      //for [x][y]   ,  each X will represent a line and each Y will represent a point in a line X



    private void Awake()
    {
        isMovingUp = false;
        isMovingSides = false;
    }
    

    // Use this for initialization
    void Start () {

        GeneratePoints();
        Debug.Log("Teste");

    }
	
	// Update is called once per frame
	void Update () {
		



	}



    //Will genarate the Points Area
    private void GeneratePoints()
    {
        //Helper variable
        int check = 0;
        


        //Initialize the List that will hold PointLines
        pointsLines = new List<GameObject>();

        //Initialize the 2D List that will hold Points
        points = new List<List<GameObject>>();

        //Instantiate Points container
        pointsArea = (GameObject)Instantiate(pointsAreaPrefab, new Vector3(-20,0,-20), Quaternion.identity);

        pointsArea.name = "Points Area";


        //Variables to generate Points

        int heightLines = (int)pointsArea.GetComponent<BoxCollider>().size.y / numberLines;

        int heightPoints = (int)(heightLines * 0.8);

        int widthPoints = heightPoints;

        //Change size of points prefab
        pointsPrefab.transform.localScale = new Vector3(widthPoints, heightPoints , pointsPrefab.transform.localScale.z) ;

        //Variables to set Points positions in a Line

        int emptyLineAreaSize = ((int)pointsLinesPrefab.GetComponent<BoxCollider>().size.x - (numberPointsInLine * widthPoints)) / (numberPointsInLine - 1);

        
        //For Loop to instantiate Lines
        for(int i = 0; i < numberLines; ++i)
        {
            //Instantiate Line
            GameObject line = (GameObject)Instantiate(pointsLinesPrefab, new Vector3(-20, 0, -20), Quaternion.identity);

            //Set it as child of pointsArea
            line.transform.parent = GameObject.Find("Points Area").transform;

            line.name = "Line " + i.ToString();

            //Set line height
            line.GetComponent<BoxCollider>().size = new Vector3(line.GetComponent<BoxCollider>().size.x, heightLines, line.GetComponent<BoxCollider>().size.z);

            

            
            //Line Goes down
            if (i % 2 == 1)
            {
                check = check + 1;

                int yOffset = -(heightLines * check);

                line.transform.position = new Vector3(line.transform.position.x, line.transform.position.y + yOffset, line.transform.position.z);

                
            }
            else //Line goes up
            {
                int yOffset = heightLines * check;
                
                line.transform.position = new Vector3(line.transform.position.x, line.transform.position.y + yOffset, line.transform.position.z);
                
            }

            List<GameObject> pointsList = new List<GameObject>();

            //Control variable
            int checkPoints = 0;


            for (int j = 0; j < numberPointsInLine; ++j)
            {

                //Instantiate Line
                GameObject pointTemp = (GameObject)Instantiate(pointsPrefab, new Vector3(-20, 0, -20), Quaternion.identity);

                //Set it as child of pointsArea
                pointTemp.transform.parent = GameObject.Find("Line " + i.ToString()).transform;

                pointTemp.name = "Point " + j.ToString();



                if (j % 2 == 1)
                {
                    checkPoints = checkPoints + 1;

                    int xOffset = -((widthPoints + emptyLineAreaSize) * checkPoints);


                    pointTemp.transform.position = new Vector3(pointTemp.transform.position.x + xOffset, line.transform.position.y, pointTemp.transform.position.z);

                }
                else //Line goes up
                {
                    int xOffset = (widthPoints + emptyLineAreaSize) * checkPoints;

                    pointTemp.transform.position = new Vector3(pointTemp.transform.position.x + xOffset, line.transform.position.y, pointTemp.transform.position.z);

                }


                pointsList.Add(pointTemp);  //Temp list

                points.Add(pointsList);     //2D List

                pointsLines.Add(line);      //Line List

            }


        }


            
        
    }


    public float GetDistanceBetweenLinePoints()
    {
        return points[0][2].transform.position.x - points[0][0].transform.position.x;
    }

    public float GetDistanceBetweenLines()
    {
        return points[2][0].transform.position.x - points[0][0].transform.position.x;
    }



}
