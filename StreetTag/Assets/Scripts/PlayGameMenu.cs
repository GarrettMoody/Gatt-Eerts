using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGameMenu : MonoBehaviour {

	public Canvas playGameCanvas;
	public GameObject startGamePanel;
	public GameObject createGamePanel;
	public GameObject joinGamePanel;
	public GameObject selectLocationPanel;
	public GameObject gameConfirmationPanel;
	public GameObject teamPreviewPanel;
	public GameObject invitePlayersPanel;
	public Button nextButton;
	public Button backButton;
	public Button closeButton;

	private GameObject activePanel;

	// Use this for initialization
	void Start () {
		playGameCanvas.gameObject.SetActive (false);
	}

	public void openPlayGameMenu() {
		playGameCanvas.gameObject.SetActive (true);
		startGamePanel.gameObject.SetActive (true);
		nextButton.gameObject.SetActive (false);
		backButton.gameObject.SetActive (false);
		closeButton.gameObject.SetActive (true);
		activePanel = startGamePanel;

	}

	public void closePlayGameMenu() {
		playGameCanvas.gameObject.SetActive (false);
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

	void openNextScreen(GameObject currentScreen, GameObject nextScreen) {
		currentScreen.gameObject.SetActive (false);
		nextScreen.gameObject.SetActive (true);
		activePanel = nextScreen;
	}

	void openPrevScreen (GameObject currentScreen, GameObject prevScreen) {
		currentScreen.gameObject.SetActive (false);
		prevScreen.gameObject.SetActive (true);
		activePanel = prevScreen;
	}

	public void nextButtonOnClickListener() {
		if (activePanel == startGamePanel) {//should never happen; next button will be hidden on this panel
			createGame ();
		} else if (activePanel == createGamePanel) {
			openNextScreen (createGamePanel, selectLocationPanel);
		} else if (activePanel == selectLocationPanel || activePanel == invitePlayersPanel) {
			openNextScreen (selectLocationPanel, gameConfirmationPanel);
		} else if (activePanel == gameConfirmationPanel) {
			openNextScreen (gameConfirmationPanel, teamPreviewPanel);
		} else if (activePanel == teamPreviewPanel) {
			closePlayGameMenu ();
		}
	}

	public void backButtonOnClickListner() {
		if (activePanel == startGamePanel) {//should never happen; next button will be hidden on this panel
			closePlayGameMenu ();
		} else if (activePanel == createGamePanel) {
			openPrevScreen (createGamePanel, startGamePanel);
			backButton.gameObject.SetActive (false);
			nextButton.gameObject.SetActive (false);
		} else if (activePanel == selectLocationPanel) {
			openPrevScreen (selectLocationPanel, createGamePanel);
		} else if (activePanel == gameConfirmationPanel) {
			openPrevScreen (gameConfirmationPanel, selectLocationPanel);
		} else if (activePanel == teamPreviewPanel) {
			openPrevScreen (teamPreviewPanel, gameConfirmationPanel);
		} else if (activePanel == invitePlayersPanel) {
			openPrevScreen (invitePlayersPanel, teamPreviewPanel);
		}
	}

}
