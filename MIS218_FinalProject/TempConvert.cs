using System;

public static class Convert
{
	public static double F2c(double f)
	{
		return (f - 32) * 5 / 9;
	}

	public static double C2f(double c)
    {
		return (c * 9 / 5) + 32;
    }
}
