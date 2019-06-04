using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{


    public static BoardManager Instance;

    public GameObject Tile;
    public GameObject Parent;

    public List<GameObject> Balls = new List<GameObject>();
    public int axisX, axisY;
    
    private GameObject[,] Tiles;
    public bool IsShifting { get; set; }


	// Use this for initialization
	void Start()
	{
	    Instance = GetComponent<BoardManager>();
        CreateBoard();
	}
	
    // Update is called once per frame
	void Update()
	{
		
	}

    private void CreateBoard()
    {
        Tiles = new GameObject[axisX, axisY];

        GameObject[] previousLeft = new GameObject[axisY];
        GameObject previousBelow = null;

        for (int i = 0; i < axisX; i++)
        {
            for (int j = 0; j < axisY; j++)
            {
                GameObject newTile = Instantiate(Tile, new Vector3(i, j, 0),
                    Quaternion.identity);

                newTile.transform.SetParent(Parent.transform); 

                Tiles[i, j] = newTile;

                List<GameObject> possibleCharacters = new List<GameObject>(); // 1
                possibleCharacters.AddRange(Balls); // 2

                possibleCharacters.Remove(previousLeft[j]); // 3
                possibleCharacters.Remove(previousBelow);

                Tile = possibleCharacters[Random.Range(0, possibleCharacters.Count)];

                previousLeft[j] = Tile;
                previousBelow = Tile;
            }
        }

    }

    private void OnMouseClick()
    {

    }
}
