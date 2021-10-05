using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    //When reached finih show this.
    [SerializeField]private Text finalTime;
    [SerializeField]private Text finalObjects;

    //private void Start()
    //{
    //    finalObjects = GameObject.Find("Text_ResulTime");
    //}

    public void GetTime(string resultTime)
    {
        finalTime.text = "Time: " + resultTime;
    }

    public void GetObjects(string resultObjects)
    {
        finalObjects.text = "Total objects: " + resultObjects;
    }
}
