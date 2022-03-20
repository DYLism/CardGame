using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 手札マネジメント////用于排列手牌位置
/// </summary>
public class HandCardManager : MonoBehaviour
{
    public float distance=20f;
    public float moveSpeed = 200f;
   
    public List<Transform> HandCardList = new List<Transform>();//手札リスト
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        for (int i = 0; i < HandCardList.Count; i++)
        {
            if (!HandCardList[i].GetComponent<DragUIControl>().isDrag)
            {
                Vector3 targetPos = new Vector3(-(HandCardList.Count - 1) / 1.5f * distance + distance * i,
                    0,HandCardList[0].transform.localPosition.z);

                HandCardList[i].transform.localPosition = Vector3.MoveTowards(
                    HandCardList[i].transform.localPosition,
                    targetPos,
                    moveSpeed * Time.deltaTime);

            }
            
        }
    }
}
