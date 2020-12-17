using System;

public struct EncInt
{
    /// A struct for storing a 32-bit integer while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a floating-point number that is affected by random values. { encryptionKey1 & encryptionKey2 }
    /// Every time the value changes, the encryption keys change too. And it works exactly as an int.
    ///
    /// WIKI & INFO: https://github.com/JosepeDev/VarEnc

    #region Variables - Properties - Methods - Constructors

    // The encryption values
    private readonly double encryptionKey1;
    private readonly double encryptionKey2;

    // The encrypted value stored in memory
    private readonly double encryptedValue;

    // The decrypted value
    private int Value
    {
        get => (int)Decrypt();
    }

    public static int MaxValue { get => Int32.MaxValue; }
    public static int MinValue { get => Int32.MinValue; }

    private EncInt(double value)
    {
        encryptionKey1 = random.NextDouble() * 0.001;
        encryptionKey2 = random.NextDouble() * 100;
        encryptedValue = Encrypt(value, encryptionKey1, encryptionKey2);
    }

    // Encryption Key Generator
    static private Random random = new Random();

    // Takes a given value and returns it encrypted
    private static double Encrypt(double value, double k1, double k2) => (value * k1) * k2;

    // Takes an encrypted value and returns it decrypted
    private double Decrypt() => ((encryptedValue / encryptionKey2) / encryptionKey1) + 0.5;

    // Int32 methods
    public Int32 CompareTo(object value) => Value.CompareTo(value);
    public Int32 CompareTo(Int32 value) => Value.CompareTo(value);
    public bool Equals(Int32 obj) => Value.Equals(obj);
    public override bool Equals(object obj) => Value.Equals(obj);
    public override Int32 GetHashCode() => Value.GetHashCode();
    public TypeCode GetTypeCode() => Value.GetTypeCode();
    public override string ToString() => Value.ToString();
    public string ToString(IFormatProvider provider) => Value.ToString(provider);
    public string ToString(string format) => Value.ToString(format);
    public string ToString(string format, IFormatProvider provider) => Value.ToString(format, provider);

    #endregion

    #region Operators Overloading

    /// & | ^ << >>
    public static EncInt operator &(EncInt eint1, EncInt eint2) => new EncInt(eint1.Value & eint2.Value);
    public static EncInt operator |(EncInt eint1, EncInt eint2) => new EncInt(eint1.Value | eint2.Value);
    public static EncInt operator ^(EncInt eint1, EncInt eint2) => new EncInt(eint1.Value ^ eint2.Value);

    public static int operator &(EncInt eint1, int eint2) => eint1.Value & eint2;
    public static int operator |(EncInt eint1, int eint2) => eint1.Value | eint2;
    public static int operator ^(EncInt eint1, int eint2) => eint1.Value ^ eint2;
    public static int operator >>(EncInt eint1, int eint2) => eint1.Value >> eint2;
    public static int operator <<(EncInt eint1, int eint2) => eint1.Value << eint2;

    /// + - * / %
    public static EncInt operator +(EncInt eint1, EncInt eint2) => new EncInt(eint1.Value + eint2.Value);
    public static EncInt operator -(EncInt eint1, EncInt eint2) => new EncInt(eint1.Value - eint2.Value);
    public static EncInt operator *(EncInt eint1, EncInt eint2) => new EncInt(eint1.Value * eint2.Value);
    public static EncInt operator /(EncInt eint1, EncInt eint2) => new EncInt(eint1.Value / eint2.Value);
    public static EncInt operator %(EncInt eint1, EncInt eint2) => new EncInt(eint1.Value % eint2.Value);

    public static int operator +(EncInt eint1, int eint2) => eint1.Value + eint2;
    public static int operator -(EncInt eint1, int eint2) => eint1.Value - eint2;
    public static int operator *(EncInt eint1, int eint2) => eint1.Value * eint2;
    public static int operator /(EncInt eint1, int eint2) => eint1.Value / eint2;
    public static int operator %(EncInt eint1, int eint2) => eint1.Value % eint2;

    public static int operator +(EncInt eint1, ushort eint2) => eint1.Value + eint2;
    public static int operator -(EncInt eint1, ushort eint2) => eint1.Value - eint2;
    public static int operator *(EncInt eint1, ushort eint2) => eint1.Value * eint2;
    public static int operator /(EncInt eint1, ushort eint2) => eint1.Value / eint2;
    public static int operator %(EncInt eint1, ushort eint2) => eint1.Value % eint2;

    public static int operator +(EncInt eint1, short eint2) => eint1.Value + eint2;
    public static int operator -(EncInt eint1, short eint2) => eint1.Value - eint2;
    public static int operator *(EncInt eint1, short eint2) => eint1.Value * eint2;
    public static int operator /(EncInt eint1, short eint2) => eint1.Value / eint2;
    public static int operator %(EncInt eint1, short eint2) => eint1.Value % eint2;

    public static int operator +(EncInt eint1, byte eint2) => eint1.Value + eint2;
    public static int operator -(EncInt eint1, byte eint2) => eint1.Value - eint2;
    public static int operator *(EncInt eint1, byte eint2) => eint1.Value * eint2;
    public static int operator /(EncInt eint1, byte eint2) => eint1.Value / eint2;
    public static int operator %(EncInt eint1, byte eint2) => eint1.Value % eint2;

    public static int operator +(EncInt eint1, sbyte eint2) => eint1.Value + eint2;
    public static int operator -(EncInt eint1, sbyte eint2) => eint1.Value - eint2;
    public static int operator *(EncInt eint1, sbyte eint2) => eint1.Value * eint2;
    public static int operator /(EncInt eint1, sbyte eint2) => eint1.Value / eint2;
    public static int operator %(EncInt eint1, sbyte eint2) => eint1.Value % eint2;

