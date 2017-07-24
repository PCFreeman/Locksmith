using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingPoints : MonoBehaviour
{

    [SerializeField]
    private GameObject circlePrefab;

    private int mNumPoints = 500;
   //private GameObject[] Points;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < mNumPoints; i+=25)
        {
            for (int j = 0; j < mNumPoints; j+=25)
            {
                Instantiate(circlePrefab, new Vector3(i, j, -1), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

