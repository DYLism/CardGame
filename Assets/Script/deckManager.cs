using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 山札マネジメント
/// </summary>
public class deckManager : MonoBehaviour
{

    //public Button[] renewButton;//山札を更新するボタン     //////之后搞一个统一管理按钮的文档
    public List<Transform> deckList = new List<Transform>();//山札リスト
    public List<Sprite> cardSpriteList = new List<Sprite>();//card配列
    private int r;
    public Button renewButton;

    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform child in transform)
        {
            deckList.Add(child);
        }
        Renew();
        AddListener(renewButton);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void Renew()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);//Randomクラスの初期化
        for (int i = 0; i < deckList.Count; i++)
        {
          
            r = UnityEngine.Random.Range(0, cardSpriteList.Count);
            deckList[i].GetComponent<Image>().sprite = cardSpriteList[r];
        }
      
      
    }

    private void AddListener(Button button)
    {
        button.onClick.AddListener(delegate { Renew(); });
    }

}
