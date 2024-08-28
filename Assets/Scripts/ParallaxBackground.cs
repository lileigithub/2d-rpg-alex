using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    [SerializeField] private float paralaxEffect;
    private GameObject cam;
    private float xPosition;
    private float length;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        xPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToMove = cam.transform.position.x * paralaxEffect;
        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);

        //相机向右移动时 相机位置已比图片位置大了一个length, 初始位置向右移动一个length
        if (cam.transform.position.x - transform.position.x > length)
        {
            xPosition = xPosition + length;
        }
        else if (transform.position.x - cam.transform.position.x > length)
        {
            xPosition = xPosition - length;
        }
    }

}
