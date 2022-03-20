
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



/// <summary>
/// 选择卡牌 放入手牌list
/// </summary>

public class CardSelecter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image explanationImage;
    public Sprite defaultSprite;
    //public Card card;
    public GameObject Card2DPrefab;
    public Transform hand;

   
    void Start()
    {
        
    }

    public  void OnPointerClick(PointerEventData data)
    {
        if(GetComponent<Image>().sprite != defaultSprite)
        {
            Sprite sprite = GetComponent<Image>().sprite;//選択したカードを保存
            explanationImage.gameObject.SetActive(false);
            GetComponent<Image>().sprite = defaultSprite;
            GameObject card = Instantiate(Card2DPrefab);
            card.GetComponent<Image>().sprite = sprite;
            card.transform.SetParent(hand, false);//handの子オブジエンドにする
            hand.GetComponent<HandCardManager>().HandCardList.Add(card.transform);//手札リストに入れる
        }
        
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (!explanationImage.gameObject.activeSelf && GetComponent<Image>().sprite != defaultSprite)
        {
            explanationImage.gameObject.SetActive(true);
            explanationImage.sprite = GetComponent<Image>().sprite;
        }
       
    }

    public  void OnPointerExit(PointerEventData data)
    {
        explanationImage.gameObject.SetActive(false);
    }

}
