using System;

public struct EncFloat
{
    /// A struct for storing a Single (float) while efficiently keeping it encrypted in the memory.
    /// Instead of encrypting and decrypting yourself, you can just use the encrypted type (EncType) of the variable you want to be encrypted
    /// The encryption will happen in the background without you worrying about it
    /// In the memory it is saved as a different that is affected by random values. { encryptionKey1 & encryptionKey2 }
    /// Every time the value changes, the encryption keys change too. And it works exactly as an float.
    ///
    /// WIKI & INFO: https://github.com/JosepeDev/VarEnc

    #region Variables And Properties

    // The encryption values
    private readonly double encryptionKey1;
    private readonly double encryptionKey2;

    // The encrypted value stored in memory
    private readonly double encryptedValue;

    // The decrypted value
    private float Value
    {
        get => (float)Decrypt();
    }

    public static float Epsilon { get => Single.Epsilon; }
    public static float MaxValue { get => Single.MaxValue; }
    public static float MinValue { get => Single.MinValue; }
    public static float NaN { get => Single.NaN; }
    public static float NegativeInfinity { get => Single.NegativeInfinity; }
    public static float PositiveInfinity { get => Single.PositiveInfinity; }

    #endregion

    #region Methods And Constructors

    private EncFloat(float value)
    {
        encryptionKey1 = random.NextDouble() * 0.01;
        encryptionKey2 = random.NextDouble() * 10;
        encryptedValue = Encrypt(value, encryptionKey1, encryptionKey2);
    }

    // encryption key generator
    static private Random random = new Random();

    // Takes a given value and returns it encrypted
    private static double Encrypt(double value, double k1, double k2) => (value * k1) * k2;

    // Takes an encrypted value and returns it decrypted
    private double Decrypt() => (encryptedValue / encryptionKey2) / encryptionKey1;

    // Single methods
    public int CompareTo(Single value) => Value.CompareTo(value);
    public int CompareTo(object value) => Value.CompareTo(value);
    public override bool Equals(object obj) => Value.Equals(obj);
    public bool Equals(Single obj) => Value.Equals(obj);
    public override int GetHashCode() => Value.GetHashCode();
    public TypeCode GetTypeCode() => Value.GetTypeCode();
    public override string ToString() => Value.ToString();
    public string ToString(IFormatProvider provider) => Value.ToString(provider);
    public string ToString(string format) => Value.ToString(format);
    public string ToString(string format, IFormatProvider provider) => Value.ToString(format, provider);

    #endregion

    #region Operators Overloading

    /// + - * / %
    public static EncFloat operator +(EncFloat eint1, EncFloat eint2) => new EncFloat(eint1.Value + eint2.Value);
    public static EncFloat operator -(EncFloat eint1, EncFloat eint2) => new EncFloat(eint1.Value - eint2.Value);
    public static EncFloat operator *(EncFloat eint1, EncFloat eint2) => new EncFloat(eint1.Value * eint2.Value);
    public static EncFloat operator /(EncFloat eint1, EncFloat eint2) => new EncFloat(eint1.Value / eint2.Value);
    public static EncFloat operator %(EncFloat eint1, EncFloat eint2) => new EncFloat(eint1.Value % eint2.Value);

    public static float operator +(EncFloat efloat1, ulong efloat2) => efloat1.Value + efloat2;
    public static float operator -(EncFloat efloat1, ulong efloat2) => efloat1.Value - efloat2;
    public static float operator *(EncFloat efloat1, ulong efloat2) => efloat1.Value * efloat2;
    public static float operator /(EncFloat efloat1, ulong efloat2) => efloat1.Value / efloat2;
    public static float operator %(EncFloat efloat1, ulong efloat2) => efloat1.Value % efloat2;

    public static float operator +(EncFloat efloat1, long efloat2) => efloat1.Value + efloat2;
    public static float operator -(EncFloat efloat1, long efloat2) => efloat1.Value - efloat2;
    public static float operator *(EncFloat efloat1, long efloat2) => efloat1.Value * efloat2;
    public static float operator /(EncFloat efloat1, long efloat2) => efloat1.Value / efloat2;
    public static float operator %(EncFloat efloat1, long efloat2) => efloat1.Value % efloat2;

    public static float operator +(EncFloat efloat1, uint efloat2) => efloat1.Value + efloat2;
    public static float operator -(EncFloat efloat1, uint efloat2) => efloat1.Value - efloat2;
    public static float operator *(EncFloat efloat1, uint efloat2) => efloat1.Value * efloat2;
    public static float operator /(EncFloat efloat1, uint efloat2) => efloat1.Value / efloat2;
    public static float operator %(EncFloat efloat1, uint efloat2) => efloat1.Value % efloat2;

