using System.IO;
using UnityEngine;

public class PersistentStorage : MonoBehaviour {

	string savePath;

	// Use this for initialization
	void Awake () {
		savePath = Path.Combine(Application.persistentDataPath, "saveFile");
	}
	
	public void Save(PersistableObject o) {
		using (
			BinaryWriter writer = new BinaryWriter(File.Open(savePath, FileMode.Create))
		) {
			o.Save(new GameDataWriter(writer));
		}
	}

	public void Load(PersistableObject o) {
		using (
			BinaryReader reader = new BinaryReader(File.Open(savePath, FileMode.Open))
		) {
			o.Load(new GameDataReader(reader));
		}
	}
}
