using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGameMenu : MonoBehaviour {

	public Canvas playGameCanvas;
	public GameObject startGamePanel;
	public GameObject createGamePanel;
	//public GameObject joinGamePanel;
	public GameObject selectLocationPanel;
	public GameObject gameConfirmationPanel;
	public GameObject teamPreviewPanel;
	public GameObject invitePlayersPanel;
	public Button nextButton;
	public Button backButton;
	public Button closeButton;
	public Button invitePlayersButton;

	private GameObject activePanel;

	// Use this for initialization
	void Start () {
		closePlayGameMenu ();
	}

	public void openPlayGameMenu() {
		playGameCanvas.gameObject.SetActive (true);
		startGamePanel.gameObject.SetActive (true);
		nextButton.gameObject.SetActive (false);
		backButton.gameObject.SetActive (false);
		invitePlayersButton.gameObject.SetActive (false);
		closeButton.gameObject.SetActive (true);
		activePanel = startGamePanel;

	}

	public void closePlayGameMenu() {
		playGameCanvas.gameObject.SetActive (false);

		startGamePanel.gameObject.SetActive (false);
		createGamePanel.gameObject.SetActive (false);
		//joinGamePanel.gameObject.SetActive (false);
		selectLocationPanel.gameObject.SetActive (false);
		gameConfirmationPanel.gameObject.SetActive (false);
		teamPreviewPanel.gameObject.SetActive (false);
		invitePlayersPanel.gameObject.SetActive (false);

		nextButton.gameObject.SetActive (false);
		backButton.gameObject.SetActive (false);
		closeButton.gameObject.SetActive (false);
		invitePlayersButton.gameObject.SetActive (false);
	}

	public void createGame() {
		startGamePanel.gameObject.SetActive (false);
		createGamePanel.gameObject.SetActive (true);
		activePanel = createGamePanel;
		nextButton.gameObject.SetActive (true);
		backButton.gameObject.SetActive (true);
	}

	public void joinGame() {

	}

	void openNextScreen(GameObject nextScreen) {
		activePanel.gameObject.SetActive (false);
		nextScreen.gameObject.SetActive (true);
		activePanel = nextScreen;
	}

	void openPrevScreen (GameObject prevScreen) {
		activePanel.gameObject.SetActive (false);
		prevScreen.gameObject.SetActive (true);
		activePanel = prevScreen;
	}

	public void nextButtonOnClickListener() {
		if (activePanel == startGamePanel) {//should never happen; next button will be hidden on this panel
			createGame ();
		} else if (activePanel == createGamePanel) {
			openNextScreen (selectLocationPanel);
		} else if (activePanel == selectLocationPanel) {
			openNextScreen (gameConfirmationPanel);
		} else if (activePanel == gameConfirmationPanel) {
			openNextScreen (teamPreviewPanel);
			invitePlayersButton.gameObject.SetActive (true);
		} else if (activePanel == teamPreviewPanel) {
			closePlayGameMenu ();
		} else if (activePanel == invitePlayersPanel) {
			openNextScreen (teamPreviewPanel);
			invitePlayersButton.gameObject.SetActive (true);
		}
	}

	public void backButtonOnClickListner() {
		if (activePanel == startGamePanel) {//should never happen; back button will be hidden on this panel
			closePlayGameMenu ();
		} else if (activePanel == createGamePanel) {
			openPrevScreen (startGamePanel);
			backButton.gameObject.SetActive (false);
			nextButton.gameObject.SetActive (false);
		} else if (activePanel == selectLocationPanel) {
			openPrevScreen (createGamePanel);
		} else if (activePanel == gameConfirmationPanel) {
			openPrevScreen (selectLocationPanel);
		} else if (activePanel == teamPreviewPanel) {
			openPrevScreen (gameConfirmationPanel);
			invitePlayersButton.gameObject.SetActive (false);
		} else if (activePanel == invitePlayersPanel) {
			openPrevScreen (teamPreviewPanel);
			invitePlayersButton.gameObject.SetActive (true);
		}
	}

	public void invitePlayersButtonOnClickListner() {
		openNextScreen (invitePlayersPanel);
		invitePlayersButton.gameObject.SetActive (false);
	}

}