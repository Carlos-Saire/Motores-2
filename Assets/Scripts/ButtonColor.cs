using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ButtonColor : MonoBehaviour
{
    private Button myButton;
    private Image myImage;
    [SerializeField] private GameObject Player;
    [SerializeField] private TMP_Text myText;
    [SerializeField] private Color Color;
    [SerializeField] private string myName;
    private void Awake()
    {
        myButton = GetComponent<Button>();
        myImage = GetComponent<Image>();
        myButton.onClick.AddListener(() => Onclick());
    }
    private void Start()
    {
        myImage.color = Color;
        myText.text =myName;
    }
    private void Onclick()
    {
        Player.GetComponent<SpriteRenderer>().color = Color;
    }
}
