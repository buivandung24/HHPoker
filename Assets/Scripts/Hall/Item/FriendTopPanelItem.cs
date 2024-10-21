using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FriendTopPanelItem : MonoBehaviour {

    private CircleImage icon;
    private Text Name;
    private Button self;
    private bool isFriend=false;

    private string id;
    private Hashtable data;

    private void Awake()
    {
        icon = transform.Find("Icon").GetComponent<CircleImage>();
        Name = transform.Find("Name").GetComponent<Text>();
        self = GetComponent<Button>();
        self.onClick.AddListener(() =>
        {
            HallManager.GetSingleton().friendDetailTopPanel.id = id;
            HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().friendDetailTopPanel);
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
            isFriend=data["isFriend"].ToString() == "1" ? true : false;
        }
    }

    private void GetNetSprite(Sprite sprite)
    {
        icon.sprite = sprite;
    }



    void Start()
    {

    }

    void Update()
    {

    }
}
