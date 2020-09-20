using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Games.Puzzle
{
	public class CreatePatch : MonoBehaviour
	{
		public Sprite[] spritePatches;
        private GameObject[,] patches;
		public AudioClip puzzleEffect;
		public Sprite[] items;
		public SpriteRenderer picture;
		public Vector2 patchXRange, patchYRange;
		private bool isWin = false;
		public int index;
		public int ColNumber;
		public int RowNumber;
		public static CreatePatch _instance;
		public int FinishedPuzzle { get; set; } = 0;

        void Start()
		{
			_instance = this;
			patches = new GameObject[ColNumber, RowNumber];
			CreatePatchObj();
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				SceneManager.LoadScene("Main");
			}
			if (FinishedPuzzle == RowNumber * ColNumber)
            {
				isWin = true;
            }
		}
		public void DeletePatch()
        {
			for (int row = 0; row < RowNumber; row++)
			{
				for (int col = 0; col < ColNumber; col++)
				{
					Destroy(patches[row, col]);
				}
			}
		}
		public void CreatePatchObj()
		{
			picture.sprite = items[index];
			spritePatches = Resources.LoadAll<Sprite>("Puzzle_" + index);
			for (int row = 0; row < RowNumber; row++)
			{
				for (int col = 0; col < ColNumber; col++)
				{
					patches[row, col] = new GameObject("patch" + row + col);
					var patchAudio = patches[row, col].AddComponent<AudioSource>();
					patchAudio.clip = puzzleEffect;
					patchAudio.playOnAwake = false;
					patches[row, col].AddComponent<SpriteRenderer>().sprite = spritePatches[row * ColNumber + col];
					patches[row, col].GetComponent<SpriteRenderer>().sortingOrder = 7;
					patches[row, col].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
					float x = Random.Range(patchXRange.x, patchXRange.y);
					float y = Random.Range(patchYRange.x, patchYRange.y);
					patches[row, col].transform.position = new Vector3(x, y, 0);
					patches[row, col].transform.localScale = new Vector3(0.875f, 0.841f);
					Vector2 size = patches[row, col].GetComponent<SpriteRenderer>().sprite.bounds.size;
					Vector2 patchSize = new Vector2(size.x * 0.875f, size.y * 0.841f);
					Vector3 initPosition = patches[row, col].GetComponent<Transform>().position;
					Vector3 targetPosition = new Vector3((col + 0.5f) * patchSize.x, 
														 (RowNumber - row - 0.5f) * patchSize.y, 0);
					patches[row, col].AddComponent<Patch>().InitPatch(patchSize.x, patchSize.y, targetPosition, initPosition);
					//patches[row, col].transform.position = patches[row, col].GetComponent<Patch>().GetTargetPosition();
				}
			}
		}
		public GameObject[,] GetPatchObj()
        {
			return patches;
        }

    }

}
