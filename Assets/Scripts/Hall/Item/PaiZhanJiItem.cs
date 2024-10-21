using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PaiZhanJiItem : MonoBehaviour {

    private CircleImage icon;
    private Text playerName;
    private Text playerBuy;
    private Text playerShoushu;
    private Text playerScore;
    private Text playerShengyu;

    private Hashtable data;

    private void Awake()
    {
        icon = transform.Find("Icon").GetComponent<CircleImage>();
        playerName = transform.Find("Name").GetComponent<Text>();
        playerBuy = transform.Find("Buy/value").GetComponent<Text>();
        playerShoushu = transform.Find("ShouShu/value").GetComponent<Text>();
        playerScore = transform.Find("Score").GetComponent<Text>();
        playerShengyu = transform.Find("shengyu/value").GetComponent<Text>();

    }

    void Start ()
    {
	
	}

	void Update ()
    {
	
	}

    public void SetData(Hashtable data)
    {
        this.data = data;
        GameTools.GetSingleton().GetTextureFromNet(data["playerUrl"].ToString(), GetNetSprite);
        playerName.text = data["playerName"].ToString();
        playerBuy.text = "买入:"+data["playerBuy"].ToString();
        playerShoushu.text = "手数:"+data["playerShouShu"].ToString();
        playerScore.text = data["playerScore"].ToString();
        playerShengyu.text = "剩余筹码:"+data["playerSheng"].ToString();
        playerScore.color = StaticFunction.Getsingleton().GetColor(int.Parse(data["playerScore"].ToString()));
    }
    private void GetNetSprite(Sprite sprite)
    {
        icon.sprite = sprite;
    }
}
