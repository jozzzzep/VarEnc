using System;

public struct EncDecimal
{
    /// A struct for storing a Decimal while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a different that is affected by random values. { encryptionKey1 & encryptionKey2 }
    /// Every time the value changes, the encryption keys change too. And it works exactly as an deciaml.
    ///
    /// WIKI & INFO: https://github.com/JosepeDev/VarEnc

    #region Variables And Properties

    // The encryption values
    private decimal encryptionKey1;
    private decimal encryptionKey2;

    // The encrypted value stored in memory
    private decimal encryptedValue;

    // The decrypted value
    public decimal Value
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

    public Decimal MaxValue { get => Decimal.MaxValue; }
    public Decimal MinValue { get => Decimal.MinValue; }
    public Decimal MinusOne { get => Decimal.MinusOne; }
    public Decimal One { get => Decimal.One; }
    public Decimal Zero { get => Decimal.Zero; }

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
    static private decimal GetEncryptionKey() => (decimal)(random.NextDouble());

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

    // Overrides
    public int CompareTo(Decimal value) => Value.CompareTo(value);
    public int CompareTo(object value) => Value.CompareTo(value);
    public bool Equals(Decimal value) => Value.Equals(value);
    public override bool Equals(object value) => Value.Equals(value);
    public override int GetHashCode() => Value.GetHashCode();
    public TypeCode GetTypeCode() => Value.GetTypeCode();
    public string ToString(string format) => Value.ToString(format);
    public string ToString(IFormatProvider provider) => Value.ToString(provider);
    public override string ToString() => Value.ToString();
    public string ToString(string format, IFormatProvider provider) => Value.ToString(format, provider);

    #endregion

    #region Operators Overloading

    /// + - * / %
     
    public static EncDecimal operator +(EncDecimal eint1, EncDecimal eint2) => EncDecimal.NewEncDecimal(eint1.Value + eint2.Value);
    public static EncDecimal operator -(EncDecimal eint1, EncDecimal eint2) => EncDecimal.NewEncDecimal(eint1.Value - eint2.Value);
    public static EncDecimal operator *(EncDecimal eint1, EncDecimal eint2) => EncDecimal.NewEncDecimal(eint1.Value * eint2.Value);
    public static EncDecimal operator /(EncDecimal eint1, EncDecimal eint2) => EncDecimal.NewEncDecimal(eint1.Value / eint2.Value);
    public static EncDecimal operator %(EncDecimal eint1, EncDecimal eint2) => EncDecimal.NewEncDecimal(eint1.Value % eint2.Value);

    public static decimal operator +(EncDecimal edecimal1, ulong edecimal2) => edecimal1.Value + edecimal2;
    public static decimal operator -(EncDecimal edecimal1, ulong edecimal2) => edecimal1.Value - edecimal2;
    public static decimal operator *(EncDecimal edecimal1, ulong edecimal2) => edecimal1.Value * edecimal2;
    public static decimal operator /(EncDecimal edecimal1, ulong edecimal2) => edecimal1.Value / edecimal2;
    public static decimal operator %(EncDecimal edecimal1, ulong edecimal2) => edecimal1.Value % edecimal2;

    public static decimal operator +(EncDecimal edecimal1, long edecimal2) => edecimal1.Value + edecimal2;
    public static decimal operator -(EncDecimal edecimal1, long edecimal2) => edecimal1.Value - edecimal2;
    public static decimal operator *(EncDecimal edecimal1, long edecimal2) => edecimal1.Value * edecimal2;
    public static decimal operator /(EncDecimal edecimal1, long edecimal2) => edecimal1.Value / edecimal2;
    public static decimal operator %(EncDecimal edecimal1, long edecimal2) => edecimal1.Value % edecimal2;

    public static decimal operator +(EncDecimal edecimal1, uint edecimal2) => edecimal1.Value + edecimal2;
    public static decimal operator -(EncDecimal edecimal1, uint edecimal2) => edecimal1.Value - edecimal2;
    public static decimal operator *(EncDecimal edecimal1, uint edecimal2) => edecimal1.Value * edecimal2;
    public static decimal operator /(EncDecimal edecimal1, uint edecimal2) => edecimal1.Value / edecimal2;
    public static decimal operator %(EncDecimal edecimal1, uint edecimal2) => edecimal1.Value % edecimal2;

    public static decimal operator +(EncDecimal edecimal1, int edecimal2) => edecimal1.Value + edecimal2;
    public static decimal operator -(EncDecimal edecimal1, int edecimal2) => edecimal1.Value - edecimal2;
    public static decimal operator *(EncDecimal edecimal1, int edecimal2) => edecimal1.Value * edecimal2;
    public static decimal operator /(EncDecimal edecimal1, int edecimal2) => edecimal1.Value / edecimal2;
    public static decimal operator %(EncDecimal edecimal1, int edecimal2) => edecimal1.Value % edecimal2;

