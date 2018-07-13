using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {

	public int width = 6;
	public int height = 6;

	public HexCell cellPrefab;
	HexCell[] cells;

	public Text cellLabelPrefab;
	Canvas gridCanvas;


	void Awake() {
		gridCanvas = GetComponentInChildren<Canvas>();

		cells = new HexCell[height * width];

		for (int z=0, i=0; z < height; z++) {
			for (int x=0; x < width; x++) {
				CreateCell(x, z, i++);
			}
		}
	}

	void CreateCell(int x, int z, int i) {
		Vector3 pos = new Vector3(x * 10f, 0, z * 10f);

		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = pos;
	}

}
