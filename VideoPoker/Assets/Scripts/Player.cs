using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private int _credits;
	private int _wager;

    // Start is called before the first frame update
    void Start()
    {
		_credits = 100;
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
	public void SetWager()
	{
		if (_wager != 5)
			_wager++;

		print("wager" + _wager);
	}
	public void ResetWager()
	{
		_wager = 0;
	}
}
