using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleJoystickCanvas : MonoBehaviour
{
    public RectTransform canvasRectTran;
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    private Vector2 localPositionOffsetForImages;

    public Image circleImg;
    public Image outerCircleImg;

    private float heightOffset;
    private float widthOffset;
    private float quarterWidthOuterCircle;

    // Use this for initialization
    void Start()
    {  
        heightOffset = canvasRectTran.rect.height / 2;
        widthOffset = canvasRectTran.rect.width / 2 ;
        quarterWidthOuterCircle = outerCircleImg.rectTransform.rect.width / 4;

        pointA = new Vector2();
        pointB = new Vector2();
        localPositionOffsetForImages = new Vector2(widthOffset, heightOffset);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA.Set(Input.mousePosition.x, Input.mousePosition.y);

            circleImg.transform.localPosition = pointA - localPositionOffsetForImages;
            outerCircleImg.transform.localPosition = pointA - localPositionOffsetForImages;
            circleImg.enabled = true;
            outerCircleImg.enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB.Set(Input.mousePosition.x, Input.mousePosition.y);
        }
        else
        {
            touchStart = false;
        }
    }

    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;

            Vector2 direction = Vector2.ClampMagnitude(offset, quarterWidthOuterCircle);
            moveCharacter(direction/quarterWidthOuterCircle);

            circleImg.transform.localPosition = pointA + direction - localPositionOffsetForImages;
        }
        else
        {
            circleImg.enabled = false;
            outerCircleImg.enabled = false;
        }
    }

    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}
