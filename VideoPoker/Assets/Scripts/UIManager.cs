using System.Collections;
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
		_wager.text = "WAGER    " + _wagerInt;
		_win.gameObject.SetActive(false);
		_winningHandText.gameObject.SetActive(false);
		OnDisableText();

		//SetInteractableButtons(false);
		SetInteractableHoldButtons(false);

	}

	public void DisplayEarnings(int earnings, string winningHand)
	{
		_win.text = "WIN    " + earnings;
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
	//_UIManager.SetInteractableHoldButtons(true);
	//_UIManager.SetInteractableBetButtons(false);

	public void SetInteractableHoldButtons(bool interactable)
	{
		for (int i = 0; i < _holdButtons.Length; i++)
		{
			_holdButtons[i].interactable = interactable;
		}
		print("bet buttons1");
	}
	public void SetInteractableBetButtons(bool interactable)
	{
		print("bet buttons");
		_betButton.interactable = interactable;
		_maxBetButton.interactable = interactable;
	}
	/*
	public void SetInteractableButtons(bool interactable)
	{
		for (int i = 0; i < _holdButtons.Length; i++)
		{
			_holdButtons[i].interactable = interactable;
		}

		
	}*/

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
		//_wager.text = "WAGER    " + 0;
		_winningHandText.gameObject.SetActive(false);
		_win.gameObject.SetActive(false);

	}

	public void AddWager()
	{

		if (_wagerInt < _maxWager)
			_wagerInt++;
		else
			_wagerInt = 0;

		_wager.text = "WAGER    " + _wagerInt;
		_player.AddWager();
	}
	public void MaxWager()
	{
		_wagerInt = _player.GetMaxWager();

		_wager.text = "WAGER    " + _wagerInt;
		_player.SetMaxWager();
	}

	public void DealDraw()
	{
		_dealButton.gameObject.SetActive(false);
		_drawButton.gameObject.SetActive(true);
		_betButton.interactable = false;
	}

	public void DrawDeal()
	{
		_dealButton.gameObject.SetActive(true);
		_drawButton.gameObject.SetActive(false);
		_betButton.interactable = true;
	}
  
}
