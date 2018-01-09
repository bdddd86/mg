using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ePCState
{
	eNone = 0,	// 구매전
	eMining,	// 채굴중
	eBreak,		// 고장
	eEnoughCoin,// 코인 풀
}

public enum ePCType
{
	eBasic = 0,	// 기본형 
	ePro,		// 프로페셔널
	eSuper,		// 슈퍼컴퓨터
}

public class PC : MonoBehaviour {

	private Animator animator;
	private ePCType eType = ePCType.eBasic;
	private ePCState eState = ePCState.eNone;
	private List<Image> listImg = null;

	public void SetState(PCData pcData)
	{
		eState = (ePCState)pcData.state;

		if (listImg == null) {
			listImg = new List<Image> ();

			listImg.Add (GetComponent<Image> ());

			if (transform.childCount == 0) {
				eType = ePCType.eBasic;
			} 
			else {
				for (int i = 0; i < transform.childCount; i++) {
					listImg.Add (transform.GetChild (i).GetComponent<Image> ());
				}

				if (transform.childCount == 1) {
					eType = ePCType.ePro;
				} 
				else {
					eType = ePCType.eSuper;
				}
			}
		}

		switch (eState) {
		case ePCState.eNone:
			for (int i = 0; i < listImg.Count; i++) {
				listImg [i].color = new Color (0, 0, 0, 0.55f);
			}
			break;
		case ePCState.eMining:
			for (int i = 0; i < listImg.Count; i++) {
				listImg [i].color = Color.white;
			}
			break;
		case ePCState.eEnoughCoin:
			for (int i = 0; i < listImg.Count; i++) {
				listImg [i].color = Color.white;
			}
			break;
		case ePCState.eBreak:
			for (int i = 0; i < listImg.Count; i++) {
				listImg [i].color = Color.white;
			}
			break;
		}
	}
}
