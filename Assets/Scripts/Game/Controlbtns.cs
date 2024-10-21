using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controlbtns : MonoBehaviour {

    private Button systembtn;//系统设置按钮
    private Button homeMsgBtn;//首页按钮
    private Button record;//记录按钮
    private Button recordZhanji;//记录战绩按钮
    private Button actualZhanji;

	public Button share;
	public Button msg;

	public Button storeBtn;
	public Button guessBtn;
	public Button reviewBtn;


    private void Awake()
    {
        systembtn = transform.Find("SystemBtn").GetComponent<Button>();
        homeMsgBtn = transform.Find("homeMsgBtn").GetComponent<Button>();
        record = transform.Find("record").GetComponent<Button>();
        recordZhanji = transform.Find("recordZhanji").GetComponent<Button>();
        actualZhanji = transform.Find("actualZhanji").GetComponent<Button>();

		storeBtn = transform.Find("store").GetComponent<Button>();
		guessBtn = transform.Find("guessCard").GetComponent<Button>();
		reviewBtn = transform.Find("review").GetComponent<Button>();
      
		share = transform.Find("shareBtn").GetComponent<Button>();
		msg = transform.Find("msgBtn").GetComponent<Button>();

		storeBtn.onClick.AddListener(()=> {
			GameUIManager.GetSingleton().shopInGame.gameObject.SetActive(true);
		});

		reviewBtn.onClick.AddListener(() => {
			GameUIManager.GetSingleton().gameReviewPanel.gameObject.SetActive(true);
			NetMngr.GetSingleton().Send(InterfaceGame.roundReview, new object[] { 1, GameUIManager.GetSingleton().gameReviewPanel.isMine });
		});

		guessBtn.onClick.AddListener(() => {
			GameUIManager.GetSingleton().guessRecordPanel.gameObject.SetActive(true);
			NetMngr.GetSingleton().Send(InterfaceGame.getGuessRecord, new object[] { 1, 10 });
		});


		share.onClick.AddListener(()=> 
		{
			GameUIManager.GetSingleton().gameSharePopup.ShowView();
		});

		msg.onClick.AddListener(()=> 
		{
			GameUIManager.GetSingleton().planeManager.AddTopPlane(GameUIManager.GetSingleton().paiMsgTopPanel);
		});


        systembtn.onClick.AddListener(()=> 
        {
            GameUIManager.GetSingleton().ptopleftpanel.gameObject.SetActive(true);
        });
        homeMsgBtn.onClick.AddListener(() =>
        {

        });
        record.onClick.AddListener(() =>
        {

        });
        recordZhanji.onClick.AddListener(() =>
        {

        });
        actualZhanji.onClick.AddListener(() =>
        {

        });
        
    }


	void Start ()
    {
	    
	}
	

	void Update ()
    {
	
	}
}
