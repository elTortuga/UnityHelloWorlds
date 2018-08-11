using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObject : MonoBehaviour {


	public Transform target;
	public Camera mainCamera;
	public float distance;
	public float heightDifference;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		PointCameraAtTarget();
		
	}

	void PointCameraAtTarget() {
		this.mainCamera.transform.LookAt(target);
	}

	// Move Camera's postion in a circular path around the target along the X Z plane of the target.  Future versions maybe circle around the object at a variable distance, spherically around the tartget, or cylindrically around the target.
	void MoveAroundTarget(){

	}
}
