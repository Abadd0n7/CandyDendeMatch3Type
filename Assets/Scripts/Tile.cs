using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Tile : MonoBehaviour {
	//private static Color selectedColor = new Color(.5f, .5f, .5f, 1.0f);
	private static Tile previousSelected = null;
    private Renderer rend;
    private GameObject go;
	private bool isSelected = false;

	//private Vector2[] adjacentDirections = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

	void Awake() {
		go = GetComponent<GameObject>();
    }

	private void Select() {
		isSelected = true;
		//go. = selectedColor;
		previousSelected = gameObject.GetComponent<Tile>();
		//SFXManager.instance.PlaySFX(Clip.Select);
	}

	private void Deselect() {
		isSelected = false;
		//go.color = Color.white;
		previousSelected = null;
	}
    void OnMouseDown()
    {
        // 1
        if (go == null || BoardManager.Instance.IsShifting)
        {
            Debug.Log(BoardManager.Instance.IsShifting.Equals(true));
            return;
        }

        if (isSelected)
        { // 2 Is it already selected?
            Deselect();
        }
        else
        {
            if (previousSelected == null)
            { // 3 Is it the first tile selected?
                Debug.Log(BoardManager.Instance.IsShifting.Equals(true));
                Select();
                Debug.Log(BoardManager.Instance.IsShifting.Equals(true));
            }
            else
            {
                Debug.Log(BoardManager.Instance.IsShifting.Equals(true));
                previousSelected.Deselect(); // 4
                Debug.Log(BoardManager.Instance.IsShifting.Equals(true));
            }
        }
    }
}