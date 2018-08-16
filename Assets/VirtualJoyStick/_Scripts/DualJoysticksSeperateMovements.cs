using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DualJoysticksSeperateMovements : MonoBehaviour
{
    public Transform player;
    public Transform playerRight;
    public float speed = 5.0f;
    public float middleOfScreenX;
    private bool touchStart = false;
    private bool touchStartRight = false;
    private Vector2 pointA;
    private Vector2 pointB;
    private Vector2 pointARight;
    private Vector2 pointBRight;
    private Vector2 offset;
    private Vector2 offsetRight;
    private Vector2 direction;
    private Vector2 directionRight;

    private Vector3 mouseInputPosition;
    private Vector3 mouseInputPositionRight;

    // public Transform circle;
    public SpriteRenderer circle;
    public SpriteRenderer outerCircle;
    public SpriteRenderer circleRight;
    public SpriteRenderer outerCircleRight;

    private Touch[] myTouches;
    private Touch leftTouch;
    private Touch rightTouch;

    void Start()
    {
        mouseInputPosition = new Vector3();
        middleOfScreenX = Screen.width / (float)2;
    }

    // Update is called once per frame
    void Update()
    {
#if (UNITY_STANDALONE || UNITY_WEBPLAYER)
        if (Input.GetMouseButtonDown(0))
        {
            mouseInputPosition.Set(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z);
            pointA = Camera.main.ScreenToWorldPoint(mouseInputPosition);

            circle.transform.position = pointA * -1;
            outerCircle.transform.position = pointA * -1;
            circle.enabled = true;
            outerCircle.enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            mouseInputPosition.Set(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z);
            pointB = Camera.main.ScreenToWorldPoint(mouseInputPosition);
        }
        else
        {
            touchStart = false;
        }

#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 2)
            {
                if (Input.touches[0].position.x < middleOfScreenX)
                {
                    leftTouch = Input.touches[0];
                    rightTouch = Input.touches[1];
                }
                else
                {
                    leftTouch = Input.touches[1];
                    rightTouch = Input.touches[0];
                }
            }
            else if (Input.touchCount == 1)
            {
                if (Input.touches[0].position.x < middleOfScreenX)
                {
                    leftTouch = Input.touches[0];
                }
                else
                {
                    rightTouch = Input.touches[0];
                }
            }

            if (leftTouch.phase == TouchPhase.Began)
            {
                mouseInputPosition.Set(leftTouch.position.x, leftTouch.position.y, Camera.main.transform.position.z);
                pointA = Camera.main.ScreenToWorldPoint(mouseInputPosition);

                circle.transform.position = pointA * -1;
                outerCircle.transform.position = pointA * -1;
                circle.enabled = true;
                outerCircle.enabled = true;
            }
            if (leftTouch.phase == TouchPhase.Moved || leftTouch.phase == TouchPhase.Began || leftTouch.phase == TouchPhase.Stationary)
            {
                touchStart = true;
                mouseInputPosition.Set(leftTouch.position.x, leftTouch.position.y, Camera.main.transform.position.z);
                pointB = Camera.main.ScreenToWorldPoint(mouseInputPosition);
            }
            else
            {
                touchStart = false;
            }
            //For the right player
            if (rightTouch.phase == TouchPhase.Began)
            {
                mouseInputPositionRight.Set(rightTouch.position.x, rightTouch.position.y, Camera.main.transform.position.z);
                pointARight = Camera.main.ScreenToWorldPoint(mouseInputPositionRight);

                circleRight.transform.position = pointARight * -1;
                outerCircleRight.transform.position = pointARight * -1;
                circleRight.enabled = true;
                outerCircleRight.enabled = true;
            }
            if (rightTouch.phase == TouchPhase.Moved || rightTouch.phase == TouchPhase.Began || rightTouch.phase == TouchPhase.Stationary)
            {
                touchStartRight = true;
                mouseInputPositionRight.Set(rightTouch.position.x, rightTouch.position.y, Camera.main.transform.position.z);
                pointBRight = Camera.main.ScreenToWorldPoint(mouseInputPositionRight);
            }
            else
            {
                touchStartRight = false;
            }
        }
#endif

    }

    private void FixedUpdate()
    {
        if (touchStart)
        {
            offset = pointB - pointA;
            direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction * -1);

            circle.transform.position = (pointA + direction) * -1;
        }
        else
        {
            circle.enabled = false;
            outerCircle.enabled = false;
        }

        if (touchStartRight)
        {
            offsetRight = pointBRight - pointARight;
            directionRight = Vector2.ClampMagnitude(offsetRight, 1.0f);
            moveCharacterRight(directionRight * -1);

            circleRight.transform.position = (pointARight + directionRight) * -1;
        }
        else
        {
            circleRight.enabled = false;
            outerCircleRight.enabled = false;
        }
    }
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
    void moveCharacterRight(Vector2 direction)
    {
        playerRight.Translate(direction * speed * Time.deltaTime);
    }
}