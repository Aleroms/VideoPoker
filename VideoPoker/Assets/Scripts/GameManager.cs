using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private int _playerCredits;
	private int _playerWager;
	private Player _player;
	private Table _table;
	private CombinationsPayOut _cpo;
	public GameManager instance;
	
	
	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(this);

		_player = GameObject.Find("Player").GetComponent<Player>();
		_table = GameObject.Find("Canvas").GetComponent<Table>();
		_cpo = GameObject.Find("GameManager").GetComponent<CombinationsPayOut>();

		if (_table == null) print("table is null");
		if (_player == null) print("player is null");
		if (_cpo == null) print("combination is null");
	}
	void Start()
	{
		_player.SetMaxWager(5);
		_playerCredits = _player.GetCredits();
		
	}
	void Update()
	{

	}

	public void Deal()
	{
		_playerCredits = _player.GetCredits();

		if (_playerCredits > 0)
		{
			_playerWager = _player.GetWager();
			_table.Play();

			if (_cpo.CheckCards(_table.GetSelectedCards()))
			{
				print("you won");
			}
			else
				LoseCondition();
		}
		else
			GameOver();

	}
	void LoseCondition()
	{

	}
	void GameOver()
	{
		print("Game Over");
	}
}
