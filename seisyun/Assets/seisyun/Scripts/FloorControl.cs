using UnityEngine;
using System.Collections;

public class FloorControl : MonoBehaviour {
    public static float WIDTH = 10.0f;
    public static int BACK_NUM = 5;
    public GameObject Object;

    private Object ballObject;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        float total_width = FloorControl.WIDTH * FloorControl.BACK_NUM;

        Vector3 floor_position = this.transform.position;

        Vector3 camera_position = Camera.main.transform.position;

        if (floor_position.x + total_width / 2.0f < camera_position.x)
        {
            floor_position.x += total_width;
            this.transform.position = floor_position;

            Destroy(ballObject);

            if (Random.Range(0f, 2.0f) >= 0.5f)
            {
                ballObject = Instantiate(Object, this.transform.position + new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(0.5f, 4.0f)), Quaternion.identity);
                ballObject.name = "ballobject";
            }
        }
	}
}
