using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode,RequireComponent(typeof(Animator))]
public class IKEditor : MonoBehaviour {

	private Animator m_TargetAnimator;

	public bool m_EnableIK = false;

	public GameObject m_LeftFootIKGoal;
	public GameObject m_RightFootIKGoal;
	public GameObject m_LeftHandIKGoal;
	public GameObject m_RightHandIKGoal;

	public GameObject m_LeftKneeIKHint;
	public GameObject m_RightKneeIKHint;
	public GameObject m_LeftElbowIKHint;
	public GameObject m_RightElbowIKHint;


	public float m_LeftFootPositionWeight = 0f;
	public float m_RightFootPositionWeight= 0f;
	public float m_LeftFootRotationWeight = 0f;
	public float m_RightFootRotationWeight = 0f;

	public float m_LeftHandPositionWeight = 0f;
	public float m_RightHandPositionWeight = 0f;
	public float m_LeftHandRotationWeight = 0f;
	public float m_RightHandRotationWeight = 0f;


	public float m_LeftKneePositionWeight = 0f;
	public float m_RightKneePositionWeight = 0f;
	public float m_LeftElbowPositionWeight = 0f;
	public float m_RightElbowPositionWeight = 0f;

	private GameObject CreateIKGoal(string goalName)
	{
		GameObject newObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		newObj.name = goalName;
		newObj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
		return newObj;
	}

	void Start()
	{
		m_TargetAnimator = GetComponent<Animator>();

		if(m_LeftFootIKGoal == null)
			m_LeftFootIKGoal = CreateIKGoal("Left Foot Goal");
		if(m_RightFootIKGoal == null) m_RightFootIKGoal = CreateIKGoal("Right Foot Goal");
		if(m_LeftHandIKGoal == null) m_LeftHandIKGoal = CreateIKGoal("Left Hand Goal");
		if(m_RightHandIKGoal == null) m_RightHandIKGoal = CreateIKGoal("Right Hand Goal");
		if(m_LeftKneeIKHint == null) m_LeftKneeIKHint = CreateIKGoal("Left Knee IK Hint");
		if(m_RightKneeIKHint == null) m_RightKneeIKHint = CreateIKGoal("Right Knee IK Hint");
		if(m_LeftElbowIKHint == null) m_LeftElbowIKHint = CreateIKGoal("Left Elbow IK Hint");
		if(m_RightElbowIKHint == null) m_RightElbowIKHint = CreateIKGoal("Right Elbow IK Hint");
	}

	void Update()
	{
		m_TargetAnimator.Update(0f);
	}

	void OnAnimatorIK(int layerIndex)
	{
		m_TargetAnimator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, m_LeftFootPositionWeight);
        m_TargetAnimator.SetIKPositionWeight(AvatarIKGoal.RightFoot, m_RightFootPositionWeight);
        m_TargetAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, m_LeftHandPositionWeight);
        m_TargetAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, m_RightHandPositionWeight);
 
        m_TargetAnimator.SetIKHintPositionWeight(AvatarIKHint.LeftKnee, m_LeftKneePositionWeight);
        m_TargetAnimator.SetIKHintPositionWeight(AvatarIKHint.RightKnee, m_RightKneePositionWeight);
        m_TargetAnimator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, m_LeftElbowPositionWeight);
        m_TargetAnimator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, m_RightElbowPositionWeight);
 
        m_TargetAnimator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, m_LeftFootRotationWeight);
        m_TargetAnimator.SetIKRotationWeight(AvatarIKGoal.RightFoot, m_RightFootRotationWeight);
        m_TargetAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, m_LeftHandRotationWeight);
        m_TargetAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, m_RightHandRotationWeight);
 
        if (m_EnableIK)
        {
            m_TargetAnimator.SetIKPosition(AvatarIKGoal.LeftFoot, m_LeftFootIKGoal.transform.position);
            m_TargetAnimator.SetIKHintPosition(AvatarIKHint.LeftKnee, m_LeftKneeIKHint.transform.position);
            m_TargetAnimator.SetIKRotation(AvatarIKGoal.LeftFoot, m_LeftFootIKGoal.transform.rotation);
 
            m_TargetAnimator.SetIKPosition(AvatarIKGoal.RightFoot, m_RightFootIKGoal.transform.position);
            m_TargetAnimator.SetIKHintPosition(AvatarIKHint.RightKnee, m_RightKneeIKHint.transform.position);
            m_TargetAnimator.SetIKRotation(AvatarIKGoal.RightFoot, m_RightFootIKGoal.transform.rotation);
 
            m_TargetAnimator.SetIKPosition(AvatarIKGoal.LeftHand, m_LeftHandIKGoal.transform.position);
            m_TargetAnimator.SetIKHintPosition(AvatarIKHint.LeftElbow, m_LeftElbowIKHint.transform.position);
            m_TargetAnimator.SetIKRotation(AvatarIKGoal.LeftHand, m_LeftHandIKGoal.transform.rotation);
 
            m_TargetAnimator.SetIKPosition(AvatarIKGoal.RightHand, m_RightHandIKGoal.transform.position);
            m_TargetAnimator.SetIKHintPosition(AvatarIKHint.RightElbow, m_RightElbowIKHint.transform.position);
            m_TargetAnimator.SetIKRotation(AvatarIKGoal.RightHand, m_RightHandIKGoal.transform.rotation);
        }
        else
        {
            m_LeftFootIKGoal.transform.position = m_TargetAnimator.GetIKPosition(AvatarIKGoal.LeftFoot);
            m_LeftKneeIKHint.transform.position = m_TargetAnimator.GetIKHintPosition(AvatarIKHint.LeftKnee);
            m_LeftFootIKGoal.transform.rotation = m_TargetAnimator.GetIKRotation(AvatarIKGoal.LeftFoot);
 
            m_RightFootIKGoal.transform.position = m_TargetAnimator.GetIKPosition(AvatarIKGoal.RightFoot);
            m_RightKneeIKHint.transform.position = m_TargetAnimator.GetIKHintPosition(AvatarIKHint.RightKnee);
            m_RightFootIKGoal.transform.rotation = m_TargetAnimator.GetIKRotation(AvatarIKGoal.RightFoot);
 
            m_LeftHandIKGoal.transform.position = m_TargetAnimator.GetIKPosition(AvatarIKGoal.LeftHand);
            m_LeftElbowIKHint.transform.position = m_TargetAnimator.GetIKHintPosition(AvatarIKHint.LeftElbow);
            m_LeftHandIKGoal.transform.rotation = m_TargetAnimator.GetIKRotation(AvatarIKGoal.LeftHand);
 
            m_RightHandIKGoal.transform.position = m_TargetAnimator.GetIKPosition(AvatarIKGoal.RightHand);
            m_RightElbowIKHint.transform.position = m_TargetAnimator.GetIKHintPosition(AvatarIKHint.RightElbow);
            m_RightHandIKGoal.transform.rotation = m_TargetAnimator.GetIKRotation(AvatarIKGoal.RightHand);
        }
	}
}
