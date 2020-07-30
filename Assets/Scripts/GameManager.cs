using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Sprite[] spritePatches;
	private readonly int colNumber = 3;
	private readonly int rowNumber = 3;
	private GameObject[,] patches;
	public Vector2 patchXRange, patchYRange;
	void Start()
	{
		patches = new GameObject[colNumber, rowNumber];
		spritePatches = Resources.LoadAll<Sprite>("Patches");
		CreatePatchObj(spritePatches);
	}

	void Update()
	{
		
	}

	private void CreatePatchObj(Sprite[] sprites)
    {
		for (int row = 0; row < rowNumber; row++)
        {
            for (int col = 0; col < colNumber; col++)
            {
				patches[row, col] = new GameObject("patch" + row + col);
				patches[row, col].AddComponent<SpriteRenderer>().sprite = sprites[row * colNumber + col];
				patches[row, col].GetComponent<SpriteRenderer>().sortingOrder = 2;
				float x = Random.Range(patchXRange.x, patchXRange.y);
				float y = Random.Range(patchYRange.x, patchYRange.y);
				patches[row, col].GetComponent<Transform>().position = new Vector3(x, y, 0);
			}
        }
    }
}
