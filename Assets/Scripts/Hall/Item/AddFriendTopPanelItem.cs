using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddFriendTopPanelItem : MonoBehaviour {

    private CircleImage icon;
    private Text Name;
    private Button add;
    private Button self;
    private bool isFriend = false;
    private string id;
    private Hashtable data;

    private void Awake()
    {
        icon = transform.Find("Icon").GetComponent<CircleImage>();
        Name = transform.Find("Name").GetComponent<Text>();
        add = transform.Find("Add").GetComponent<Button>();
        self = GetComponent<Button>();

        add.onClick.AddListener(() =>
        {
            if (isFriend)
            {
                PopupCommon.GetSingleton().ShowView("该玩家已经是好友,请勿重复添加!");
            }
            else
            {
                HallManager.GetSingleton().addFriendInfoTopPanel.id = id;
                HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().addFriendInfoTopPanel);
            }
            
        });
        self.onClick.AddListener(() =>
        {

        });
    }

    public void SetData(Hashtable data)
    {
        this.data = data;
        GameTools.GetSingleton().GetTextureFromNet(data["playerURL"].ToString(), GetNetSprite);
        id = data["playerID"].ToString();
        Name.text = data["playerName"].ToString();
        if (data.ContainsKey("isFriend"))
        {
            isFriend = data["isFriend"].ToString() == "1" ? true : false;
        }
    }
    private void GetNetSprite(Sprite sprite)
    {
        icon.sprite = sprite;
    }


    void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}
}
