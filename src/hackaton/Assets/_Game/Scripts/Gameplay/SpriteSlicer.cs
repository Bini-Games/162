using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
	public class SpriteSlicer : MonoBehaviour 
	{
		private List<SpriteSlicer2DSliceInfo> slicedSpriteInfo = new();
		private TrailRenderer trailRenderer;
		
		public float MouseRecordInterval = 0.05f;
		public int MaxMousePositions = 5;
   
		private List<MousePosition> mousePositions = new();
		private float mouseRecordTimer = 0.0f;

		private Camera mainCamera;

		private void Awake()
		{
			mainCamera = Camera.main;
			trailRenderer = GetComponentInChildren<TrailRenderer>();
		}

		private async UniTask DestroyWithTimeout(GameObject item)
		{
			await UniTask.Delay(TimeSpan.FromSeconds(2));
			Destroy(item);
		}

		private void Update() 
		{
			if (Input.GetMouseButton(0))
			{
				var mousePositionAdded = false;
				mouseRecordTimer -= Time.deltaTime;

				// Record the world position of the mouse every x seconds
				if (mouseRecordTimer <= 0.0f)
				{
					var newMousePosition = new MousePosition();
					newMousePosition.WorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
					newMousePosition.Time = Time.time;

					mousePositions.Add(newMousePosition);
					mouseRecordTimer = MouseRecordInterval;
					mousePositionAdded = true;

					if (mousePositions.Count > MaxMousePositions)
					{
						mousePositions.RemoveAt(0);
					}
				}

				// Forget any positions that are too old to care about
				if (mousePositions.Count > 0 && (Time.time - mousePositions[0].Time) > MouseRecordInterval * MaxMousePositions)
				{
					mousePositions.RemoveAt(0);
				}

				// Go through all our recorded positions and slice any sprites that intersect them
				if (mousePositionAdded)
				{
					for (var loop = 0; loop < mousePositions.Count - 1; loop++)
					{
						SpriteSlicer2D.SliceAllSprites(mousePositions[loop].WorldPosition, mousePositions[mousePositions.Count - 1].WorldPosition, true, ref slicedSpriteInfo);

						if (slicedSpriteInfo.Count <= 0) 
							continue;
						
						// Add some force in the direction of the swipe so that stuff topples over rather than just being
						// sliced but remaining stationary
						foreach (var sliceInfo in slicedSpriteInfo)
						{
							var direction = Vector3.right;
							foreach (var sliceObject in sliceInfo.ChildObjects)
							{
								Vector2 sliceDirection = mousePositions[^1].WorldPosition - mousePositions[loop].WorldPosition;
								sliceDirection.Normalize();
								sliceObject.GetComponent<Rigidbody2D>().AddForce(direction * 1000.0f);
								direction *= -1;
								DestroyWithTimeout(sliceObject).Forget();
							}
						}

						mousePositions.Clear();
						break;
					}
				}

				var trailPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
				trailPosition.z = -9.0f;
				trailRenderer.transform.position = trailPosition;
			}
			else
				mousePositions.Clear();

			// Sliced sprites sharing the same layer as standard Unity sprites could increase the draw call count as
			// the engine will have to keep swapping between rendering SlicedSprites and Unity Sprites.To avoid this, 
			// move the newly sliced sprites either forward or back along the z-axis after they are created
			for(int spriteIndex = 0; spriteIndex < slicedSpriteInfo.Count; spriteIndex++)
			{
				for(int childSprite = 0; childSprite < slicedSpriteInfo[spriteIndex].ChildObjects.Count; childSprite++)
				{
					Vector3 spritePosition = slicedSpriteInfo[spriteIndex].ChildObjects[childSprite].transform.position;
					spritePosition.z = -90f;
					slicedSpriteInfo[spriteIndex].ChildObjects[childSprite].transform.position = spritePosition;
				}
			}

			slicedSpriteInfo.Clear();
		}
	}
}