    public static decimal operator +(EncDecimal edecimal1, ushort edecimal2) => edecimal1.Value + edecimal2;
    public static decimal operator -(EncDecimal edecimal1, ushort edecimal2) => edecimal1.Value - edecimal2;
    public static decimal operator *(EncDecimal edecimal1, ushort edecimal2) => edecimal1.Value * edecimal2;
    public static decimal operator /(EncDecimal edecimal1, ushort edecimal2) => edecimal1.Value / edecimal2;
    public static decimal operator %(EncDecimal edecimal1, ushort edecimal2) => edecimal1.Value % edecimal2;

    public static decimal operator +(EncDecimal edecimal1, short edecimal2) => edecimal1.Value + edecimal2;
    public static decimal operator -(EncDecimal edecimal1, short edecimal2) => edecimal1.Value - edecimal2;
    public static decimal operator *(EncDecimal edecimal1, short edecimal2) => edecimal1.Value * edecimal2;
    public static decimal operator /(EncDecimal edecimal1, short edecimal2) => edecimal1.Value / edecimal2;
    public static decimal operator %(EncDecimal edecimal1, short edecimal2) => edecimal1.Value % edecimal2;

    public static decimal operator +(EncDecimal edecimal1, byte edecimal2) => edecimal1.Value + edecimal2;
    public static decimal operator -(EncDecimal edecimal1, byte edecimal2) => edecimal1.Value - edecimal2;
    public static decimal operator *(EncDecimal edecimal1, byte edecimal2) => edecimal1.Value * edecimal2;
    public static decimal operator /(EncDecimal edecimal1, byte edecimal2) => edecimal1.Value / edecimal2;
    public static decimal operator %(EncDecimal edecimal1, byte edecimal2) => edecimal1.Value % edecimal2;

    public static decimal operator +(EncDecimal edecimal1, sbyte edecimal2) => edecimal1.Value + edecimal2;
    public static decimal operator -(EncDecimal edecimal1, sbyte edecimal2) => edecimal1.Value - edecimal2;
    public static decimal operator *(EncDecimal edecimal1, sbyte edecimal2) => edecimal1.Value * edecimal2;
    public static decimal operator /(EncDecimal edecimal1, sbyte edecimal2) => edecimal1.Value / edecimal2;
    public static decimal operator %(EncDecimal edecimal1, sbyte edecimal2) => edecimal1.Value % edecimal2;

    public static decimal operator +(EncDecimal edecimal1, decimal edecimal2) => edecimal1.Value + edecimal2;
    public static decimal operator -(EncDecimal edecimal1, decimal edecimal2) => edecimal1.Value - edecimal2;
    public static decimal operator *(EncDecimal edecimal1, decimal edecimal2) => edecimal1.Value * edecimal2;
    public static decimal operator /(EncDecimal edecimal1, decimal edecimal2) => edecimal1.Value / edecimal2;
    public static decimal operator %(EncDecimal edecimal1, decimal edecimal2) => edecimal1.Value % edecimal2;

    public static decimal operator +(EncDecimal edecimal1, double edecimal2) => edecimal1.Value + (decimal)edecimal2;
    public static decimal operator -(EncDecimal edecimal1, double edecimal2) => edecimal1.Value - (decimal)edecimal2;
    public static decimal operator *(EncDecimal edecimal1, double edecimal2) => edecimal1.Value * (decimal)edecimal2;
    public static decimal operator /(EncDecimal edecimal1, double edecimal2) => edecimal1.Value / (decimal)edecimal2;
    public static decimal operator %(EncDecimal edecimal1, double edecimal2) => edecimal1.Value % (decimal)edecimal2;

    public static decimal operator +(EncDecimal edecimal1, float edecimal2) => edecimal1.Value + (decimal)edecimal2;
    public static decimal operator -(EncDecimal edecimal1, float edecimal2) => edecimal1.Value - (decimal)edecimal2;
    public static decimal operator *(EncDecimal edecimal1, float edecimal2) => edecimal1.Value * (decimal)edecimal2;
    public static decimal operator /(EncDecimal edecimal1, float edecimal2) => edecimal1.Value / (decimal)edecimal2;
    public static decimal operator %(EncDecimal edecimal1, float edecimal2) => edecimal1.Value % (decimal)edecimal2;

    /// == != < >

