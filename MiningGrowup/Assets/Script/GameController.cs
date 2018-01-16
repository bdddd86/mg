using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eGameState
{
	eWorking_Room,
	wBuilding_Select,
}

// 게임플레이 데이터 저장용.
[Serializable]
public class PCData
{
	public int idx;		// PC 위치정보로 쓸 인덱스.
	public int level;	// PC 업그레이드 레벨.
	public int type;	// PC 타입. (0, 1, 2)
	public int state;	// PC 현재상태. (0, 1, 2, 3)
	public float gauge;	// 코인 보관량. (0-1)
}

[Serializable]
public class WorkingRoomData
{
	public int idx;		// 작업장 번호.
	public int level;	// 작업장 레벨. (0, 1, 2)
	public List<PCData> listPc;	// 작업장 PC정보.
}

[Serializable]
public class GamePlayData
{
	public string bitCoin;		// 보유한 비트코인 정보.
	public string money;		// 보유한 현금 정보.
	public string treasure;		// 보유한 보물정보.
	public int miningLevel;		// 최종 채굴난이도.
	public List<WorkingRoomData> listRoom;	// 내가 가진 작업장 정보.
	// + NPC 정보도 저장해야함.
}

public class GameController : MonoBehaviour {

	[Header("[UI]")]
	public WorkingRoom room_lv_1;
	public WorkingRoom room_lv_2;
	public WorkingRoom room_lv_3;

	[Header("[Cursor]")]
	public Text plusBitCoin;
	public Animator plusBitCoinAnim;

	[Header("[Character]")]
	public Animator mainCharacter;

	public double bitCoin = 0;
	public double bitCoinPerTouch = 0.001;

	void Start()
	{
		SaveWorkingRoomData ();
	}

	private void SaveWorkingRoomData()
	{
		// 가라데이터
		// 나중에 PlayerPrefs로 저장된 Json 문자열로 대신한다.
		GamePlayData gameData = new GamePlayData();
		gameData.bitCoin = "100";
		gameData.money = "1000000";
		gameData.listRoom = new List<WorkingRoomData> ();

		WorkingRoomData roomData = new WorkingRoomData ();
		roomData.idx = 0;
		roomData.level = 0;
		roomData.listPc = new List<PCData> ();

		PCData pcData = new PCData ();
		pcData.idx = 0;
		pcData.level = 2;
		pcData.type = 0;
		pcData.gauge = 0.5f;

		roomData.listPc.Add (pcData);

		gameData.listRoom.Add (roomData);

		string saveData = JsonUtility.ToJson (gameData, true);
		Debug.Log(saveData);
		PlayerPrefs.SetString ("playerinfo", saveData);
	}

	private void LoadWorkingRoomData()
	{
		string loadData = PlayerPrefs.GetString ("playerinfo", string.Empty);
		if (string.IsNullOrEmpty (loadData)) {
			// 첫 판.
		} 
		else {
			GamePlayData gameData = JsonUtility.FromJson<GamePlayData> (loadData);

		}
	}

	int frameCnt = 0;
	float deltaTime = 0;
	// 터치 처리.
	void Update()
	{
		if (Time.frameCount != frameCnt) {
			frameCnt = Time.frameCount;

			#if UNITY_EDITOR || UNITY_STANDALONE_WIN
			if (Input.GetMouseButtonDown(0)){
			#else
			if (Input.touchCount > 0) {
			#endif
				bitCoin += bitCoinPerTouch;
				plusBitCoin.text = string.Format("+{0}",bitCoinPerTouch);
				plusBitCoin.transform.position = Input.mousePosition;
				plusBitCoinAnim.SetTrigger("Click");
				mainCharacter.SetTrigger ("mining");
			}
		}
	}
}
