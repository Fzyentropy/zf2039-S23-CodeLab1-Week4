using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonumentInteraction : MonoBehaviour
{

    private bool allowEInput = false;
    private TMP_Text Text;
    private GameObject textBox;
    [SerializeField]
    private AudioSource SFX;

    private bool isPrinting = false;
    private bool Clickable = false;
    private bool isClicking = false;

    void Start()
    {
        if (Text == null)
        {
            Text = GameObject.Find("Text").GetComponent<TMP_Text>();
        }

        if (textBox == null)
        {
            textBox = GameObject.Find("textBox");
        }
    }

    
    void Update()
    {
        if (allowEInput && !GameManager.isReading && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.isReading = true;
            StartCoroutine(EFunction());
        }
        
        if(Clickable)       // 判断当前是否可以点击
        {
            if (Input.GetKeyDown(KeyCode.E))    
            {
                if(!isPrinting)
                {
                    isClicking = true;
                }

                if(isPrinting)
                {
                    isPrinting = false;
                }
                    
            }
                
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            allowEInput = true;
            Debug.Log("enable E");
            // TODO pop up ? or E
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            allowEInput = false;
            Debug.Log("disable E");
            // TODO ? or E disappear
        }
    }



    IEnumerator EFunction()
    {

        GameManager.isReading = true;
        string txtText = File.ReadAllText(GameManager.currentDir + "/" + GameManager.GetCurrentTxtName() + ".txt");
        string[] splitText = txtText.Split("\n");
        
        yield return new WaitForSeconds(.1f);
        
        // TODO ? or E disappear
        
        StartCoroutine(PrintDialogue(splitText, 0));
        

    }
    
    
    
    
    IEnumerator PrintDialogue(string[] StringToPrint, int StringIndex)     
    {
        Clickable = true;
        isPrinting = true;    // 正在打印，防止此时鼠标点击直接将isClicking变true
        isClicking = false;
        textBox.GetComponent<RawImage>().color = new Color(0, 0, 0, 0.7f);
        WASDControl.WASDRb.velocity = new Vector2(0,0);

        int CurrentPosition = 0;     //打印的string数组当前字符位置
        int AudioIndex = 2;       //控制音频播放的频率
        float printSpeed = 0.05f;

        while (true) 
        {

            if (!isPrinting)     // 当鼠标点击1次，isPrinting将变为false，将文本全部打印
            {
                Text.GetComponent<TMP_Text>().text = StringToPrint[StringIndex];      // 直接全部显示文字
                CurrentPosition += StringToPrint[StringIndex].Length;                   // 直接将CurrentPosition设置为长度+1，以满足break的条件
                isClicking = false;                                                   // 重要！此时将isClicking设为false，防止中途点击鼠标将isClicking设置为true而直接break
            }
                

            if (CurrentPosition > StringToPrint[StringIndex].Length)      //如果当前位置超出文本长度，则break
            {
                isPrinting = false;                                      // 再次设置isPrinting为false，自然播放完后也应该结束Printing
                yield return new WaitUntil(() => isClicking);            // 鼠标点击后break
                isClicking = false;                                      // break前，将isClicking设置为false，call back
                Clickable = false;                                      // break前，禁止鼠标点击
                break;
            }

            Text.GetComponent<TMP_Text>().text = StringToPrint[StringIndex].Substring(0,CurrentPosition);      //让text组件的text等于打印文本的substring截取
            if(AudioIndex>=2){SFX.Play(); AudioIndex = 0;}      //若音频计数达到指定值，则播放音频，并重置计数
                
            CurrentPosition++;     //指示位置前移
            AudioIndex++;    //音频播放计数+1
            yield return new WaitForSeconds(printSpeed);     //设置多长时间执行下一个循环，即打印速度

        }   

        Debug.Log("done");
        Text.GetComponent<TMP_Text>().text = "";
        textBox.GetComponent<RawImage>().color = new Color(0, 0, 0, 0);
        StringIndex++;

        if (StringIndex < StringToPrint.Length)
        {
            StartCoroutine(PrintDialogue(StringToPrint, StringIndex));
            yield break;
        }
        
        if (StringIndex == StringToPrint.Length)
        { 
            GameManager.isReading = false; 
            yield break; 
        }
    }
    
    
    
}
