using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdaptiveText : MonoBehaviour
{
    private float height;
    private float width;
    private float resolution;
    private Vector3 textPosition;
    [SerializeField] Text[] texts;
    [SerializeField] RectTransform[] spacingVertical;     
    [SerializeField] RectTransform[] buttonsSize;
    [SerializeField] RectTransform spacingRight;
    [SerializeField] RectTransform spacingLeft;

    //Just for testing
    //[SerializeField] private float spacingVertical;
    //[SerializeField] private float spacingHorizontal;
   

    // Start is called before the first frame update
    private void Awake()
    {
        width = Screen.width;
        height = Screen.height;
        resolution = width / height;
    }
    void Start()
    {
        ScaleText(texts);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Width is: " + width + " :: " + "Height is: " + height + " :: " + "Resolution is: " + resolution);
        //width = Screen.width;
        //height = Screen.height;
        //resolution = width / height;
        
    }

    private void ScaleText(Text[] texts)
    {
        if (resolution >= 0.7)
        {
            ScaleFontSize(texts, 40);
            AddSpacingHorizontal(spacingRight, -0.16f, "right");
            AddSpacingHorizontal(spacingLeft, -0.16f, "left");
            Debug.Log("Ratio: 4:3");
        }
        else if (resolution > 0.5)
        {
            ScaleFontSize(texts, 34);
            AddSpacingHorizontal(spacingRight, -0.1f, "right");
            AddSpacingHorizontal(spacingLeft, -0.1f, "left");
            AddSpacingVertical(spacingVertical, 0.1f);
            ButtonSize(buttonsSize, 90, 90);
            Debug.Log("Ratio: 16:9");
        }
        else
        {
            ScaleFontSize(texts, 28);
            AddSpacingVertical(spacingVertical, 0.1f);
            ButtonSize(buttonsSize, 80, 80);
            Debug.Log("Ratio: 90:195");
        }
        
    }

    private void ScaleFontSize(Text[] texts, int size)
    {
        foreach (var text in texts)
        {
            text.fontSize = size;
        }
    }

    private void AddSpacingVertical(RectTransform[] texts, float spacing)
    {
        foreach (var text in texts)
        {
            textPosition = text.transform.position;
            //Debug.Log("Initial position: " + textPosition);
            textPosition.y += spacing;
            text.transform.position = textPosition;
            //Debug.Log("Final Position: " + textPosition);
            
        }
    }

    private void AddSpacingHorizontal(RectTransform item, float spacing, string leftRight)
    {
        textPosition = item.transform.position;
        //Debug.Log("Initial position: " + textPosition);

        if (leftRight == "right")
        {
            textPosition.x += spacing;
        }
        else
        {
            textPosition.x -= spacing;
        }

        item.transform.position = textPosition;
        //Debug.Log("Final Position: " + textPosition);
        
    }

    private void ButtonSize (RectTransform[] buttons, int width, int height)
    {
        foreach (RectTransform button in buttons)
        {
            button.sizeDelta = new Vector2(width, height);
        }
    }

}
