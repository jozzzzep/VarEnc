using System;

public struct EncInt
{
    /// A struct for storing a 32-bit integer while efficiently keeping it encrypted in the memory
    /// Instead of encrypting and decrypting yourself, you can just use the encrypted type (EncType) of the variable you want to be encrypted
    /// The encryption will happen in the background without you worrying about it
    /// In the memory it is saved as a weird floating-point number that is affected by random values { encryptionKey1 & encryptionKey2 }
    /// Every time the value changes, the encryption keys change too. And it works exactly as an int (Int32)
    ///
    /// WIKI & INFO: https://github.com/JosepeDev/VarEnc

    #region Variables And Properties

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

    #endregion

    #region Methods And Constructors

    private EncInt(int value)
    {
        encryptionKey1 = random.NextDouble() * 0.01;
        encryptionKey2 = random.NextDouble() * 10;
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
    public static explicit operator EncInt(ulong value) => new EncInt((int)value);
    public static explicit operator EncInt(long value) => new EncInt((int)value);
    public static explicit operator EncInt(uint value) => new EncInt((int)value);
    public static implicit operator EncInt(int value) => new EncInt(value);
    public static implicit operator EncInt(ushort value) => new EncInt(value);
    public static implicit operator EncInt(short value) => new EncInt(value);
    public static implicit operator EncInt(byte value) => new EncInt(value);
    public static implicit operator EncInt(sbyte value) => new EncInt(value);
    public static explicit operator EncInt(decimal value) => new EncInt((int)value);
    public static explicit operator EncInt(double value) => new EncInt((int)value);
    public static explicit operator EncInt(float value) => new EncInt((int)value);

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