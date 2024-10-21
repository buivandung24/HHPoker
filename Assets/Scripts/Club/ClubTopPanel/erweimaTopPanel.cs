using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class erweimaTopPanel : BasePlane
{
    public Button backBtn;
    public Button shareBtn;

	public CircleImage clubHead;
    public Text clubName;
    public Text clubAddress;
    public Image erweimaImage;


    void Awake()
    {
        backBtn = transform.Find("ToggleGroup/Back/Share").GetComponent<Button>();
        shareBtn = transform.Find("ToggleGroup/ShareBtn").GetComponent<Button>();

		clubHead = transform.Find("ClubHead").GetComponent<CircleImage>();
        clubName = transform.Find("ClubName").GetComponent<Text>();
        clubAddress = transform.Find("ClubAddress").GetComponent<Text>();
        erweimaImage = transform.Find("erweimaImage").GetComponent<Image>();

        backBtn.onClick.AddListener(() => {
            ClubManager.GetSingleton().planeManager.RemoveTopPlane();
        });

        shareBtn.onClick.AddListener(() => {
            ClubManager.GetSingleton().erweimaPopup.ShowView();
        });

        gameObject.SetActive(false);
    }

    public void GetSprtie(Sprite s)
    {
        erweimaImage.sprite = s;
    }


    public void GetErWeiMaCallBack(Hashtable data) {
        GameTools.GetSingleton().GetTextureFromNet(data["ImgUrl"].ToString(), GetSprtie);

    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    public override void OnAddComplete()
    {
        NetMngr.GetSingleton().Send(InterfaceClub.GetErWeiMa, new object[] {});
        clubHead.sprite = ClubManager.GetSingleton().clubInfoTopPanel.clubHead.sprite;
        clubName.text = ClubManager.GetSingleton().clubInfoTopPanel.clubName.text;
       
    }

    public override void OnAddStart()
    {

    }

    public override void OnRemoveComplete()
    {

    }

    public override void OnRemoveStart()
    {

    }
}
