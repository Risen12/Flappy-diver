using System;

public static class UserUtils
{
    private static Random _random = new Random();

    public static float GetRandomNumber(float minimumNumber, float maximumNumber)
    { 
        return _random.Next((int)minimumNumber, (int)maximumNumber + 1);
    }
}
