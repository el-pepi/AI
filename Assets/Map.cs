using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour {

	public static int [,] tiles;
	public static int [,] weights;
	GameObject[,] objects;
	GameObject[,] objectsW;

	public InputField width,height;

	public GameObject emptyTile, blockTile,start,end,wPref;

	public Toggle blockToggle, startToggle, endToggle,weightToggle;
	public Transform wCanvas;
	public InputField wField;

	public static int startX,startY,endX,endY;

	public void CreateMap(){
		if (objects != null) {
			foreach (GameObject g in objects) {
				Destroy (g);
			}
		}
		if (objectsW != null) {
			foreach (GameObject g in objectsW) {
				Destroy (g);
			}
		}
		tiles = new int[int.Parse(width.text),int.Parse(height.text)];
		weights = new int[int.Parse(width.text),int.Parse(height.text)];
		objects = new GameObject[tiles.GetLength(0),tiles.GetLength(1)];
		objectsW = new GameObject[tiles.GetLength(0),tiles.GetLength(1)];

		for (int x = 0; x < tiles.GetLength(0); x++) {
			for (int y = 0; y < tiles.GetLength(1); y++) {
				tiles [x, y] = 0;
				objects [x, y] = Instantiate (emptyTile,new Vector3(x,y,0),Quaternion.identity);
				objectsW [x, y] = Instantiate (wPref,new Vector3(x,y,0),Quaternion.identity,wCanvas);
			}
		}

		Camera.main.transform.position = new Vector3 (tiles.GetLength(0)/2-0.5f,tiles.GetLength(1)/2-0.5f,-10);
	}

	public void OnClick(){
		if (blockToggle.isOn) {
			PlaceBlock ();
		}
		if (startToggle.isOn) {
			PlaceStart ();
		}
		if (endToggle.isOn) {
			PlaceEnd ();
		}
		if (weightToggle.isOn) {
			SetWeight ();
		}
	}

	void SetWeight(){
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		int x = Mathf.RoundToInt(mousePos.x);
		int y = Mathf.RoundToInt(mousePos.y);
		weights [x, y] = int.Parse (wField.text);
		objectsW [x, y].GetComponent<Text> ().text = wField.text;
	}

	void PlaceBlock(){
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		int x = Mathf.RoundToInt(mousePos.x);
		int y = Mathf.RoundToInt(mousePos.y);
		if (x < 0 || x >= tiles.GetLength (0) || y < 0 || y >= tiles.GetLength (1)) {
			return;
		}

		Destroy(objects[x,y]);
		if (tiles [x, y] == 0) {
			tiles [x, y] = 1;
			objects [x, y] = Instantiate (blockTile, new Vector3 (x, y, 0), Quaternion.identity);
		} else {
			tiles [x, y] = 0;
			objects [x, y] = Instantiate (emptyTile, new Vector3 (x, y, 0), Quaternion.identity);
		}
	}

	void PlaceStart(){
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		int x = Mathf.RoundToInt(mousePos.x);
		int y = Mathf.RoundToInt(mousePos.y);
		if (x < 0 || x >= tiles.GetLength (0) || y < 0 || y >= tiles.GetLength (1)) {
			return;
		}
		startX = x;
		startY = y;
		start.transform.position = new Vector3 (x,y,0);
	}

	void PlaceEnd(){
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		int x = Mathf.RoundToInt(mousePos.x);
		int y = Mathf.RoundToInt(mousePos.y);
		if (x < 0 || x >= tiles.GetLength (0) || y < 0 || y >= tiles.GetLength (1)) {
			return;
		}
		endX = x;
		endY = y;
		end.transform.position = new Vector3 (x,y,0);
	}
}
