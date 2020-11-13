using System;

public struct EncInt
{
    /// A struct for storing a 32-bit integer while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a floating-point number that is affected by random values. { encryptionKey1 & encryptionKey2 }
    /// Every time the value changes, the encryption keys change too. And it works exactly as an int.
    ///
    /// Wiki page: https://github.com/JosepeDev/VarEnc/wiki

    #region Variables And Properties

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
            encryptedValue = Encrypt(value);
        }
        get
        {
            return Math.Round(Decrypt(encryptedValue));
        }
    }

    #endregion

    #region Methods

    private static EncInt NewEncInt(int value)
    {
        EncInt theEncInt = new EncInt
        {
            encryptionKey1 = GetEncryptionKey(),
            encryptionKey2 = GetEncryptionKey(),
            Value = value
        };
        return theEncInt;
    }

    // Encryption Key Generator
    static private Random random = new Random();
    public static double GetEncryptionKey() => (random.NextDouble() * 10);

    // Takes a given value and returns it encrypted
    private double Encrypt(double value)
    {
        double valueToReturn = value;
        valueToReturn += encryptionKey1;
        valueToReturn *= encryptionKey2;
        return valueToReturn;
    }

    // Takes an encrypted value and returns it decrypted
    private double Decrypt(double value)
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
    public static implicit operator long(EncInt eint1) => (long)eint1.Value;

    #endregion
}