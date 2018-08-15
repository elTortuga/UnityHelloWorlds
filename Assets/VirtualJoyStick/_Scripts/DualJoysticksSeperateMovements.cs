using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualJoysticksSeperateMovements : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    private Vector2 offset;
    private Vector2 direction;

    private Vector3 mouseInputPosition;

    // public Transform circle;
    public SpriteRenderer circle;
    public SpriteRenderer outerCircle;

    void Start()
    {
        mouseInputPosition = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
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

    }
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}