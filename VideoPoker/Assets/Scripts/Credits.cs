using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Credits
{
	private static int playerCredits = 100;

	public static int GetCredits()
	{
		return playerCredits;
	}
	public static void SetCredits(int n)
	{
		playerCredits = n;
	}
}