    /// == != < >
    public static bool operator ==(EncInt eint1, EncInt eint2) => eint1.Value == eint2.Value;
    public static bool operator !=(EncInt eint1, EncInt eint2) => eint1.Value != eint2.Value;
    public static bool operator <(EncInt eint1, EncInt eint2) => eint1.Value < eint2.Value;
    public static bool operator >(EncInt eint1, EncInt eint2) => eint1.Value > eint2.Value;

    public static bool operator ==(EncInt eint1, ulong eint2) => (ulong)eint1.Value == eint2;
    public static bool operator !=(EncInt eint1, ulong eint2) => (ulong)eint1.Value != eint2;
    public static bool operator >(EncInt eint1, ulong eint2) => (ulong)eint1.Value > eint2;
    public static bool operator <(EncInt eint1, ulong eint2) => (ulong)eint1.Value < eint2;

    public static bool operator ==(EncInt eint1, long eint2) => eint1.Value == eint2;
    public static bool operator !=(EncInt eint1, long eint2) => eint1.Value != eint2;
    public static bool operator >(EncInt eint1, long eint2) => eint1.Value > eint2;
    public static bool operator <(EncInt eint1, long eint2) => eint1.Value < eint2;

    public static bool operator ==(EncInt eint1, uint eint2) => (uint)eint1.Value == eint2;
    public static bool operator !=(EncInt eint1, uint eint2) => (uint)eint1.Value != eint2;
    public static bool operator >(EncInt eint1, uint eint2) => (uint)eint1.Value > eint2;
    public static bool operator <(EncInt eint1, uint eint2) => (uint)eint1.Value < eint2;

    public static bool operator ==(EncInt eint1, int eint2) => eint1.Value == eint2;
    public static bool operator !=(EncInt eint1, int eint2) => eint1.Value != eint2;
    public static bool operator >(EncInt eint1, int eint2) => eint1.Value > eint2;
    public static bool operator <(EncInt eint1, int eint2) => eint1.Value < eint2;

    public static bool operator ==(EncInt eint1, ushort eint2) => (ushort)eint1.Value == eint2;
    public static bool operator !=(EncInt eint1, ushort eint2) => (ushort)eint1.Value != eint2;
    public static bool operator >(EncInt eint1, ushort eint2) => (ushort)eint1.Value > eint2;
    public static bool operator <(EncInt eint1, ushort eint2) => (ushort)eint1.Value < eint2;

    public static bool operator ==(EncInt eint1, short eint2) => (short)eint1.Value == eint2;
    public static bool operator !=(EncInt eint1, short eint2) => (short)eint1.Value != eint2;
    public static bool operator >(EncInt eint1, short eint2) => (short)eint1.Value > eint2;
    public static bool operator <(EncInt eint1, short eint2) => (short)eint1.Value < eint2;

    public static bool operator ==(EncInt eint1, byte eint2) => (byte)eint1.Value == eint2;
    public static bool operator !=(EncInt eint1, byte eint2) => (byte)eint1.Value != eint2;
    public static bool operator >(EncInt eint1, byte eint2) => (byte)eint1.Value > eint2;
    public static bool operator <(EncInt eint1, byte eint2) => (byte)eint1.Value < eint2;

    public static bool operator ==(EncInt eint1, sbyte eint2) => (sbyte)eint1.Value == eint2;
    public static bool operator !=(EncInt eint1, sbyte eint2) => (sbyte)eint1.Value != eint2;
    public static bool operator >(EncInt eint1, sbyte eint2) => (sbyte)eint1.Value > eint2;
    public static bool operator <(EncInt eint1, sbyte eint2) => (sbyte)eint1.Value < eint2;

    public static bool operator ==(EncInt eint1, decimal eint2) => eint1.Value == eint2;
    public static bool operator !=(EncInt eint1, decimal eint2) => eint1.Value != eint2;
    public static bool operator >(EncInt eint1, decimal eint2) => eint1.Value > eint2;
    public static bool operator <(EncInt eint1, decimal eint2) => eint1.Value < eint2;

    public static bool operator ==(EncInt eint1, double eint2) => eint1.Value == eint2;
    public static bool operator !=(EncInt eint1, double eint2) => eint1.Value != eint2;
    public static bool operator >(EncInt eint1, double eint2) => eint1.Value > eint2;
    public static bool operator <(EncInt eint1, double eint2) => eint1.Value < eint2;

    public static bool operator ==(EncInt eint1, float eint2) => eint1.Value == eint2;
    public static bool operator !=(EncInt eint1, float eint2) => eint1.Value != eint2;
    public static bool operator >(EncInt eint1, float eint2) => eint1.Value > eint2;
    public static bool operator <(EncInt eint1, float eint2) => eint1.Value < eint2;

    /// assign
    public static implicit operator EncInt(int value) => new EncInt(value);
    public static explicit operator ulong(EncInt eint1) => (ulong)eint1.Value;
    public static implicit operator long(EncInt eint1) => eint1.Value;
    public static explicit operator uint(EncInt eint1) => (uint)eint1.Value;
    public static implicit operator int(EncInt eint1) => eint1.Value;
    public static explicit operator ushort(EncInt eint1) => (ushort)eint1.Value;
    public static explicit operator short(EncInt eint1) => (short)eint1.Value;
    public static explicit operator byte(EncInt eint1) => (byte)eint1.Value;
    public static explicit operator sbyte(EncInt eint1) => (sbyte)eint1.Value;
    public static implicit operator decimal(EncInt eint1) => eint1.Value;
    public static implicit operator double(EncInt eint1) => eint1.Value;
    public static implicit operator float(EncInt eint1) => eint1.Value;

    #endregion
}