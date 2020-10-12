using System;

static class EncryptionTools
{
    /// A static class with tools for these classes:
    /// EncryptedInt
    
    #region Methods

    // The Random class for getting the random numbers
    static private Random random = new Random();

    // Returns a random float between 1 and 10
    public static float RandomNumber()
    {
        return (float)(random.NextDouble() * 10);
    }

    #endregion
}