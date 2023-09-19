using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour
{
    public GameObject button;
    public GameObject buttonHover;

    // Start is called before the first frame update
    void Start()
    {
        buttonHover.SetActive(false);
    }

    // Update is called once per frame
    void Update() { }

    private void OnMouseOver()
    {
        button.SetActive(false);
        buttonHover.SetActive(true);
    }

    private void OnMouseExit()
    {
        button.SetActive(true);
        buttonHover.SetActive(false);
    }
}
