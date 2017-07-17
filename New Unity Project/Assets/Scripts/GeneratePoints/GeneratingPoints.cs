using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingPoints : MonoBehaviour
{

    [SerializeField]
    private GameObject circlePrefab;

    private int mNumPoints = 10;
    private GameObject[] Points;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < mNumPoints; i++)
        {
            for (int j = 0; j < mNumPoints; j++)
            {
                Instantiate(circlePrefab, new Vector3(i + 1, j + 1, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

