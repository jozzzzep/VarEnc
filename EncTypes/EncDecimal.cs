using System;

public struct EncDecimal
{
    /// A struct for storing a Decimal while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a different that is affected by random values. { encryptionKey1 & encryptionKey2 }
    /// Every time the value changes, the encryption keys change too. And it works exactly as an deciaml.
    ///
    /// Wiki page: https://github.com/JosepeDev/VarEnc/wiki

    #region Variables And Properties

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
            encryptedValue = Encrypt(value);
        }
        get
        {
            return (decimal)Decrypt(encryptedValue);
        }
    }

    #endregion

    #region Methods

    private static EncDecimal NewEncDecimal(decimal value)
    {
        EncDecimal theEncdecimal = new EncDecimal
        {
            encryptionKey1 = GetEncryptionKey(),
            encryptionKey2 = GetEncryptionKey(),
            Value = value
        };
        return theEncdecimal;
    }

    // Encryption key generator
    static private Random random = new Random();
    public static decimal GetEncryptionKey() => (decimal)(random.NextDouble());

    // Takes a given value and returns it encrypted
    private decimal Encrypt(decimal value)
    {
        decimal valueToReturn = value;
        valueToReturn += encryptionKey1;
        valueToReturn *= encryptionKey2;
        return valueToReturn;
    }

    // Takes an encrypted value and returns it decrypted
    private decimal Decrypt(decimal value)
    {
        decimal valueToReturn = value;
        valueToReturn /= encryptionKey2;
        valueToReturn -= encryptionKey1;
        return valueToReturn;
    }

    // Returns the stored value as a string
    public override string ToString()
    {
        return (Value).ToString();
    }

    #endregion

    #region Operators Overloading

    /// + - * / %
    public static EncDecimal operator +(EncDecimal eint1, EncDecimal eint2) => EncDecimal.NewEncDecimal(eint1.Value + eint2.Value);
    public static EncDecimal operator -(EncDecimal eint1, EncDecimal eint2) => EncDecimal.NewEncDecimal(eint1.Value - eint2.Value);
    public static EncDecimal operator *(EncDecimal eint1, EncDecimal eint2) => EncDecimal.NewEncDecimal(eint1.Value * eint2.Value);
    public static EncDecimal operator /(EncDecimal eint1, EncDecimal eint2) => EncDecimal.NewEncDecimal(eint1.Value / eint2.Value);
    public static EncDecimal operator %(EncDecimal eint1, EncDecimal eint2) => EncDecimal.NewEncDecimal(eint1.Value % eint2.Value);

    public static decimal operator +(EncDecimal edecimal1, decimal edecimal2) => edecimal1.Value + edecimal2;
    public static decimal operator -(EncDecimal edecimal1, decimal edecimal2) => edecimal1.Value - edecimal2;
    public static decimal operator *(EncDecimal edecimal1, decimal edecimal2) => edecimal1.Value * edecimal2;
    public static decimal operator /(EncDecimal edecimal1, decimal edecimal2) => edecimal1.Value / edecimal2;
    public static decimal operator %(EncDecimal edecimal1, decimal edecimal2) => edecimal1.Value % edecimal2;

    /// == != < >
    public static bool operator ==(EncDecimal eint1, decimal eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDecimal eint1, decimal eint2) => eint1.Value != eint2;
    public static bool operator >(EncDecimal eint1, decimal eint2) => eint1.Value > eint2;
    public static bool operator <(EncDecimal eint1, decimal eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDecimal eint1, EncDecimal eint2) => eint1.Value == eint2.Value;
    public static bool operator !=(EncDecimal eint1, EncDecimal eint2) => eint1.Value != eint2.Value;
    public static bool operator <(EncDecimal eint1, EncDecimal eint2) => eint1.Value < eint2.Value;
    public static bool operator >(EncDecimal eint1, EncDecimal eint2) => eint1.Value > eint2.Value;

    /// assign
    public static implicit operator EncDecimal(decimal value) => EncDecimal.NewEncDecimal(value);
    public static implicit operator decimal(EncDecimal eint1) => eint1.Value;
    public static explicit operator float(EncDecimal eint1) => (float)eint1.Value;
    public static explicit operator double(EncDecimal eint1) => (double)eint1.Value;
    public static explicit operator int(EncDecimal eint1) => (int)eint1.Value;
    public static explicit operator long(EncDecimal eint1) => (long)eint1.Value;

    #endregion
}