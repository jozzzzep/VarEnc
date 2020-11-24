using System;

public struct EncDouble
{
    /// A struct for storing a Double while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a different that is affected by random values. { encryptionKey1 & encryptionKey2 }
    /// Every time the value changes, the encryption keys change too. And it works exactly as an double.
    ///
    /// WIKI & INFO: https://github.com/JosepeDev/VarEnc

    #region Variables And Properties

    // The encryption values
    private double encryptionKey1;
    private double encryptionKey2;

    // The encrypted value stored in memory
    private double encryptedValue;

    // The decrypted value
    public double Value
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

    public Double Epsilon { get => Double.Epsilon; }
    public Double MaxValue { get => Double.MaxValue; }
    public Double MinValue { get => Double.MinValue; }
    public Double NaN { get => Double.NaN; }
    public Double NegativeInfinity { get => Double.NegativeInfinity; }
    public Double PositiveInfinity { get => Double.PositiveInfinity; }

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
    static private double GetEncryptionKey() => random.NextDouble();

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

    // Overrides
    public int CompareTo(object value) => Value.CompareTo(value);
    public int CompareTo(Double value) => Value.CompareTo(value);
    public bool Equals(Double obj) => Value.Equals(obj);
    public override bool Equals(object obj) => Value.Equals(obj);
    public override int GetHashCode() => Value.GetHashCode();
    public TypeCode GetTypeCode() => Value.GetTypeCode();
    public override string ToString() => Value.ToString();
    public string ToString(IFormatProvider provider) => Value.ToString(provider);
    public string ToString(string format) => Value.ToString(format);
    public string ToString(string format, IFormatProvider provider) => Value.ToString(format, provider);

    #endregion

    #region Operators Overloading

    /// + - * / %
    public static EncDouble operator +(EncDouble eint1, EncDouble eint2) => EncDouble.NewEncDouble(eint1.Value + eint2.Value);
    public static EncDouble operator -(EncDouble eint1, EncDouble eint2) => EncDouble.NewEncDouble(eint1.Value - eint2.Value);
    public static EncDouble operator *(EncDouble eint1, EncDouble eint2) => EncDouble.NewEncDouble(eint1.Value * eint2.Value);
    public static EncDouble operator /(EncDouble eint1, EncDouble eint2) => EncDouble.NewEncDouble(eint1.Value / eint2.Value);
    public static EncDouble operator %(EncDouble eint1, EncDouble eint2) => EncDouble.NewEncDouble(eint1.Value % eint2.Value);

    public static double operator +(EncDouble edouble1, ulong edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, ulong edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, ulong edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, ulong edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, ulong edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, long edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, long edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, long edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, long edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, long edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, uint edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, uint edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, uint edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, uint edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, uint edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, int edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, int edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, int edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, int edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, int edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, ushort edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, ushort edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, ushort edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, ushort edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, ushort edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, short edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, short edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, short edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, short edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, short edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, byte edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, byte edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, byte edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, byte edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, byte edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, sbyte edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, sbyte edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, sbyte edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, sbyte edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, sbyte edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, double edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, double edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, double edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, double edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, double edouble2) => edouble1.Value % edouble2;

    public static double operator +(EncDouble edouble1, float edouble2) => edouble1.Value + edouble2;
    public static double operator -(EncDouble edouble1, float edouble2) => edouble1.Value - edouble2;
    public static double operator *(EncDouble edouble1, float edouble2) => edouble1.Value * edouble2;
    public static double operator /(EncDouble edouble1, float edouble2) => edouble1.Value / edouble2;
    public static double operator %(EncDouble edouble1, float edouble2) => edouble1.Value % edouble2;

    /// == != < >

    public static bool operator ==(EncDouble eint1, EncDouble eint2) => eint1.Value == eint2.Value;
    public static bool operator !=(EncDouble eint1, EncDouble eint2) => eint1.Value != eint2.Value;
    public static bool operator <(EncDouble eint1, EncDouble eint2) => eint1.Value < eint2.Value;
    public static bool operator >(EncDouble eint1, EncDouble eint2) => eint1.Value > eint2.Value;

    public static bool operator ==(EncDouble eint1, ulong eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, ulong eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, ulong eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, ulong eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, long eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, long eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, long eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, long eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, uint eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, uint eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, uint eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, uint eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, int eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, int eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, int eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, int eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, ushort eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, ushort eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, ushort eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, ushort eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, short eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, short eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, short eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, short eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, byte eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, byte eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, byte eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, byte eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, sbyte eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, sbyte eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, sbyte eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, sbyte eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, decimal eint2) => (decimal)eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, decimal eint2) => (decimal)eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, decimal eint2) => (decimal)eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, decimal eint2) => (decimal)eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, double eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, double eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, double eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, double eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDouble eint1, float eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDouble eint1, float eint2) => eint1.Value != eint2;
    public static bool operator >(EncDouble eint1, float eint2) => eint1.Value > eint2;
    public static bool operator <(EncDouble eint1, float eint2) => eint1.Value < eint2;

    /// assign
    public static implicit operator EncDouble(double value) => EncDouble.NewEncDouble(value);
    public static explicit operator decimal(EncDouble eint1) => (decimal)eint1.Value;
    public static implicit operator double(EncDouble eint1) => eint1.Value;
    public static explicit operator float(EncDouble eint1) => (float)eint1.Value;
    public static explicit operator ulong(EncDouble eint1) => (ulong)eint1.Value;
    public static explicit operator long(EncDouble eint1) => (long)eint1.Value;
    public static explicit operator uint(EncDouble eint1) => (uint)eint1.Value;
    public static explicit operator int(EncDouble eint1) => (int)eint1.Value;
    public static explicit operator ushort(EncDouble eint1) => (ushort)eint1.Value;
    public static explicit operator short(EncDouble eint1) => (short)eint1.Value;
    public static explicit operator byte(EncDouble eint1) => (byte)eint1.Value;
    public static explicit operator sbyte(EncDouble eint1) => (sbyte)eint1.Value;

    #endregion
}