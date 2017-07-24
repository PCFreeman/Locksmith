using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class will hold functions for touch logic. No need to have Start and Update. Will be element of TouchManager


public class TouchLogic {
        
	public enum Shapes
    {
        Triangle
            //Add here all shapes of our game
    }

    public bool checkShapes(Shapes shape)
    {

        switch(shape)
        {
            case Shapes.Triangle:
                return checkTriangle();
                break;

            default:
                Debug.Log("[TouchLogic]Shape name does not exit.");
                break;
        }

        return false;
    }






    private bool checkTriangle()
    {

        //return false;

        return true;
    }





}
