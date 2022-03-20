using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject boss;
    public GameObject canvas;
    public CameraMove cameraMove;
    private float h = 0;
    // Start is called before the first frame update
    void Start()
    {
        boss.SetActive(false);
        canvas.SetActive(false);
        StartCoroutine("Event");
        InvokeRepeating("ColorChange", 1.5f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public IEnumerator Event()
    {
        yield return new WaitForSeconds(1f);
        boss.SetActive(true);
        yield return new WaitForSeconds(2f);
        canvas.SetActive(true);


    }
    public void ColorChange()
    {
        h += 0.1f;
        if(h>=1.0f)
        {
            h = 0;
        }
        Color color = Color.HSVToRGB(h, 1f, 1f);
        boss.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
    }
}
