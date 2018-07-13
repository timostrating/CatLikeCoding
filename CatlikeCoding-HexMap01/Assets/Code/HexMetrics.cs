using UnityEngine;

public class HexMetrics : MonoBehaviour {

	
	public const float outerRadius = 10f;

	public const float innerRadius = outerRadius * 0.866025404f; 	// outer * sqrt(3) / 2


	public static Vector3[] corners = {
		new Vector3(0, 0, outerRadius),
		new Vector3(innerRadius, 0, 0.5f * outerRadius), 		// Mathf.Sqrt(Mathf.Pow(outerRadius, 2) - Mathf.Pow(innerRadius, 2))),
		new Vector3(innerRadius, 0, -0.5f * outerRadius), 		// Mathf.Sqrt(Mathf.Pow(outerRadius, 2) - Mathf.Pow(innerRadius, 2))),
		new Vector3(0, 0, -outerRadius),
		new Vector3(-innerRadius, 0, -0.5f * outerRadius), 		// Mathf.Sqrt(Mathf.Pow(outerRadius, 2) - Mathf.Pow(innerRadius, 2))),
		new Vector3(-innerRadius, 0, 0.5f * outerRadius), 		// Mathf.Sqrt(Mathf.Pow(outerRadius, 2) - Mathf.Pow(innerRadius, 2)))
	};

}
