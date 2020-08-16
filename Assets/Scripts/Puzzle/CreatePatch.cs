using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Puzzle
{
	public class CreatePatch : MonoBehaviour
	{
		public Sprite[] spritePatches;
        private GameObject[,] patches;
		public Sprite[] items;
		public SpriteRenderer picture;
		public Vector2 patchXRange, patchYRange;
		private bool isWin = false;
		public int index;

		public int ColNumber;
		public int RowNumber;
		public int FinishedPuzzle { get; set; } = 0;

        void Start()
		{
			picture.sprite = items[index];
			patches = new GameObject[ColNumber, RowNumber];
			spritePatches = Resources.LoadAll<Sprite>("Puzzle_" + index);
			CreatePatchObj(spritePatches);
		}

		void Update()
		{
            if (FinishedPuzzle == RowNumber * ColNumber)
            {
				isWin = true;
            }
		}

		private void CreatePatchObj(Sprite[] sprites)
		{
			for (int row = 0; row < RowNumber; row++)
			{
				for (int col = 0; col < ColNumber; col++)
				{
					patches[row, col] = new GameObject("patch" + row + col);
					patches[row, col].AddComponent<SpriteRenderer>().sprite = sprites[row * ColNumber + col];
					patches[row, col].GetComponent<SpriteRenderer>().sortingOrder = 7;
					patches[row, col].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
					float x = Random.Range(patchXRange.x, patchXRange.y);
					float y = Random.Range(patchYRange.x, patchYRange.y);
					patches[row, col].transform.position = new Vector3(x, y, 0);
					patches[row, col].transform.localScale = new Vector3(0.717f, 0.717f);
					Vector2 patchSize = patches[row, col].GetComponent<SpriteRenderer>().sprite.bounds.size;
					Vector3 initPosition = patches[row, col].GetComponent<Transform>().position;
					Vector3 targetPosition = new Vector3((col + 0.5f) * patchSize.x, 
														 (RowNumber - row - 0.5f) * patchSize.y, 0);
					patches[row, col].AddComponent<Patch>().InitPatch(patchSize.x, patchSize.y, targetPosition, initPosition);
				}
			}
		}
		public GameObject[,] GetPatchObj()
        {
			return patches;
        }
	}

}
