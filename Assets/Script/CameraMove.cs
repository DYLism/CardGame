using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //暂用 后续如果镜头转换比较复杂 改用cinemachine
    public Transform targetTransform;
    public float speed;
    public bool startFlag;
    public float WaitTime;
    // Start is called before the first frame update
    void Start()
    {
        startFlag = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (startFlag)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetTransform.rotation, speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);

        }

    }
    public void Moveflag()
    {
        startFlag = true;
    }
  
}
