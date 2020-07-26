using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
	public enum Suit { CLUB, DIAMOND, HEART, SPADE};
	[SerializeField]
	private Suit _suit;
	[SerializeField]
	private int _rank;

	//remove serializeField when submitting
    public Suit GetSuit()
	{
		return _suit;
	}
	public int GetRank()
	{
		return _rank;
	}
	
	public void setSuit(int i)
	{
		if (i == 0)
			_suit = Suit.CLUB;

		if (i == 1)
			_suit = Suit.DIAMOND;

		if (i == 2)
			_suit = Suit.HEART;

		if (i == 3)
			_suit = Suit.SPADE;

		//print(_suit);
	}
	public void setRank(int n)
	{
		_rank = n;
		//print("_rank now =" + _rank);
	}

}
