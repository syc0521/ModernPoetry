﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Puzzle
{
	public class MouseDrag : MonoBehaviour
	{
		public CreatePatch createPatchObj;
		private Vector3 mousePosInWorld;
		public Camera worldCamera;
		private Patch selectingPatch;
		private Transform selectedPatch;
		private Vector3 lastMousePosition = Vector3.zero;
		public float threhold = 0.35f;

		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				selectedPatch = SelectPatch();
				if (selectedPatch != null)
				{
					Debug.Log(selectedPatch.ToString());
				}
			}
			if (Input.GetMouseButton(0))
			{
				if (!selectingPatch.IsComplete)
				{
					DragPatch();
				}
			}
			if (Input.GetMouseButtonUp(0))
			{
                if (!MatchPatch())
                {
					selectingPatch.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
				}
				lastMousePosition = Vector3.zero;
				if (selectedPatch != null)
				{
					selectingPatch.GetComponent<SpriteRenderer>().sortingOrder = 2;
				}
			}
		}

		private Transform SelectPatch()
		{
			mousePosInWorld = worldCamera.ScreenToWorldPoint(Input.mousePosition);
			for (int i = 0; i < createPatchObj.ColNumber; i++)
			{
				for (int j = 0; j < createPatchObj.RowNumber; j++)
				{
					selectingPatch = createPatchObj.GetPatchObj()[i, j].GetComponent<Patch>();
					if (Mathf.Abs(mousePosInWorld.x - selectingPatch.transform.position.x) < selectingPatch.GetWidth() / 2 &&
						Mathf.Abs(mousePosInWorld.y - selectingPatch.transform.position.y) < selectingPatch.GetWidth() / 2)
					{
						return selectingPatch.gameObject.transform;
					}
				}
			}
			return null;
		}
		private void DragPatch()
		{
			if (selectedPatch == null)
			{
				return;
			}
			if (lastMousePosition != Vector3.zero)
			{
				selectingPatch.GetComponent<SpriteRenderer>().sortingOrder = 8;
				selectingPatch.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
				Vector3 offset = worldCamera.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
				selectedPatch.position += offset;
			}
			lastMousePosition = worldCamera.ScreenToWorldPoint(Input.mousePosition);
		}
		private bool MatchPatch()
		{
			if (selectedPatch == null)
			{
				return false;
			}
			Patch currentPatch = selectedPatch.GetComponent<Patch>();
			if (Mathf.Abs(selectedPatch.transform.position.x - currentPatch.GetTargetPosition().x) < threhold &&
				Mathf.Abs(selectedPatch.transform.position.y - currentPatch.GetTargetPosition().y) < threhold)
			{
				selectedPatch.transform.position = currentPatch.GetTargetPosition();
				selectingPatch.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
				currentPatch.IsComplete = true;
				createPatchObj.FinishedPuzzle++;
				selectingPatch.GetComponent<AudioSource>().Play();
				return true;
			}
			return false;
		}
	}

}
