using UnityEngine;

public class Graph : MonoBehaviour {

	public Transform pointPrefab;
	[Range(10, 100)]
	public int resolution = 10;
	public GraphFunctionName function; 

	static GraphFunction[] functions = { 
		SineFunction, Sine2DFunction, MultiSineFunction
	};


	Transform[] points;

	void Awake () {
		float step = 2f / resolution;
		Vector3 scale = Vector3.one * step;
		Vector3 position = Vector3.zero;
		points = new Transform[resolution * resolution];

		for(int i=0, z=0; z < resolution; z++) {
			position.z = (z + 0.5f) * step - 1f;			
			for(int x=0; x < resolution; i++, x++) {
				Transform point = Instantiate(pointPrefab);
				position.x = (x + 0.5f) * step - 1f;
				point.localPosition = position;
				point.localScale = scale;
				point.SetParent(transform, false);
				points[i] = point;
			}
		}
	}

	void Update() {
		float t = Time.time;
		GraphFunction f = functions[(int)function];
		for(int i=0; i < points.Length; i++) { 
			Transform point = points[i];
			Vector3 position = point.localPosition;
			position.y = f(position.x, position.z, t);
			point.localPosition = position;
		}
	}

	const float pi = Mathf.PI;

	static float SineFunction(float x, float z, float t) {
		return Mathf.Sin(pi * (x + t));
	}

	static float Sine2DFunction(float x, float z, float t) {
		float y = Mathf.Sin(pi * (x + t));
		y += Mathf.Sin(pi * (z + t));
		y *= 0.5f;
		return y;
	}

	static float MultiSineFunction(float x, float z, float t) {
		float y = Mathf.Sin(pi * (x + t));
		y += Mathf.Sin(2f * pi * (x + 2f * t)) / 2f;
		y *= 2f / 3f;
		return y;
	}

	static float MultiSine2DFunction(float x, float z, float t) {
		float y = Mathf.Sin(pi * (x + t));
		y += Mathf.Sin(2f * pi * (x + 2f * t)) / 2f;
		y *= 2f / 3f;
		return y;
	}
}