    public static float operator +(EncFloat efloat1, int efloat2) => efloat1.Value + efloat2;
    public static float operator -(EncFloat efloat1, int efloat2) => efloat1.Value - efloat2;
    public static float operator *(EncFloat efloat1, int efloat2) => efloat1.Value * efloat2;
    public static float operator /(EncFloat efloat1, int efloat2) => efloat1.Value / efloat2;
    public static float operator %(EncFloat efloat1, int efloat2) => efloat1.Value % efloat2;

    public static float operator +(EncFloat efloat1, ushort efloat2) => efloat1.Value + efloat2;
    public static float operator -(EncFloat efloat1, ushort efloat2) => efloat1.Value - efloat2;
    public static float operator *(EncFloat efloat1, ushort efloat2) => efloat1.Value * efloat2;
    public static float operator /(EncFloat efloat1, ushort efloat2) => efloat1.Value / efloat2;
    public static float operator %(EncFloat efloat1, ushort efloat2) => efloat1.Value % efloat2;

    public static float operator +(EncFloat efloat1, short efloat2) => efloat1.Value + efloat2;
    public static float operator -(EncFloat efloat1, short efloat2) => efloat1.Value - efloat2;
    public static float operator *(EncFloat efloat1, short efloat2) => efloat1.Value * efloat2;
    public static float operator /(EncFloat efloat1, short efloat2) => efloat1.Value / efloat2;
    public static float operator %(EncFloat efloat1, short efloat2) => efloat1.Value % efloat2;

    public static float operator +(EncFloat efloat1, byte efloat2) => efloat1.Value + efloat2;
    public static float operator -(EncFloat efloat1, byte efloat2) => efloat1.Value - efloat2;
    public static float operator *(EncFloat efloat1, byte efloat2) => efloat1.Value * efloat2;
    public static float operator /(EncFloat efloat1, byte efloat2) => efloat1.Value / efloat2;
    public static float operator %(EncFloat efloat1, byte efloat2) => efloat1.Value % efloat2;

    public static float operator +(EncFloat efloat1, sbyte efloat2) => efloat1.Value + efloat2;
    public static float operator -(EncFloat efloat1, sbyte efloat2) => efloat1.Value - efloat2;
    public static float operator *(EncFloat efloat1, sbyte efloat2) => efloat1.Value * efloat2;
    public static float operator /(EncFloat efloat1, sbyte efloat2) => efloat1.Value / efloat2;
    public static float operator %(EncFloat efloat1, sbyte efloat2) => efloat1.Value % efloat2;

    public static float operator +(EncFloat efloat1, float efloat2) => efloat1.Value + efloat2;
    public static float operator -(EncFloat efloat1, float efloat2) => efloat1.Value - efloat2;
    public static float operator *(EncFloat efloat1, float efloat2) => efloat1.Value * efloat2;
    public static float operator /(EncFloat efloat1, float efloat2) => efloat1.Value / efloat2;
    public static float operator %(EncFloat efloat1, float efloat2) => efloat1.Value % efloat2;

    /// == != < >

    public static bool operator ==(EncFloat eint1, EncFloat eint2) => eint1.Value == eint2.Value;
    public static bool operator !=(EncFloat eint1, EncFloat eint2) => eint1.Value != eint2.Value;
    public static bool operator <(EncFloat eint1, EncFloat eint2) => eint1.Value < eint2.Value;
    public static bool operator >(EncFloat eint1, EncFloat eint2) => eint1.Value > eint2.Value;

    public static bool operator ==(EncFloat eint1, ulong eint2) => eint1.Value == eint2;
    public static bool operator !=(EncFloat eint1, ulong eint2) => eint1.Value != eint2;
    public static bool operator >(EncFloat eint1, ulong eint2) => eint1.Value > eint2;
    public static bool operator <(EncFloat eint1, ulong eint2) => eint1.Value < eint2;

    public static bool operator ==(EncFloat eint1, long eint2) => eint1.Value == eint2;
    public static bool operator !=(EncFloat eint1, long eint2) => eint1.Value != eint2;
    public static bool operator >(EncFloat eint1, long eint2) => eint1.Value > eint2;
    public static bool operator <(EncFloat eint1, long eint2) => eint1.Value < eint2;

    public static bool operator ==(EncFloat eint1, uint eint2) => eint1.Value == eint2;
    public static bool operator !=(EncFloat eint1, uint eint2) => eint1.Value != eint2;
    public static bool operator >(EncFloat eint1, uint eint2) => eint1.Value > eint2;
    public static bool operator <(EncFloat eint1, uint eint2) => eint1.Value < eint2;

