using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private int _credits;
	private int _maxWager;
	private int _wager;

  
	public void StartGame()
	{
		_credits = 100;
		//_credits = Credits.GetCredits();
		_wager = 0;
	}

	public void AddCredits(int n)
	{
		_credits += n;
	}

	public void SubCredits(int n)
	{
		_credits -= n;
	}

	public int GetCredits()
	{
		return _credits;
	}

	public int GetMaxWager()
	{
		return _maxWager;
	}

	public void SetMaxWager(int n)
	{
		_maxWager = n;
	}
	public void SetMaxWager()
	{
		_wager = _maxWager;
	}

	public int GetWager()
	{
		return _wager;
	}

	public void AddWager()
	{
		if (_wager != _maxWager)
			_wager++;
		else
			_wager = 1;

	}

	public void ResetWager()
	{
		_wager = 0;
	}

}
