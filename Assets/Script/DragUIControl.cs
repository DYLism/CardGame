using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// ドラッグ操作
/// </summary>

public class DragUIControl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Color SelectedColor;
    private RectTransform rectTransform;
    private Vector3 Originalpos;
    private Image image;
    public bool isDrag;
    public Transform PlayerCard;
    private GameObject highlightObj;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        PlayerCard= GameObject.Find("PlayerCard").transform;
        isDrag = false;
    }

    void Update()
    {
        if (isDrag)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                highlightObj = hit.collider.gameObject;
                if (highlightObj.CompareTag("PlayerCard"))
                {
                    foreach (Transform child in highlightObj.transform.parent)
                    {
                        child.GetComponent<MeshRenderer>().material.SetColor("_LineColor", Color.black);
                    }

                    highlightObj.GetComponent<MeshRenderer>().material.SetColor("_LineColor", Color.yellow);
                }

            }
        }
    
    }

    // ドラックが開始したとき呼ばれる.
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
        Originalpos = rectTransform.position;
        image.color = SelectedColor;
        
    }

    // ドラック中に呼ばれる.
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos;
        //座標をローカル座標に変換
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            rectTransform,
            eventData.position, 
            eventData.enterEventCamera,
            out pos
            );
        rectTransform.position = pos;
    }

    // ドラックが終了したとき呼ばれる.
    public void OnEndDrag(PointerEventData eventData)
    {
        image.color =Color.white;
        rectTransform.position = Originalpos;
        isDrag=false;
        foreach (Transform child in PlayerCard)
        {
            child.GetComponent<MeshRenderer>().material.SetColor("_LineColor", Color.black);
        }
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    Debug.Log("drop");
    //    col.gameObject.GetComponent<Image>().color = dropColor;
    //    if (col.gameObject.CompareTag("hand"))
    //    {
            
    //    }
        
    //}

}