    public static bool operator ==(EncFloat eint1, int eint2) => eint1.Value == eint2;
    public static bool operator !=(EncFloat eint1, int eint2) => eint1.Value != eint2;
    public static bool operator >(EncFloat eint1, int eint2) => eint1.Value > eint2;
    public static bool operator <(EncFloat eint1, int eint2) => eint1.Value < eint2;

    public static bool operator ==(EncFloat eint1, ushort eint2) => eint1.Value == eint2;
    public static bool operator !=(EncFloat eint1, ushort eint2) => eint1.Value != eint2;
    public static bool operator >(EncFloat eint1, ushort eint2) => eint1.Value > eint2;
    public static bool operator <(EncFloat eint1, ushort eint2) => eint1.Value < eint2;

    public static bool operator ==(EncFloat eint1, short eint2) => eint1.Value == eint2;
    public static bool operator !=(EncFloat eint1, short eint2) => eint1.Value != eint2;
    public static bool operator >(EncFloat eint1, short eint2) => eint1.Value > eint2;
    public static bool operator <(EncFloat eint1, short eint2) => eint1.Value < eint2;

    public static bool operator ==(EncFloat eint1, byte eint2) => eint1.Value == eint2;
    public static bool operator !=(EncFloat eint1, byte eint2) => eint1.Value != eint2;
    public static bool operator >(EncFloat eint1, byte eint2) => eint1.Value > eint2;
    public static bool operator <(EncFloat eint1, byte eint2) => eint1.Value < eint2;

    public static bool operator ==(EncFloat eint1, sbyte eint2) => eint1.Value == eint2;
    public static bool operator !=(EncFloat eint1, sbyte eint2) => eint1.Value != eint2;
    public static bool operator >(EncFloat eint1, sbyte eint2) => eint1.Value > eint2;
    public static bool operator <(EncFloat eint1, sbyte eint2) => eint1.Value < eint2;

    public static bool operator ==(EncFloat eint1, decimal eint2) => (decimal)eint1.Value == eint2;
    public static bool operator !=(EncFloat eint1, decimal eint2) => (decimal)eint1.Value != eint2;
    public static bool operator >(EncFloat eint1, decimal eint2) => (decimal)eint1.Value > eint2;
    public static bool operator <(EncFloat eint1, decimal eint2) => (decimal)eint1.Value < eint2;

    public static bool operator ==(EncFloat eint1, double eint2) => eint1.Value == eint2;
    public static bool operator !=(EncFloat eint1, double eint2) => eint1.Value != eint2;
    public static bool operator >(EncFloat eint1, double eint2) => eint1.Value > eint2;
    public static bool operator <(EncFloat eint1, double eint2) => eint1.Value < eint2;

    public static bool operator ==(EncFloat eint1, float eint2) => eint1.Value == eint2;
    public static bool operator !=(EncFloat eint1, float eint2) => eint1.Value != eint2;
    public static bool operator >(EncFloat eint1, float eint2) => eint1.Value > eint2;
    public static bool operator <(EncFloat eint1, float eint2) => eint1.Value < eint2;

    /// assign
    public static implicit operator EncFloat(ulong value) => new EncFloat(value);
    public static implicit operator EncFloat(long value) => new EncFloat(value);
    public static implicit operator EncFloat(uint value) => new EncFloat(value);
    public static implicit operator EncFloat(int value) => new EncFloat(value);
    public static implicit operator EncFloat(ushort value) => new EncFloat(value);
    public static implicit operator EncFloat(short value) => new EncFloat(value);
    public static implicit operator EncFloat(byte value) => new EncFloat(value);
    public static implicit operator EncFloat(sbyte value) => new EncFloat(value);
    public static explicit operator EncFloat(decimal value) => new EncFloat((float)value);
    public static explicit operator EncFloat(double value) => new EncFloat((float)value);
    public static implicit operator EncFloat(float value) => new EncFloat(value);

    public static explicit operator decimal(EncFloat eint1) => (decimal)eint1.Value;
    public static implicit operator double(EncFloat eint1) => eint1.Value;
    public static implicit operator float(EncFloat eint1) => eint1.Value;
    public static explicit operator ulong(EncFloat eint1) => (ulong)eint1.Value;
    public static explicit operator long(EncFloat eint1) => (long)eint1.Value;
    public static explicit operator uint(EncFloat eint1) => (uint)eint1.Value;
    public static explicit operator int(EncFloat eint1) => (int)eint1.Value;
    public static explicit operator ushort(EncFloat eint1) => (ushort)eint1.Value;
    public static explicit operator short(EncFloat eint1) => (short)eint1.Value;
    public static explicit operator byte(EncFloat eint1) => (byte)eint1.Value;
    public static explicit operator sbyte(EncFloat eint1) => (sbyte)eint1.Value;

    #endregion
}