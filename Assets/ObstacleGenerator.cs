using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
	public float radius;
	public int count;
	public GameObject obstacle;
	private void Start(){
		for(int i = 0; i < count; i++){
			transform.position = Vector3.zero;
			transform.Rotate(0, 0, 360 / count);
			transform.Translate(radius, 0, 0);
			Instantiate(obstacle, transform.position, Quaternion.identity);
		}
	}
}
