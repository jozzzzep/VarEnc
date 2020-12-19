﻿using System;

public struct EncDecimal
{
    /// A struct for storing a Decimal while efficiently keeping it encrypted in the memory.
    /// Instead of encrypting and decrypting yourself, you can just use the encrypted type (EncType) of the variable you want to be encrypted
    /// The encryption will happen in the background without you worrying about it
    /// In the memory it is saved as a an array of weird bytes that are affected by random values { encryptionKeys array }
    /// Every time the value changes, the encryption keys change too. And it works exactly as a deciaml.
    ///
    /// WIKI & INFO: https://github.com/JosepeDev/VarEnc

    #region Variables And Properties

    private readonly int[] encryptionKeys;

    // The encrypted value stored in memory
    private readonly int[] encryptedValue;

    // The decrypted value
    private decimal Value
    {
        get => Decrypt();
    }

    public static Decimal MaxValue { get => Decimal.MaxValue; }
    public static Decimal MinValue { get => Decimal.MinValue; }
    public static Decimal MinusOne { get => Decimal.MinusOne; }
    public static Decimal One { get => Decimal.One; }
    public static Decimal Zero { get => Decimal.Zero; }

    #endregion

    #region Methods And Constructors

    private EncDecimal(decimal value)
    {
        encryptionKeys = EncKeys();
        encryptedValue = Encrypt(value, encryptionKeys);
    }

    // Encryption key generator
    static private Random random = new Random();

    private static int[] EncKeys()
    {
        var arr = new int[4];
        for (int i = 0; i < 4; i++)
        {
            arr[i] = random.Next();
        }
        return arr;
    }

    // Takes a given value and returns it encrypted
    private static int[] Encrypt(decimal value, int[] keys)
    {
        var valueInBits = decimal.GetBits(value);
        for (int i = 0; i < 4; i++)
        {
            valueInBits[i] ^= keys[i];
        }
        return valueInBits;
    }

    // Takes an encrypted value and returns it decrypted
    private decimal Decrypt()
    {
        var decrypted = new int[4];
        for (int i = 0; i < 4; i++)
        {
            decrypted[i] = encryptedValue[i] ^ encryptionKeys[i];
        }
        return new decimal(decrypted);
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
     
    public static EncDecimal operator +(EncDecimal eint1, EncDecimal eint2) => new EncDecimal(eint1.Value + eint2.Value);
    public static EncDecimal operator -(EncDecimal eint1, EncDecimal eint2) => new EncDecimal(eint1.Value - eint2.Value);
    public static EncDecimal operator *(EncDecimal eint1, EncDecimal eint2) => new EncDecimal(eint1.Value * eint2.Value);
    public static EncDecimal operator /(EncDecimal eint1, EncDecimal eint2) => new EncDecimal(eint1.Value / eint2.Value);
    public static EncDecimal operator %(EncDecimal eint1, EncDecimal eint2) => new EncDecimal(eint1.Value % eint2.Value);

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
    
    public static implicit operator EncDecimal(decimal value) => new EncDecimal(value);
    public static explicit operator EncDecimal(double value) => new EncDecimal((decimal)value);
    public static explicit operator EncDecimal(float value) => new EncDecimal((decimal)value);
    public static implicit operator EncDecimal(ulong value) => new EncDecimal(value);
    public static implicit operator EncDecimal(long value) => new EncDecimal(value);
    public static implicit operator EncDecimal(uint value) => new EncDecimal(value);
    public static implicit operator EncDecimal(int value) => new EncDecimal(value);
    public static implicit operator EncDecimal(ushort value) => new EncDecimal(value);
    public static implicit operator EncDecimal(short value) => new EncDecimal(value);
    public static implicit operator EncDecimal(byte value) => new EncDecimal(value);
    public static implicit operator EncDecimal(sbyte value) => new EncDecimal(value);

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