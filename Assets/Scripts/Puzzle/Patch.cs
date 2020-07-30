using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Puzzle
{
	public class Patch : MonoBehaviour
	{
		private Vector3 targetPosition;
		private Vector3 initPosition;
		private float PatchWidth;
		private float PatchHeight;

		public void InitPatch(float PatchWidth,float PatchHeight,Vector3 targetPosition, Vector3 initPosition)
		{
			this.PatchWidth = PatchWidth;
			this.PatchHeight = PatchHeight;
			this.targetPosition = targetPosition;
			this.initPosition = initPosition;
		}
		public Vector3 GetTargetPosition()
        {
			return targetPosition;
        }
		public float GetWidth()
        {
			return PatchWidth;
        }
		public float GetHeight()
        {
			return PatchHeight;
        }
	}

}
