using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class will hold functions for touch logic. No need to have Start and Update. Will be element of TouchManager


public class TouchLogic {
        
	public enum Shapes
    {
        Triangle5X3YUP
        //Add here all shapes of our game
    }

    public bool checkShapes(Shapes shape, List<GameObject> points)
    {

        switch(shape)
        {
            case Shapes.Triangle5X3YUP:
                return checkTriangle5X3Y(points,true);
                break;

            default:
                Debug.Log("[TouchLogic]Shape name does not exit.");
                break;
        }

        return false;
    }






    private bool checkTriangle5X3Y(List<GameObject> points, bool isUp)
    {
        Debug.Log("Start Triangle Check");

        float distanceBetweenPointsX = GameObject.Find("GeneratePoints").GetComponent<PointsManager>().GetDistanceBetweenLinePoints();
        float distanceBetweenPointsY = GameObject.Find("GeneratePoints").GetComponent<PointsManager>().GetDistanceBetweenLines();

        Debug.Log(points.Count);

        //Check number of points
        if (points.Count < 8 || points.Count > 8)
        {
            return false;  
        }

        Debug.Log("Correct number of points!");


        //Check for UP

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

        //Check num of Points in each line 
        if ((Line1.Count == 5 && Line2.Count == 2 && Line3.Count == 1) ||
            (Line1.Count == 5 && Line2.Count == 1 && Line3.Count == 2) ||
             (Line1.Count == 2 && Line2.Count == 5 && Line3.Count == 1) ||
             (Line1.Count == 1 && Line2.Count == 5 && Line3.Count == 2) ||
             (Line1.Count == 2 && Line2.Count == 1 && Line3.Count == 5) ||
             (Line1.Count == 1 && Line2.Count == 2 && Line3.Count == 5))
        {

            List<List<GameObject>> LinesList = new List<List<GameObject>>();

            if (Line1.Count == 5)
            {
                if (Line2.Count == 2)
                {
                    LinesList.Add(sortLine(Line1));
                    LinesList.Add(sortLine(Line2));
                    LinesList.Add(sortLine(Line3));
                }
                else if (Line3.Count == 2)
                {
                    LinesList.Add(sortLine(Line1));
                    LinesList.Add(sortLine(Line3));
                    LinesList.Add(sortLine(Line2));
                }
                else
                {
                    Debug.Assert(false, "[TouchLogic] Lists with problems.");
                }
            }
            else if (Line2.Count == 5)
            {
                if (Line1.Count == 2)
                {
                    LinesList.Add(sortLine(Line2));
                    LinesList.Add(sortLine(Line1));
                    LinesList.Add(sortLine(Line3));
                }
                else if (Line3.Count == 2)
                {
                    LinesList.Add(sortLine(Line2));
                    LinesList.Add(sortLine(Line3));
                    LinesList.Add(sortLine(Line1));
                }
                else
                {
                    Debug.Assert(false, "[TouchLogic] Lists with problems.");
                }

            }
            else if (Line3.Count == 5)
            {
                if (Line1.Count == 2)
                {
                    LinesList.Add(sortLine(Line3));
                    LinesList.Add(sortLine(Line1));
                    LinesList.Add(sortLine(Line2));
                }
                else if (Line2.Count == 2)
                {
                    LinesList.Add(sortLine(Line3));
                    LinesList.Add(sortLine(Line2));
                    LinesList.Add(sortLine(Line1));
                }
                else
                {
                    Debug.Assert(false, "[TouchLogic] Lists with problems.");
                }

            }


            if (isUp == true)
            {
                //Check if Triangle is Up
                if (LinesList[0][0].transform.position.y > LinesList[1][0].transform.position.y ||
                    LinesList[0][0].transform.position.y > LinesList[2][0].transform.position.y ||
                    LinesList[1][0].transform.position.y > LinesList[2][0].transform.position.y)
                {
                    return false;
                }

                //Check Bottom X distances
                if ((LinesList[0][1].transform.position.x - LinesList[0][0].transform.position.y) != distanceBetweenPointsX ||
                    (LinesList[0][2].transform.position.x - LinesList[0][1].transform.position.y) != distanceBetweenPointsX ||
                    (LinesList[0][3].transform.position.x - LinesList[0][2].transform.position.y) != distanceBetweenPointsX ||
                    (LinesList[0][4].transform.position.x - LinesList[0][3].transform.position.y) != distanceBetweenPointsX)
                {
                    return false;
                }

                //Check Middle X distances
                if ((LinesList[1][1].transform.position.x - LinesList[1][0].transform.position.y) * 2 != distanceBetweenPointsX)
                {
                    return false;
                }

                //Check Line1 and Line2 points pos
                if ((LinesList[1][0].transform.position.x != LinesList[0][1].transform.position.x) ||
                       (LinesList[1][1].transform.position.x != LinesList[0][3].transform.position.x) ||
                       ((LinesList[1][0].transform.position.y - LinesList[0][1].transform.position.y) != distanceBetweenPointsY) ||
                       ((LinesList[1][1].transform.position.y - LinesList[0][3].transform.position.y) != distanceBetweenPointsY))
                {
                    return false;
                }

                if ((LinesList[2][0].transform.position.x != LinesList[0][2].transform.position.x) ||
                       ((LinesList[2][0].transform.position.y - LinesList[0][2].transform.position.y)*2 != distanceBetweenPointsY))
                {
                    return false;
                }

               
            }


            return true;
        }

        return false;


    }





    //=========================================================================
    //========================  Support Functions  ============================
    //=========================================================================

    private List<GameObject> sortLine(List<GameObject> list)
    {
        List<GameObject> temp = new List<GameObject>();

        if(list[0].transform.position.x < list[1].transform.position.x && list[0].transform.position.x < list[2].transform.position.x)
        {
            temp.Add(list[0]);

            if (list[1].transform.position.x < list[2].transform.position.x)
            {
                temp.Add(list[1]);
            }
            else
            {
                temp.Add(list[2]);
            }
            
        }
        else if (list[1].transform.position.x < list[0].transform.position.x && list[1].transform.position.x < list[2].transform.position.x)
        {
            temp.Add(list[1]);

            if (list[0].transform.position.x < list[2].transform.position.x)
            {
                temp.Add(list[0]);
            }
            else
            {
                temp.Add(list[2]);
            }

        }
        else if (list[2].transform.position.x < list[1].transform.position.x && list[2].transform.position.x < list[0].transform.position.x)
        {
            temp.Add(list[2]);

            if (list[1].transform.position.x < list[0].transform.position.x)
            {
                temp.Add(list[1]);
            }
            else
            {
                temp.Add(list[0]);
            }

        }

        return temp;
    }

}
