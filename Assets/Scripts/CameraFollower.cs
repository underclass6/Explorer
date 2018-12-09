using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {
    // 引用对象
    public Transform target;

    // 字段
    private Vector3 target2D; // 三维空间转换为二维
    private float startDistance = 1e-4f; // 开始跟踪的距离
    private Vector3 currentVelocity = new Vector3(0, 0, 0);
    private float followTime = 0.25f;

	// Use this for initialization
	void Start () {
        target2D = new Vector3(0, 0, transform.position.z);
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Follow(); // 相机进行跟踪
	}

    private void Follow()
    {
        // target2D获得目标对象的横纵坐标
        target2D.x = target.position.x;
        target2D.y = target.position.y;

        // 相机和跟踪对象间的距离
        float disTarAndCamera = Mathf.Pow(target2D.x - transform.position.x, 2) + Mathf.Pow(target2D.y - transform.position.y, 2);

        bool startFollow = disTarAndCamera > startDistance;

        if (startFollow)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target2D, ref currentVelocity, followTime);
        }
    }
}