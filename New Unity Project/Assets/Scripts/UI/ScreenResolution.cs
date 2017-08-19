using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*For Screen resolution, if the canvas render mode is under  Screen Space - Camera, then we do not have access to canvas' value.
*/
public class ScreenResolution : MonoBehaviour
{

    public RectTransform rt;

    void Awake()
    {
        //Under Screen Space - Camera after change value is equal to the original value
        //Under World Space the after change value will change to the Screen.Width and Screen.Height, however the image size still don't change for some reason.
        Debug.Log("Hi from Screen Resolution!");
        rt = GetComponent<RectTransform>();
        Debug.Log("RectTransfor width = " + rt.rect.width);
        Debug.Log("RectTransfor height = " + rt.rect.height);
        rt.sizeDelta = new Vector2(Screen.width, Screen.height);
        Debug.Log("RectTransfor X After change =" + rt.rect.width);
        Debug.Log("RectTransfor Y After change = " + rt.rect.height);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
