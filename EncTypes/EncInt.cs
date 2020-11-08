using System;

public struct EncInt
{
    /// A struct for storing a 32-bit integer while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a floating-point number that is affected by random values. { encryptionKey1 & encryptionKey2 }
    /// Every time the value changes, the encryption keys change too. And it works exactly as an int.
    ///
    /// Wiki page: https://github.com/JosepeDev/Variable-Encryption/wiki

    #region Content

    #region Encryption Key Generator

    // The Random class for getting the random numbers
    static private Random random = new Random();

    // Returns a random double between 1 and 10
    public static double GetEncryptionKey()
    {
        return (random.NextDouble() * 10);
    }

    #endregion

    #region Variables

    // The encryption values
    private double encryptionKey1;
    private double encryptionKey2;

    // The encrypted value stored in memory
    private double encryptedValue;

    // The decrypted value
    private double Value
    {
        set
        {
            encryptedValue = encrypt(value);
        }
        get
        {
            return Math.Round(decrypt(encryptedValue));
        }
    }

    #endregion

    #region Constructors

    public static EncInt NewEncInt(int value)
    {
        EncInt theEncInt = new EncInt
        {
            encryptionKey1 = GetEncryptionKey(),
            encryptionKey2 = GetEncryptionKey(),
            Value = value
        };
        return theEncInt;
    }

    #endregion

    #region Methods

    // Takes a given value and returns it encrypted
    private double encrypt(double value)
    {
        double valueToReturn = value;
        valueToReturn += encryptionKey1;
        valueToReturn *= encryptionKey2;
        return valueToReturn;
    }

    // Takes an encrypted value and returns it decrypted
    private double decrypt(double value)
    {
        double valueToReturn = value;
        valueToReturn /= encryptionKey2;
        valueToReturn -= encryptionKey1;
        return valueToReturn;
    }

    // Returns the stored value as a string
    public override string ToString()
    {
        return ((int)Value).ToString();
    }

    // Not recommended to use
    public override bool Equals(object obj)
    {
        return obj is EncInt eint &&
               (int)Value == (int)eint.Value;
    }
    public override int GetHashCode()
    {
        return (int)Value;
    }

    #endregion

    #region Operators Overloading

    /// + - * / %
    public static EncInt operator +(EncInt eint1, EncInt eint2) => EncInt.NewEncInt((int)(eint1.Value + eint2.Value));
    public static EncInt operator -(EncInt eint1, EncInt eint2) => EncInt.NewEncInt((int)(eint1.Value - eint2.Value));
    public static EncInt operator *(EncInt eint1, EncInt eint2) => EncInt.NewEncInt((int)(eint1.Value * eint2.Value));
    public static EncInt operator /(EncInt eint1, EncInt eint2) => EncInt.NewEncInt((int)(eint1.Value / eint2.Value));
    public static EncInt operator %(EncInt eint1, EncInt eint2) => EncInt.NewEncInt((int)(eint1.Value % eint2.Value));

    public static int operator +(EncInt eint1, int eint2) => (int)eint1.Value + eint2;
    public static int operator -(EncInt eint1, int eint2) => (int)eint1.Value - eint2;
    public static int operator *(EncInt eint1, int eint2) => (int)eint1.Value * eint2;
    public static int operator /(EncInt eint1, int eint2) => (int)eint1.Value / eint2;
    public static int operator %(EncInt eint1, int eint2) => (int)eint1.Value % eint2;

    /// == != < >
    public static bool operator ==(EncInt eint1, int eint2) => (int)eint1.Value == eint2;
    public static bool operator !=(EncInt eint1, int eint2) => (int)eint1.Value != eint2;
    public static bool operator >(EncInt eint1, int eint2) => (int)eint1.Value > eint2;
    public static bool operator <(EncInt eint1, int eint2) => (int)eint1.Value < eint2;

    public static bool operator ==(EncInt eint1, EncInt eint2) => (int)eint1.Value == (int)eint2.Value;
    public static bool operator !=(EncInt eint1, EncInt eint2) => (int)eint1.Value != (int)eint2.Value;
    public static bool operator <(EncInt eint1, EncInt eint2) => (int)eint1.Value < (int)eint2.Value;
    public static bool operator >(EncInt eint1, EncInt eint2) => (int)eint1.Value > (int)eint2.Value;

    /// assign
    public static implicit operator EncInt(int value) => EncInt.NewEncInt(value);
    public static implicit operator int(EncInt eint1) => (int)eint1.Value;

    #endregion

    #endregion
}