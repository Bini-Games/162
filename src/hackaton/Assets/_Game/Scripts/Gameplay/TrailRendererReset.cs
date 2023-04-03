using UnityEngine;

namespace Gameplay
{
    public class TrailRendererReset : MonoBehaviour
    {
        public float Delta;
		
        private Vector2 LastPosition;
		
        private void Update()
        {
            if (Vector2.Distance(LastPosition, transform.position) > Delta) 
                GetComponent<TrailRenderer>().Clear();
            
            LastPosition = transform.position;
        }
    }
}