﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private Text[] _heldText;

	[SerializeField]
	private Text _wager;

	[SerializeField]
	private Text _win;

	[SerializeField]
	private Text _credits;

	[SerializeField]
	private Text _winningHandText;

	[SerializeField]
	private Button[] _holdButtons;

	[SerializeField]
	private Button _betButton;

	[SerializeField]
	private Button _maxBetButton;

	[SerializeField]
	private Button _dealButton;

	[SerializeField]
	private Button _drawButton;

	[SerializeField]
	private GameObject _notificationPanel;

	[SerializeField]
	private Text _notificationMessage;

	private Player _player;
	private Table _table;

	private int _maxWager;
	private int _wagerInt;
    
	public void StartGame()
	{

		_player = GameObject.Find("Player").GetComponent<Player>();
		_table = GameObject.Find("Canvas").GetComponent<Table>();

		if (_table == null) print("table is null");

		if (_player != null)
		{
			_credits.text = "CREDITS     " + _player.GetCredits();
			_maxWager = 5;

		}
		_wagerInt = 0;
		_wager.text = "WAGER " + _wagerInt;
		_win.gameObject.SetActive(false);
		_winningHandText.gameObject.SetActive(false);
		_notificationMessage.gameObject.SetActive(false);
		_notificationPanel.gameObject.SetActive(false);
		OnDisableText();

		
		SetInteractableHoldButtons(false);

	}
	public void DisplayMessage(string message)
	{
		StartCoroutine(DisplayMessageCoroutine(message));
	}
	IEnumerator DisplayMessageCoroutine(string message)
	{
		_notificationPanel.gameObject.SetActive(true);
		_notificationMessage.gameObject.SetActive(true);

		_notificationMessage.text = message;

		yield return new WaitForSeconds(0.75f);

		_notificationPanel.gameObject.SetActive(false);
		_notificationMessage.gameObject.SetActive(false);
	}

	public void DisplayEarnings(int earnings, string winningHand)
	{
		_win.text = "WIN   " + earnings;
		_win.gameObject.SetActive(true);

		_winningHandText.text = winningHand;
		_winningHandText.gameObject.SetActive(true);

		_credits.text = "CREDITS    " + _player.GetCredits();
	}

	public void LoseCondition(int credits)
	{
		_credits.text = "CREDITS    " + credits;

		_winningHandText.gameObject.SetActive(true);
		
		_winningHandText.text = "YOU LOSE";
	}
	

	public void SetInteractableHoldButtons(bool interactable)
	{
		for (int i = 0; i < _holdButtons.Length; i++)
		{
			_holdButtons[i].interactable = interactable;
		}
		
	}
	public void SetInteractableBetButtons(bool interactable)
	{
		
		_betButton.interactable = interactable;
		_maxBetButton.interactable = interactable;
	}

	public void OnDisableText()
	{
		for(int i=0; i < _heldText.Length; i++)
		{
			_heldText[i].gameObject.SetActive(false);
		}
	}

	public void UserSelect(int n)
	{
		if( n >= 0 && n < _heldText.Length)
		{
			if (_heldText[n].gameObject.activeSelf == false)
			{
				_heldText[n].gameObject.SetActive(true);
				_table.SetIsSelected(n, true);
			}
			else
			{
				_heldText[n].gameObject.SetActive(false);
				_table.SetIsSelected(n, false);
			}
		}

		
	}

	public void Reset()
	{
	
		_winningHandText.gameObject.SetActive(false);
		_win.gameObject.SetActive(false);

	}

	public void AddWager()
	{
		_player.AddWager();

		_wagerInt = _player.GetWager();

		_wager.text = "WAGER " + _wagerInt;
		
	}
	public void MaxWager()
	{
		_wagerInt = _player.GetMaxWager();

		_wager.text = "WAGER " + _wagerInt;
		_player.SetMaxWager();
	}
	
  
}
