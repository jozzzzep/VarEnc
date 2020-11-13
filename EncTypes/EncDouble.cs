using System;

public struct EncDouble
{
    /// A struct for storing a Double while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a different that is affected by random values. { encryptionKey1 & encryptionKey2 }
    /// Every time the value changes, the encryption keys change too. And it works exactly as an double.
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
            return Decrypt(encryptedValue);
        }
    }

    #endregion

    #region Methods

    private static EncDouble NewEncDouble(double value)
    {
        EncDouble theEncFloat = new EncDouble
        {
            encryptionKey1 = GetEncryptionKey(),
            encryptionKey2 = GetEncryptionKey(),
            Value = value
        };
        return theEncFloat;
    }

    // Encryption key generator
    static private Random random = new Random();
    public static double GetEncryptionKey() => random.NextDouble();

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
    public static explicit operator float(EncDouble eint1) => (float)eint1.Value;
    public static explicit operator decimal(EncDouble eint1) => (decimal)eint1.Value;
    public static explicit operator int(EncDouble eint1) => (int)eint1.Value;
    public static explicit operator long(EncDouble eint1) => (long)eint1.Value;

    #endregion
}