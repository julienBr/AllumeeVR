using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
	[SerializeField] private float planetSpeedRotation = 1.0f;

	private void LateUpdate ()
	{
		transform.Rotate(-Vector3.up * (Time.deltaTime * planetSpeedRotation));
	}
}