using System;

public struct EncLong_0_3_0
{
    /// A struct for storing a 64-bit integer while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a floating-point number that is affected by random values. { encryptionKey1 & encryptionKey2 }
    /// Every time the value changes, the encryption keys change too. And it works exactly as a long.
    ///
    /// Wiki page: https://github.com/JosepeDev/Variable-Encryption/wiki
    /// Examples and tutorial: https://github.com/JosepeDev/Variable-Encryption/wiki/Examples-&-Tutorial

    #region Content

    #region Variables

    // The encryption values
    private decimal encryptionKey1;
    private decimal encryptionKey2;

    // The encrypted value stored in memory
    private decimal encryptedValue;

    // The decrypted value
    private decimal Value
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

    private EncLong_0_3_0(long value)
    {
        // set default values
        encryptionKey1 = 0;
        encryptionKey2 = 0;
        encryptedValue = 0;

        // initialize
        SetEncryptionKeys();
        encryptedValue = encrypt(value);
    }

    #endregion

    #region Methods

    // Takes a given value and returns it encrypted
    private decimal encrypt(decimal value)
    {
        decimal valueToReturn = value;
        valueToReturn += encryptionKey1;
        valueToReturn *= encryptionKey2;
        return valueToReturn;
    }

    // Takes an encrypted value and returns it decrypted
    private decimal decrypt(decimal value)
    {
        decimal valueToReturn = value;
        valueToReturn /= encryptionKey2;
        valueToReturn -= encryptionKey1;
        return valueToReturn;
    }

    // Setting the encryption keys to a new random values
    private void SetEncryptionKeys()
    {
        encryptionKey1 = EncryptionTools_0_3_0.RandomNumberDecimal();
        encryptionKey2 = EncryptionTools_0_3_0.RandomNumberDecimal();
    }

    // Returns the stored value as a string
    public override string ToString()
    {
        return ((long)Value).ToString();
    }

    // Not recommended to use
    public override bool Equals(object obj)
    {
        return obj is EncLong_0_3_0 eint &&
               (long)Value == (long)eint.Value;
    }
    public override int GetHashCode()
    {
        return (int)Value;
    }

    #endregion

    #region Operators Overloading

    /// + - * / %
    public static EncLong_0_3_0 operator +(EncLong_0_3_0 eint1, EncLong_0_3_0 eint2) => new EncLong_0_3_0((long)(eint1.Value + eint2.Value));
    public static EncLong_0_3_0 operator -(EncLong_0_3_0 eint1, EncLong_0_3_0 eint2) => new EncLong_0_3_0((long)(eint1.Value - eint2.Value));
    public static EncLong_0_3_0 operator *(EncLong_0_3_0 eint1, EncLong_0_3_0 eint2) => new EncLong_0_3_0((long)(eint1.Value * eint2.Value));
    public static EncLong_0_3_0 operator /(EncLong_0_3_0 eint1, EncLong_0_3_0 eint2) => new EncLong_0_3_0((long)(eint1.Value / eint2.Value));
    public static EncLong_0_3_0 operator %(EncLong_0_3_0 eint1, EncLong_0_3_0 eint2) => new EncLong_0_3_0((long)(eint1.Value % eint2.Value));

    public static long operator +(EncLong_0_3_0 eint1, long eint2) => (long)eint1.Value + eint2;
    public static long operator -(EncLong_0_3_0 eint1, long eint2) => (long)eint1.Value - eint2;
    public static long operator *(EncLong_0_3_0 eint1, long eint2) => (long)eint1.Value * eint2;
    public static long operator /(EncLong_0_3_0 eint1, long eint2) => (long)eint1.Value / eint2;
    public static long operator %(EncLong_0_3_0 eint1, long eint2) => (long)eint1.Value % eint2;

    /// == != < >
    public static bool operator ==(EncLong_0_3_0 eint1, long eint2) => (long)eint1.Value == eint2;
    public static bool operator !=(EncLong_0_3_0 eint1, long eint2) => (long)eint1.Value != eint2;
    public static bool operator >(EncLong_0_3_0 eint1, long eint2) => (long)eint1.Value > eint2;
    public static bool operator <(EncLong_0_3_0 eint1, long eint2) => (long)eint1.Value < eint2;

    public static bool operator ==(EncLong_0_3_0 eint1, EncLong_0_3_0 eint2) => (long)eint1.Value == (long)eint2.Value;
    public static bool operator !=(EncLong_0_3_0 eint1, EncLong_0_3_0 eint2) => (long)eint1.Value != (long)eint2.Value;
    public static bool operator <(EncLong_0_3_0 eint1, EncLong_0_3_0 eint2) => (long)eint1.Value < (long)eint2.Value;
    public static bool operator >(EncLong_0_3_0 eint1, EncLong_0_3_0 eint2) => (long)eint1.Value > (long)eint2.Value;

    /// assign
    public static implicit operator EncLong_0_3_0(long value) => new EncLong_0_3_0(value);
    public static implicit operator long(EncLong_0_3_0 eint1) => (long)eint1.Value;

    #endregion

    #endregion
}