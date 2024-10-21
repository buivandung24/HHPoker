﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NoticeItem : MonoBehaviour {

    private Button self;
    private Text title;
    private Text Name;
    private Text time;

	private CircleImage icon;

    public string id;
    public string type;
    public string type2;

    private void Awake()
    {
        self = GetComponent<Button>();
        title = transform.Find("Title").GetComponent<Text>();
        Name = transform.Find("Name").GetComponent<Text>();
        time = transform.Find("Time").GetComponent<Text>();

		icon = transform.Find("Icon").GetComponent<CircleImage>();

        self.onClick.AddListener(() =>
        {
            if (type2=="2")
            {
                HallManager.GetSingleton().noticeContentTopPanel.id = id;
                HallManager.GetSingleton().noticeContentTopPanel.type = type;
                HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().noticeContentTopPanel);
            }
            else if(type2 == "1")
            {
                HallManager.GetSingleton().noticeListContentTopPanel.id = id;
                HallManager.GetSingleton().noticeListContentTopPanel.type = type;
                HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().noticeListContentTopPanel);
            }
        });
    }

	void Start ()
    {
	
	}

	void Update ()
    {
	
	}
	void getSprite(Sprite sp)
	{
		icon.sprite = sp;
	}

    public void SetData(Hashtable data)
    {
        if (type2=="1")
        {
			Name.text = data["title"].ToString();
			title.text = type == "1" ? "系统" : data["name"].ToString() + "俱乐部";
            time.text = data["time"].ToString();

			if (data.ContainsKey("iconUrl") && (data ["iconUrl"]).ToString() != "") {
				GameTools.GetSingleton ().GetTextureFromNet (data ["iconUrl"].ToString (), getSprite);
			}
        }
        else if(type2=="2")
        {
            title.text = data["title"].ToString();
            Name.text = data["time"].ToString();
            time.text = "";

			if (data.ContainsKey ("iconUrl") && (data ["iconUrl"]) != "") {
				GameTools.GetSingleton ().GetTextureFromNet (data ["iconUrl"].ToString (), getSprite);
			}

			if(!data.ContainsKey ("iconUrl") )
			{
				icon.sprite = Resources.Load<Sprite> ("img/系统消息");
			}
		
        }
    }
}
