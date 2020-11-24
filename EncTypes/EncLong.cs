using System;

public struct EncLong
{
    /// A struct for storing a 64-bit integer while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a floating-point number that is affected by random values. { encryptionKey1 & encryptionKey2 }
    /// Every time the value changes, the encryption keys change too. And it works exactly as an long.
    ///
    /// WIKI & INFO: https://github.com/JosepeDev/VarEnc

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
            return Math.Round(Decrypt(encryptedValue));
        }
    }

    public long MaxValue { get => Int64.MaxValue; }
    public long MinValue { get => Int64.MinValue; }

    #endregion

    #region Methods

    private static EncLong NewEncLong(long value)
    {
        EncLong theEncLong = new EncLong
        {
            encryptionKey1 = GetEncryptionKey(),
            encryptionKey2 = GetEncryptionKey(),
            Value = value
        };
        return theEncLong;
    }

    // Encryption Key Generator
    static private Random random = new Random();
    static private decimal GetEncryptionKey() => (decimal)(random.NextDouble() * 10);

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

    // Int64 methods
    public int CompareTo(object value) => ((long)Value).CompareTo(value);
    public int CompareTo(long value) => ((long)Value).CompareTo(value);
    public bool Equals(long obj) => ((long)Value).Equals(obj);
    public override bool Equals(object obj) => ((long)Value).Equals(obj);
    public override int GetHashCode() => ((long)Value).GetHashCode();
    public TypeCode GetTypeCode() => ((long)Value).GetTypeCode();
    public override string ToString() => ((long)Value).ToString();
    public string ToString(IFormatProvider provider) => ((long)Value).ToString(provider);
    public string ToString(string format) => ((long)Value).ToString(format);
    public string ToString(string format, IFormatProvider provider) => ((long)Value).ToString(format, provider);

    #endregion

    #region Operators Overloading

    /// + - * / %
    public static EncLong operator +(EncLong elong1, EncLong elong2) => EncLong.NewEncLong((long)(elong1.Value + elong2.Value));
    public static EncLong operator -(EncLong elong1, EncLong elong2) => EncLong.NewEncLong((long)(elong1.Value - elong2.Value));
    public static EncLong operator *(EncLong elong1, EncLong elong2) => EncLong.NewEncLong((long)(elong1.Value * elong2.Value));
    public static EncLong operator /(EncLong elong1, EncLong elong2) => EncLong.NewEncLong((long)(elong1.Value / elong2.Value));
    public static EncLong operator %(EncLong elong1, EncLong elong2) => EncLong.NewEncLong((long)(elong1.Value % elong2.Value));

    public static long operator +(EncLong elong1, long elong2) => (long)elong1.Value + elong2;
    public static long operator -(EncLong elong1, long elong2) => (long)elong1.Value - elong2;
    public static long operator *(EncLong elong1, long elong2) => (long)elong1.Value * elong2;
    public static long operator /(EncLong elong1, long elong2) => (long)elong1.Value / elong2;
    public static long operator %(EncLong elong1, long elong2) => (long)elong1.Value % elong2;

    public static long operator +(EncLong elong1, int elong2) => (long)elong1.Value + elong2;
    public static long operator -(EncLong elong1, int elong2) => (long)elong1.Value - elong2;
    public static long operator *(EncLong elong1, int elong2) => (long)elong1.Value * elong2;
    public static long operator /(EncLong elong1, int elong2) => (long)elong1.Value / elong2;
    public static long operator %(EncLong elong1, int elong2) => (long)elong1.Value % elong2;

    public static long operator +(EncLong elong1, short elong2) => (long)elong1.Value + elong2;
    public static long operator -(EncLong elong1, short elong2) => (long)elong1.Value - elong2;
    public static long operator *(EncLong elong1, short elong2) => (long)elong1.Value * elong2;
    public static long operator /(EncLong elong1, short elong2) => (long)elong1.Value / elong2;
    public static long operator %(EncLong elong1, short elong2) => (long)elong1.Value % elong2;

    public static long operator +(EncLong elong1, ushort elong2) => (long)elong1.Value + elong2;
    public static long operator -(EncLong elong1, ushort elong2) => (long)elong1.Value - elong2;
    public static long operator *(EncLong elong1, ushort elong2) => (long)elong1.Value * elong2;
    public static long operator /(EncLong elong1, ushort elong2) => (long)elong1.Value / elong2;
    public static long operator %(EncLong elong1, ushort elong2) => (long)elong1.Value % elong2;

    public static long operator +(EncLong elong1, uint elong2) => (long)elong1.Value + elong2;
    public static long operator -(EncLong elong1, uint elong2) => (long)elong1.Value - elong2;
    public static long operator *(EncLong elong1, uint elong2) => (long)elong1.Value * elong2;
    public static long operator /(EncLong elong1, uint elong2) => (long)elong1.Value / elong2;
    public static long operator %(EncLong elong1, uint elong2) => (long)elong1.Value % elong2;

    public static long operator +(EncLong elong1, byte elong2) => (long)elong1.Value + elong2;
    public static long operator -(EncLong elong1, byte elong2) => (long)elong1.Value - elong2;
    public static long operator *(EncLong elong1, byte elong2) => (long)elong1.Value * elong2;
    public static long operator /(EncLong elong1, byte elong2) => (long)elong1.Value / elong2;
    public static long operator %(EncLong elong1, byte elong2) => (long)elong1.Value % elong2;

    public static long operator +(EncLong elong1, sbyte elong2) => (long)elong1.Value + elong2;
    public static long operator -(EncLong elong1, sbyte elong2) => (long)elong1.Value - elong2;
    public static long operator *(EncLong elong1, sbyte elong2) => (long)elong1.Value * elong2;
    public static long operator /(EncLong elong1, sbyte elong2) => (long)elong1.Value / elong2;
    public static long operator %(EncLong elong1, sbyte elong2) => (long)elong1.Value % elong2;

    /// == != < >
    /// 

    public static bool operator ==(EncLong elong1, byte elong2) => (long)elong1.Value == elong2;
    public static bool operator !=(EncLong elong1, byte elong2) => (long)elong1.Value != elong2;
    public static bool operator >(EncLong elong1, byte elong2) => (long)elong1.Value > elong2;
    public static bool operator <(EncLong elong1, byte elong2) => (long)elong1.Value < elong2;

    public static bool operator ==(EncLong elong1, sbyte elong2) => (long)elong1.Value == elong2;
    public static bool operator !=(EncLong elong1, sbyte elong2) => (long)elong1.Value != elong2;
    public static bool operator >(EncLong elong1, sbyte elong2) => (long)elong1.Value > elong2;
    public static bool operator <(EncLong elong1, sbyte elong2) => (long)elong1.Value < elong2;

    public static bool operator ==(EncLong elong1, short elong2) => (long)elong1.Value == elong2;
    public static bool operator !=(EncLong elong1, short elong2) => (long)elong1.Value != elong2;
    public static bool operator >(EncLong elong1, short elong2) => (long)elong1.Value > elong2;
    public static bool operator <(EncLong elong1, short elong2) => (long)elong1.Value < elong2;

    public static bool operator ==(EncLong elong1, ushort elong2) => (long)elong1.Value == elong2;
    public static bool operator !=(EncLong elong1, ushort elong2) => (long)elong1.Value != elong2;
    public static bool operator >(EncLong elong1, ushort elong2) => (long)elong1.Value > elong2;
    public static bool operator <(EncLong elong1, ushort elong2) => (long)elong1.Value < elong2;

    public static bool operator ==(EncLong elong1, uint elong2) => (long)elong1.Value == elong2;
    public static bool operator !=(EncLong elong1, uint elong2) => (long)elong1.Value != elong2;
    public static bool operator >(EncLong elong1, uint elong2) => (long)elong1.Value > elong2;
    public static bool operator <(EncLong elong1, uint elong2) => (long)elong1.Value < elong2;

    public static bool operator ==(EncLong elong1, int elong2) => (long)elong1.Value == elong2;
    public static bool operator !=(EncLong elong1, int elong2) => (long)elong1.Value != elong2;
    public static bool operator >(EncLong elong1, int elong2) => (long)elong1.Value > elong2;
    public static bool operator <(EncLong elong1, int elong2) => (long)elong1.Value < elong2;

    public static bool operator ==(EncLong elong1, long elong2) => (long)elong1.Value == elong2;
    public static bool operator !=(EncLong elong1, long elong2) => (long)elong1.Value != elong2;
    public static bool operator >(EncLong elong1, long elong2) => (long)elong1.Value > elong2;
    public static bool operator <(EncLong elong1, long elong2) => (long)elong1.Value < elong2;

    public static bool operator ==(EncLong elong1, EncLong elong2) => (long)elong1.Value == (long)elong2.Value;
    public static bool operator !=(EncLong elong1, EncLong elong2) => (long)elong1.Value != (long)elong2.Value;
    public static bool operator <(EncLong elong1, EncLong elong2) => (long)elong1.Value < (long)elong2.Value;
    public static bool operator >(EncLong elong1, EncLong elong2) => (long)elong1.Value > (long)elong2.Value;

    /// assign
    public static implicit operator EncLong(long value) => EncLong.NewEncLong(value);
    public static implicit operator long(EncLong elong1) => (long)elong1.Value;
    public static explicit operator ulong(EncLong elong1) => (ulong)elong1.Value;
    public static explicit operator uint(EncLong elong1) => (uint)elong1.Value;
    public static explicit operator int(EncLong elong1) => (int)elong1.Value;
    public static explicit operator ushort(EncLong elong1) => (ushort)elong1.Value;
    public static explicit operator short(EncLong elong1) => (short)elong1.Value;
    public static explicit operator sbyte(EncLong elong1) => (sbyte)elong1.Value;
    public static explicit operator byte(EncLong elong1) => (byte)elong1.Value;
    public static explicit operator decimal(EncLong elong1) => elong1.Value;
    public static explicit operator double(EncLong elong1) => (double)elong1.Value;
    public static explicit operator float(EncLong elong1) => (float)elong1.Value;

    #endregion
}