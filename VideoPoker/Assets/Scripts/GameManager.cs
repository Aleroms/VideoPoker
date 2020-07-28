using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static int _playerCredits;
	private int _playerWager;
	private bool _restart;
	private Deck _deck;
	private Player _player;
	private Table _table;
	private UIManager _UIManager;
	private CombinationsPayOut _cpo;
	public static GameManager instance;
	
	
	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(this);

		_deck = GameObject.Find("Deck").GetComponent<Deck>();
		_player = GameObject.Find("Player").GetComponent<Player>();
		_table = GameObject.Find("Canvas").GetComponent<Table>();
		_cpo = GameObject.Find("GameManager").GetComponent<CombinationsPayOut>();
		_UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

		if (_table == null) print("table is null");
		if (_player == null) print("player is null");
		if (_cpo == null) print("combination is null");
		if (_UIManager == null) print("UIManager is null");

		_restart = false;
	}

	void Start()
	{
		_deck.StartGame();
		_player.StartGame();
		_UIManager.StartGame();
		_table.StartGame();

		_player.SetMaxWager(5);
		_playerCredits = _player.GetCredits();
		
	}//changed the button from deal to playhand
	public void PlayHand()
	{
		_playerCredits = _player.GetCredits();

		if (_playerCredits > 0)
		{
			_playerWager = _player.GetWager();

			if (_playerWager > 0)
			{
				if (_table.IsFaceDown())
				{
					_table.DisableBackFaceCards();

					//write code here?
					_UIManager.SetInteractableBetButtons(false);
					_UIManager.SetInteractableHoldButtons(true);
				}
				else
				{
					if (_restart == false)
					{
						//enable hold buttons
						//disable max and bet buttons
						//_UIManager.SetInteractableButtons(true);
						print("here");

						//_table.SetDisplayCards(); 7/27
						//_UIManager.DealDraw();
						PlayGame();
						_restart = true;

						_UIManager.SetInteractableBetButtons(true);
						_UIManager.SetInteractableHoldButtons(false);
					}
					else
					{//i can still bet even though i shouldn't be allowed too
					 //hold buttons are not interactable
						_UIManager.SetInteractableHoldButtons(true);
						_UIManager.SetInteractableBetButtons(false);

						RestartMatch();
						_restart = false;
						print("restarting...");
					}
				}

			}
			else
			{
				print("PLEASE BET");
			}

		}
		else
			GameOver();

		//_UIManager.DrawDeal();

	}
	/*
	public void Draw()
	{
		_playerCredits = _player.GetCredits();

		if (_playerCredits > 0)
		{
			_playerWager = _player.GetWager();

			if (_playerWager > 0)
			{
				PlayGame();
				_restart = true;
			}
			else
			{
				print("PLEASE BET");
			}

		}
		else
			GameOver();

		_UIManager.DrawDeal();

	}
	
	public void Deal()
	{
		if (_restart == false)
		{
			//if player placed a bet
			_playerWager = _player.GetWager();

			if (_playerWager > 0)
			{
				//_table.SetDisplayCards(); 7/27
				_UIManager.DealDraw();
				
			}
			else
			{
				print("PLEASE BET");
			}		
		}
		else
		{
			RestartMatch();
			print("restarting...");
		}
	}*/

	void RestartMatch()
	{
		_deck.Reset();
		_table.Reset();
		_UIManager.Reset();
		_table.SetDisplayCards();
		//Credits.SetCredits(_playerCredits);

		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		
		//_table.Reset();
		//_UIManager.Reset();
		//_restart = false;
	}
	
	void PlayGame()
	{
		//print("name");
		_UIManager.OnDisableText();
		_table.Play();

		

		if (_cpo.CheckCards(_table.GetSelectedCards()))
		{
			int payout = _playerWager * _cpo.GetPayOut();

			_player.AddCredits(payout);
			_playerCredits = _player.GetCredits();

			_UIManager.DisplayEarnings(payout, _cpo.GetWinningHand());

		}
		else
			LoseCondition();
	}

	void LoseCondition()
	{
		_player.SubCredits(_playerWager);
		_playerCredits = _player.GetCredits();

		_UIManager.LoseCondition(_playerCredits);
		
	}

	void GameOver()
	{
		print("Game Over");
		Application.Quit();
	}

}