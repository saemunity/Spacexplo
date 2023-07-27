using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    public RawImage image;
    public float x, y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        image.uvRect = new Rect(image.uvRect.position + new Vector2(x, y) * Time.deltaTime, image.uvRect.size);        
    }
}
