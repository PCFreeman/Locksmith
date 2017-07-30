using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class will hold functions for touch logic. No need to have Start and Update. Will be element of TouchManager


public class TouchLogic {
        
	public enum Shapes
    {
        EquilateralTriangle3UP
        //Add here all shapes of our game
    }

    public bool checkShapes(Shapes shape, List<GameObject> points)
    {

        switch(shape)
        {
            case Shapes.EquilateralTriangle3UP:
                return checkEquilateralTriangle(points,3,true);
                break;

            default:
                Debug.Log("[TouchLogic]Shape name does not exit.");
                break;
        }

        return false;
    }






    private bool checkEquilateralTriangle(List<GameObject> points,int sidesSize, bool isUp)
    {
        float distanceBetweenPointsX = GameObject.Find("GenratePoints").GetComponent<PointsManager>().GetDistanceBetweenLinePoints();
        float distanceBetweenPointsY = GameObject.Find("GenratePoints").GetComponent<PointsManager>().GetDistanceBetweenLines();


        //Check number of points
        if (points.Count < ((sidesSize * 3 )-3) || points.Count > ((sidesSize * 3) - 3))
        {
            return false;  
        }
        
        //Check for UP
        if(isUp == true)
        {
            List<GameObject> Line1 = new List<GameObject>();
            List<GameObject> Line2 = new List<GameObject>();
            List<GameObject> Line3 = new List<GameObject>();


            foreach (GameObject GO in points)
            {
                if(Line1.Count == 0)
                {
                    Line1.Add(GO);
                }
                else
                {
                    if(GO.transform.position.y == Line1[0].transform.position.y)
                    {
                        Line1.Add(GO);
                    }
                    else
                    {
                        if(Line2.Count == 0)
                        {
                            Line2.Add(GO);
                        }
                        else
                        {
                            if (GO.transform.position.y == Line2[0].transform.position.y)
                            {
                                Line2.Add(GO);
                            }
                            else
                            {
                                if(Line3.Count == 0)
                                {
                                    Line3.Add(GO);
                                }
                                else
                                {
                                    if (GO.transform.position.y == Line3[0].transform.position.y)
                                    {
                                        Line3.Add(GO);
                                    }
                                    else
                                    {
                                        //Wrong shape
                                        return false;
                                    }
                                }

                            }

                        }


                    }


                }


            }

            if(Line1.Count > sidesSize || Line2.Count > sidesSize || Line3.Count > sidesSize)
            {
                return false;
            }
            else if(Line1.Count == 0 || Line2.Count == 0 || Line3.Count == 0)
            {
                return false;
            }




            //Need to sort all List and Also make an List of List to make the function work with any triangle size
            //After sort check the distance if they are correct







            if(Line1.Count == 3)
            {
                if(Line2.Count == 2)
                {
                    






                    
                }
                else
                {

                }

            }


        }
        




        return true;
    }





}