    public static bool operator ==(EncDecimal eint1, EncDecimal eint2) => eint1.Value == eint2.Value;
    public static bool operator !=(EncDecimal eint1, EncDecimal eint2) => eint1.Value != eint2.Value;
    public static bool operator <(EncDecimal eint1, EncDecimal eint2) => eint1.Value < eint2.Value;
    public static bool operator >(EncDecimal eint1, EncDecimal eint2) => eint1.Value > eint2.Value;

    public static bool operator ==(EncDecimal eint1, ulong eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDecimal eint1, ulong eint2) => eint1.Value != eint2;
    public static bool operator >(EncDecimal eint1, ulong eint2) => eint1.Value > eint2;
    public static bool operator <(EncDecimal eint1, ulong eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDecimal eint1, long eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDecimal eint1, long eint2) => eint1.Value != eint2;
    public static bool operator >(EncDecimal eint1, long eint2) => eint1.Value > eint2;
    public static bool operator <(EncDecimal eint1, long eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDecimal eint1, uint eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDecimal eint1, uint eint2) => eint1.Value != eint2;
    public static bool operator >(EncDecimal eint1, uint eint2) => eint1.Value > eint2;
    public static bool operator <(EncDecimal eint1, uint eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDecimal eint1, int eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDecimal eint1, int eint2) => eint1.Value != eint2;
    public static bool operator >(EncDecimal eint1, int eint2) => eint1.Value > eint2;
    public static bool operator <(EncDecimal eint1, int eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDecimal eint1, ushort eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDecimal eint1, ushort eint2) => eint1.Value != eint2;
    public static bool operator >(EncDecimal eint1, ushort eint2) => eint1.Value > eint2;
    public static bool operator <(EncDecimal eint1, ushort eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDecimal eint1, short eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDecimal eint1, short eint2) => eint1.Value != eint2;
    public static bool operator >(EncDecimal eint1, short eint2) => eint1.Value > eint2;
    public static bool operator <(EncDecimal eint1, short eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDecimal eint1, byte eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDecimal eint1, byte eint2) => eint1.Value != eint2;
    public static bool operator >(EncDecimal eint1, byte eint2) => eint1.Value > eint2;
    public static bool operator <(EncDecimal eint1, byte eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDecimal eint1, sbyte eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDecimal eint1, sbyte eint2) => eint1.Value != eint2;
    public static bool operator >(EncDecimal eint1, sbyte eint2) => eint1.Value > eint2;
    public static bool operator <(EncDecimal eint1, sbyte eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDecimal eint1, decimal eint2) => eint1.Value == eint2;
    public static bool operator !=(EncDecimal eint1, decimal eint2) => eint1.Value != eint2;
    public static bool operator >(EncDecimal eint1, decimal eint2) => eint1.Value > eint2;
    public static bool operator <(EncDecimal eint1, decimal eint2) => eint1.Value < eint2;

    public static bool operator ==(EncDecimal eint1, double eint2) => eint1.Value == (decimal)eint2;
    public static bool operator !=(EncDecimal eint1, double eint2) => eint1.Value != (decimal)eint2;
    public static bool operator >(EncDecimal eint1, double eint2) => eint1.Value > (decimal)eint2;
    public static bool operator <(EncDecimal eint1, double eint2) => eint1.Value < (decimal)eint2;

    public static bool operator ==(EncDecimal eint1, float eint2) => eint1.Value == (decimal)eint2;
    public static bool operator !=(EncDecimal eint1, float eint2) => eint1.Value != (decimal)eint2;
    public static bool operator >(EncDecimal eint1, float eint2) => eint1.Value > (decimal)eint2;
    public static bool operator <(EncDecimal eint1, float eint2) => eint1.Value < (decimal)eint2;

    /// assign
    
    public static implicit operator EncDecimal(decimal value) => EncDecimal.NewEncDecimal(value);
    public static implicit operator decimal(EncDecimal eint1) => eint1.Value;
    public static explicit operator double(EncDecimal eint1) => (double)eint1.Value;
    public static explicit operator float(EncDecimal eint1) => (float)eint1.Value;
    public static explicit operator ulong(EncDecimal eint1) => (ulong)eint1.Value;
    public static explicit operator long(EncDecimal eint1) => (long)eint1.Value;
    public static explicit operator uint(EncDecimal eint1) => (uint)eint1.Value;
    public static explicit operator int(EncDecimal eint1) => (int)eint1.Value;
    public static explicit operator ushort(EncDecimal eint1) => (ushort)eint1.Value;
    public static explicit operator short(EncDecimal eint1) => (short)eint1.Value;
    public static explicit operator byte(EncDecimal eint1) => (byte)eint1.Value;
    public static explicit operator sbyte(EncDecimal eint1) => (sbyte)eint1.Value;

    #endregion
}