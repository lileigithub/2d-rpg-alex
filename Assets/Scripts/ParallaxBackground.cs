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

        //��������ƶ�ʱ ���λ���ѱ�ͼƬλ�ô���һ��length, ��ʼλ�������ƶ�һ��length
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
