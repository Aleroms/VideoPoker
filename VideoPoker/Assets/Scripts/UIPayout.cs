using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPayout : MonoBehaviour
{
	[SerializeField]
	private int[] _payout;

	[SerializeField]
	private Text[] _payoutDisplay;

	[SerializeField]
	private Image[] _panels;

	private int _index = 0;

	void Start()
	{
		CalculatePayout();

		_panels[_index].color = Color.red;
	}

	private void CalculatePayout()
	{
		string numPayout = "";

		for(int j = 0; j < 5; j++)
		{
			
			for(int i = 0; i < 9; i++)
			{
				int b = j + 1;
				int a = b * _payout[i];
				numPayout += a + "\n";

			}
			_payoutDisplay[j].text = numPayout;
			numPayout = "";
		}
	}
	public void PanelAddWager()
	{
		_panels[_index].color = new Color(0.3018f, 0.3018f, 0.3018f); //reset
		_index++;

		if (_index < _panels.Length)
		{
			_panels[_index].color = Color.red;
		}
		else
		{
			_index = 0;
			_panels[_index].color = Color.red;
		}
	}
	public void PanelMaxWager()
	{   
		//reset
		_panels[_index].color = new Color(0.3018f, 0.3018f, 0.3018f); 
		_index = _panels.Length - 1;
		print(_index + "-1");
		_panels[_index].color = Color.red;
	}
}
