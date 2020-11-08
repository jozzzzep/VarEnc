using System;

public struct EncDouble
{
    /// A struct for storing a Double while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a different that is affected by random values. { encryptionKey1 & encryptionKey2 }
    /// Every time the value changes, the encryption keys change too. And it works exactly as an double.
    ///
    /// Wiki page: https://github.com/JosepeDev/Variable-Encryption/wiki

    #region Content

    #region Encryption Key Generator

    // The Random class for getting the random numbers
    static private Random random = new Random();

    // Returns a random double between 1 and 10
    public static double GetEncryptionKey()
    {
        return random.NextDouble();
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
            return decrypt(encryptedValue);
        }
    }

    #endregion

    #region Constructors

    public static EncDouble NewEncDouble(double value)
    {
        EncDouble theEncFloat = new EncDouble
        {
            encryptionKey1 = GetEncryptionKey(),
            encryptionKey2 = GetEncryptionKey(),
            Value = value
        };
        return theEncFloat;
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
        return (Value).ToString();
    }

    #endregion

    #region Operators Overloading

    /// + - * / %
    public static EncDouble operator +(EncDouble eint1, EncDouble eint2) => EncDouble.NewEncDouble(eint1.Value + eint2.Value);
    public static EncDouble operator -(EncDouble eint1, EncDouble eint2) => EncDouble.NewEncDouble(eint1.Value - eint2.Value);
    public static EncDouble operator *(EncDouble eint1, EncDouble eint2) => EncDouble.NewEncDouble(eint1.Value * eint2.Value);
    public static EncDouble operator /(EncDouble eint1, EncDouble eint2) => EncDouble.NewEncDouble(eint1.Value / eint2.Value);
    public static EncDouble operator %(EncDouble eint1, EncDouble eint2) => EncDouble.NewEncDouble(eint1.Value % eint2.Value);

    public static double operator +(EncDouble edouble1, double edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, double edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, double edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, double edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, double edouble2) => edouble1.Value % edouble2;

    /// == != < >
    public static bool operator ==(EncDouble eint1, double eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, double eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, double eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, double eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, EncDouble eint2) => eint1.Value == eint2.Value;
    public static bool operator !=(EncDouble eint1, EncDouble eint2) => eint1.Value != eint2.Value;
    public static bool operator <(EncDouble eint1, EncDouble eint2) => eint1.Value < eint2.Value;
    public static bool operator >(EncDouble eint1, EncDouble eint2) => eint1.Value > eint2.Value;

    /// assign
    public static implicit operator EncDouble(double value) => EncDouble.NewEncDouble(value);
    public static implicit operator double(EncDouble eint1) => eint1.Value;

    #endregion

    #endregion
}
