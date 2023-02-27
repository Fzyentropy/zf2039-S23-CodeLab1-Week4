using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Collider : MonoBehaviour
{

    public int roomNum = 0;
    private TMP_Text Title;
    private RawImage titleBox;
    public AudioSource SFX;
    
    void Start()
    {
        if (SFX == null)
        {
            SFX = GameObject.Find("titleSFX").GetComponent<AudioSource>();
        }

        if (Title == null)
        {
            Title = GameObject.Find("Title").GetComponent<TMP_Text>();
        }

        if (titleBox == null)
        {
            titleBox = GameObject.Find("titleBox").GetComponent<RawImage>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowLocation());
        }

    }

    
    IEnumerator ShowLocation()
    {
        GameManager.roomNumber = roomNum;  

        yield return new WaitForSeconds(.1f);

        StartCoroutine(PrintTitle(GameManager.GetCurrentTxtName()));

    }
    
    
    IEnumerator PrintTitle(string StringToPrint)     
    {
        titleBox.color = new Color(0, 0, 0, 0.8f);
        Title.color = Color.green;
        

        int CurrentPosition = 0;     //打印的string数组当前字符位置
        int AudioIndex = 2;       //控制音频播放的频率
        float printSpeed = 0.05f;
        float fadeScale = .1f;
        float fadeSpeed = .1f;

        while (true) 
        {

            Title.text = StringToPrint.Substring(0,CurrentPosition);      //让text组件的text等于打印文本的substring截取
            if(AudioIndex>=2){SFX.Play(); AudioIndex = 0;}      //若音频计数达到指定值，则播放音频，并重置计数
                
            CurrentPosition++;     //指示位置前移
            AudioIndex++;    //音频播放计数+1
            yield return new WaitForSeconds(printSpeed);     //设置多长时间执行下一个循环，即打印速度

            if (CurrentPosition > StringToPrint.Length)
            {
                break;
            }
        }   

        Debug.Log("done");

        yield return new WaitForSeconds(1f);

        while (true)
        {
            if (Title.color.a <= 0 && titleBox.color.a <= 0) {break;}
            
            Title.color = new Color(Title.color.r, Title.color.g, Title.color.b, Title.color.a - fadeScale);
            titleBox.color = new Color(titleBox.color.r, titleBox.color.g, titleBox.color.b, titleBox.color.a - fadeScale);
            yield return new WaitForSeconds(fadeSpeed);
        }
        Title.GetComponent<TMP_Text>().text = "";
        titleBox.GetComponent<RawImage>().color = new Color(0, 0, 0, 0);
        
    }
    
}
