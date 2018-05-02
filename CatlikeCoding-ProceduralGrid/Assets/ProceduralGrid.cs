using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralGrid : MonoBehaviour {
 
	public int xSize, ySize;
	private Vector3[] vertices;

	private Mesh mesh;
	

	private void Awake() {
		GetComponent<MeshFilter>().mesh = mesh = new Mesh();
		mesh.name = "Procedural Grid";
		StartCoroutine(Generate());
	}

	private IEnumerator Generate() {
		WaitForSeconds wait = new WaitForSeconds(0.05f);
		vertices = new Vector3[(xSize + 1) * (ySize + 1)];
		Vector2[] uv = new Vector2[vertices.Length];
		Vector4[] tangents = new Vector4[vertices.Length];
		Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);
		for (int y=0, i=0; y <= ySize; y++) {
			for (int x=0; x <= xSize; x++, i++) {
				vertices[i] = new Vector3(x, y);
				uv[i].x = (float)x / xSize;
				uv[i].y = (float)y / ySize;
				tangents[i] = tangent;
			}
		}
		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.tangents = tangents;

		int[] triangles = new int[xSize * ySize * 6];
		for (int y=0, ti=0, i=0; y < ySize; y++, i++) {
			for (int x=0; x < xSize; x++, ti += 6, i++) {
				triangles[ti + 0] = i;
				triangles[ti + 2] = triangles[ti + 3] = i + 1;
				triangles[ti + 4] = triangles[ti + 1] = i + xSize + 1;
				triangles[ti + 5] = i + xSize + 2;

				mesh.triangles = triangles;
				yield return wait;
			}
		}

		mesh.triangles = triangles;
		mesh.RecalculateNormals();
	}

	private void OnDrawGizmos() {
		if (vertices == null)
			return;
			
		Gizmos.color = Color.black;
		for (int i=0; i<vertices.Length; i++) {
			Gizmos.DrawSphere(vertices[i], 0.1f);
		}
	}
}
