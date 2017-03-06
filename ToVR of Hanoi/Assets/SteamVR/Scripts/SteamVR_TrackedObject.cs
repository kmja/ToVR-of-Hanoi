//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: For controlling in-game objects with tracked devices.
//
//=============================================================================

using UnityEngine;
using Valve.VR;

public class SteamVR_TrackedObject : MonoBehaviour
{
	public enum EIndex
	{
		None = -1,
		Hmd = (int)OpenVR.k_unTrackedDeviceIndex_Hmd,
		Device1,
		Device2,
		Device3,
		Device4,
		Device5,
		Device6,
		Device7,
		Device8,
		Device9,
		Device10,
		Device11,
		Device12,
		Device13,
		Device14,
		Device15
	}

	public EIndex index;
	public Transform origin; // if not set, relative to parent
    public bool isValid = false;
	// NEW ***
	public float breakPoint = 0.3f;
	public float powFactor = 2f;
	// END NEW ***

	private void OnNewPoses(TrackedDevicePose_t[] poses)
	{
		if (index == EIndex.None)
			return;

		var i = (int)index;

        isValid = false;
		if (poses.Length <= i)
			return;

		if (!poses[i].bDeviceIsConnected)
			return;

		if (!poses[i].bPoseIsValid)
			return;

        isValid = true;

		var pose = new SteamVR_Utils.RigidTransform(poses[i].mDeviceToAbsoluteTracking);

		if (origin != null)
		{
			transform.position = origin.transform.TransformPoint(pose.pos);
			transform.rotation = origin.rotation * pose.rot;
		}
		else
		{
			//transform.localPosition = pose.pos; //ORIGINAL
			// NEW *****
			// Within a certain distance, controller behaves as normal. Beyond that distance, it exponentially gains more relative movement
			Vector3 chest = GameObject.Find("Camera (eye)").transform.localPosition; // Approximate position of chest based on head position
			Vector3 chestToController = pose.pos - chest;
			if (chestToController.magnitude < breakPoint) {
				transform.localPosition = pose.pos;
			} else {
				// Formula for changing CD ratio: when the distance between controller and chest passes the breakpoint, the distance from chest to controller beyond the breakpoint is raised to the power of powFactor 
				transform.localPosition = GameObject.Find ("Camera (eye)").transform.localPosition + chestToController * Mathf.Pow(1f + chestToController.magnitude - breakPoint, powFactor);
			}
			// END NEW *****
			transform.localRotation = pose.rot;
		}
	}

	SteamVR_Events.Action newPosesAction;

	void Awake()
	{
		newPosesAction = SteamVR_Events.NewPosesAction(OnNewPoses);
	}

	void OnEnable()
	{
		var render = SteamVR_Render.instance;
		if (render == null)
		{
			enabled = false;
			return;
		}

		newPosesAction.enabled = true;
	}

	void OnDisable()
	{
		newPosesAction.enabled = false;
		isValid = false;
	}

	public void SetDeviceIndex(int index)
	{
		if (System.Enum.IsDefined(typeof(EIndex), index))
			this.index = (EIndex)index;
	}
}

