using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private int _playerCredits;
	private int _playerWager;
	private Player _player;
	private Table _table;
	public GameManager instance;
	
	
	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(this);

		_player = GameObject.Find("Player").GetComponent<Player>();
		_table = GameObject.Find("Canvas").GetComponent<Table>();

		if (_table == null) print("table is null");
		if (_player == null) print("player is null");
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
		}
		else
			print("Game Over");

	}
}
