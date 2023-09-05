using UnityEngine;

public class RevealingLightRotation : MonoBehaviour
{
	private Quaternion initRotation;

	private void Start ()
	{
		 initRotation = transform.rotation;
	}
	
	private void LateUpdate ()
	{
		transform.rotation = initRotation;
	}
}