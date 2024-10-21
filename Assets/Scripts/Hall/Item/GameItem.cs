﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameItem : MonoBehaviour {

    private CircleImage icon;
    private Text deskName;
    private Text playerName;
    private Text chouma;
    private Text persion;
    private Text time;
    private Text isStarting;

    void Awake()
    {
        icon = transform.Find("RawImage").GetComponent<CircleImage>();
        deskName = transform.Find("DeskName").GetComponent<Text>();
        playerName = transform.Find("Name").GetComponent<Text>();
        chouma = transform.Find("Chouma/value").GetComponent<Text>();
        persion = transform.Find("Persion/value").GetComponent<Text>();
        time = transform.Find("Time/value").GetComponent<Text>();
        isStarting = transform.Find("isStarting").GetComponent<Text>();
    }

	void Start ()
    {
	
	}

	void Update ()
    {
	
	}

    public void SetData(Hashtable data)
    {
        GameTools.GetSingleton().GetTextureFromNet(data["url"].ToString(), GetNetSprite);
        //数据获取
    }
    private void GetNetSprite(Sprite sprite)
    {
        icon.sprite = sprite;
    }
}
