using System;
using System.Globalization;
using System.Text;

public class EncString
{
    /// A class for storing a string while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a wierd string that is affected by a very long random key. { encryptionKey }
    /// Every time the value of the string changes, the encryption key changes too. And it works exactly as an string.
    ///
    /// WIKI & INFO: https://github.com/JosepeDev/VarEnc

    #region Variables And Properties

    private readonly char[] _encryptionKeys;
    private readonly char[] _encryptedValue;

    /// <summary>
    /// The decrypted value of the stored string.
    /// </summary>
    private string Value
    {
        get => Decrypt();
    }

    public int Length
    {
        get => Value.Length;
    }

    public static string Empty
    {
        get => string.Empty;
    }

    public char this[int index]
    {
        get => Value[index];
    }

    #endregion

    #region Methods

    public bool IsEqual(EncString encString) => encString.Value == this.Value;
    public bool IsNull() => this.Value == null;
    public object Clone() => Value.Clone();
    public override bool Equals(object obj) => Value.Equals(obj);
    public override int GetHashCode() => Value.GetHashCode();
    public bool Contains(string value) => Value.Contains(value);
    public int CompareTo(object value) => Value.CompareTo(value);
    public int CompareTo(string strB) => Value.CompareTo(strB);
    public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count) => Value.CopyTo(sourceIndex, destination, destinationIndex, count);
    public bool EndsWith(string value) => Value.EndsWith(value);
    public bool EndsWith(string value, StringComparison comparisonType) => Value.EndsWith(value, comparisonType);
    public bool EndsWith(string value, bool ignoreCase, CultureInfo culture) => Value.EndsWith(value, ignoreCase, culture);
    public CharEnumerator GetEnumerator() => Value.GetEnumerator();
    public TypeCode GetTypeCode() => Value.GetTypeCode();
    public int IndexOf(string value, int startIndex, StringComparison comparisonType) => Value.IndexOf(value, startIndex, comparisonType);
    public int IndexOf(string value, StringComparison comparisonType) => Value.IndexOf(value, comparisonType);
    public int IndexOf(string value, int startIndex, int count) => Value.IndexOf(value, startIndex, count);
    public int IndexOf(string value) => Value.IndexOf(value);
    public int IndexOf(char value, int startIndex, int count) => Value.IndexOf(value, startIndex, count);
    public int IndexOf(char value, int startIndex) => Value.IndexOf(value, startIndex);
    public int IndexOf(char value) => Value.IndexOf(value);
    public int IndexOf(string value, int startIndex, int count, StringComparison comparisonType) => Value.IndexOf(value, startIndex, count, comparisonType);
    public int IndexOf(string value, int startIndex) => Value.IndexOf(value, startIndex);
    public int IndexOfAny(char[] anyOf) => Value.IndexOfAny(anyOf);
    public int IndexOfAny(char[] anyOf, int startIndex, int count) => Value.IndexOfAny(anyOf, startIndex, count);
    public int IndexOfAny(char[] anyOf, int startIndex) => Value.IndexOfAny(anyOf, startIndex);
    public string Insert(int startIndex, string value) => Value.Insert(startIndex, value);
    public bool IsNormalized() => Value.IsNormalized();
    public bool IsNormalized(NormalizationForm normalizationForm) => Value.IsNormalized(normalizationForm);
    public int LastIndexOf(string value, int startIndex, StringComparison comparisonType) => Value.LastIndexOf(value, startIndex, comparisonType);
    public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType) => Value.LastIndexOf(value, startIndex, count, comparisonType);
    public int LastIndexOf(string value, int startIndex, int count) => Value.LastIndexOf(value, startIndex, count);
    public int LastIndexOf(string value, StringComparison comparisonType) => Value.LastIndexOf(value, comparisonType);
    public int LastIndexOf(string value) => Value.LastIndexOf(value);
    public int LastIndexOf(char value, int startIndex, int count) => Value.LastIndexOf(value, startIndex, count);
    public int LastIndexOf(char value, int startIndex) => Value.LastIndexOf(value, startIndex);
    public int LastIndexOf(string value, int startIndex) => Value.LastIndexOf(value, startIndex);
    public int LastIndexOf(char value) => Value.LastIndexOf(value);
    public int LastIndexOfAny(char[] anyOf) => Value.LastIndexOfAny(anyOf);
    public int LastIndexOfAny(char[] anyOf, int startIndex) => Value.LastIndexOfAny(anyOf, startIndex);
    public int LastIndexOfAny(char[] anyOf, int startIndex, int count) => Value.LastIndexOfAny(anyOf, startIndex, count);
    public string Normalize() => Value.Normalize();
    public string Normalize(NormalizationForm normalizationForm) => Value.Normalize(normalizationForm);
    public string PadLeft(int totalWidth) => Value.PadLeft(totalWidth);
    public string PadLeft(int totalWidth, char paddingChar) => Value.PadLeft(totalWidth, paddingChar);
    public string PadRight(int totalWidth) => Value.PadRight(totalWidth);
    public string PadRight(int totalWidth, char paddingChar) => Value.PadRight(totalWidth, paddingChar);
    public string Remove(int startIndex) => Value.Remove(startIndex);
    public string Remove(int startIndex, int count) => Value.Remove(startIndex, count);
    public string Replace(string oldValue, string newValue) => Value.Replace(oldValue, newValue);
    public string Replace(char oldChar, char newChar) => Value.Replace(oldChar, newChar);
    public string[] Split(string[] separator, int count, StringSplitOptions options) => Value.Split(separator, count, options);
    public string[] Split(params char[] separator) => Value.Split(separator);
    public string[] Split(char[] separator, int count) => Value.Split(separator, count);
    public string[] Split(char[] separator, int count, StringSplitOptions options) => Value.Split(separator, count, options);
    public string[] Split(char[] separator, StringSplitOptions options) => Value.Split(separator, options);
    public string[] Split(string[] separator, StringSplitOptions options) => Value.Split(separator, options);
    public bool StartsWith(string value) => Value.StartsWith(value);
    public bool StartsWith(string value, bool ignoreCase, CultureInfo culture) => Value.StartsWith(value, ignoreCase, culture);
    public bool StartsWith(string value, StringComparison comparisonType) => Value.StartsWith(value, comparisonType);
    public string Substring(int startIndex) => Value.Substring(startIndex);
    public string Substring(int startIndex, int length) => Value.Substring(startIndex, length);
    public char[] ToCharArray(int startIndex, int length) => Value.ToCharArray(startIndex, length);
    public char[] ToCharArray() => Value.ToCharArray();
    public string ToLower() => Value.ToLower();
    public string ToLower(CultureInfo culture) => Value.ToLower(culture);
    public string ToLowerInvariant() => Value.ToLowerInvariant();
    public override string ToString() => Value.ToString();
    public string ToString(IFormatProvider provider) => Value.ToString(provider);
    public string ToUpper() => Value.ToUpper();
    public string ToUpper(CultureInfo culture) => Value.ToUpper(culture);
    public string ToUpperInvariant() => Value.ToUpperInvariant();
    public string Trim() => Value.Trim();
    public string Trim(params char[] trimChars) => Value.Trim(trimChars);
    public string TrimEnd(params char[] trimChars) => Value.TrimEnd(trimChars);
    public string TrimStart(params char[] trimChars) => Value.TrimStart(trimChars);

    #endregion

    #region Constructors

    public EncString(string value)
    {
        _encryptionKeys = EncKeys();
        _encryptedValue = Encrypt(value, _encryptionKeys);
    }

    public EncString(char[] value)
        : this(new string(value)) { }

    public EncString(char c, int count)
        : this(new string(c, count)) { }

    public EncString(char[] value, int startIndex, int length)
        : this(new string(value, startIndex, length)) { }


    #endregion

    #region Encryption Decryption

    static Random random = new Random();

    static char[] EncKeys()
    {
        char[] chars = new char[random.Next(10, 100)]; // random length
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(random.Next(char.MinValue, char.MinValue)); // random chars
        }
        return chars;
    }

    private static char[] Encrypt(string data, char[] key)
    {
        if (data == null)
        {
            return null;
        }
        else
        {
            int dataLen = data.Length;
            int keyLen = key.Length;
            char[] output = new char[dataLen];

            for (int i = 0; i < dataLen; ++i)
            {
                output[i] = (char)(data[i] ^ key[i % keyLen]);
            }

            return output;
        }
    }

    private string Decrypt()
    {
        if (_encryptedValue == null)
        {
            return null;
        }
        else
        {
            int dataLen = _encryptedValue.Length;
            int keyLen = _encryptionKeys.Length;
            char[] output = new char[dataLen];

            for (int i = 0; i < dataLen; ++i)
            {
                output[i] = (char)(_encryptedValue[i] ^ _encryptionKeys[i % keyLen]);
            }

            return new string(output);
        }
    }

    #endregion

    #region Operators Overloading

    /// + 
    public static EncString operator +(EncString enc, string n) => new EncString(enc.Value + n);
    public static string operator +(string n, EncString enc) => enc.Value + n;

    /// == != < >
    public static bool operator ==(EncString es1, string es2) => es1.Value == es2;
    public static bool operator !=(EncString es1, string es2) => es1.Value != es2;

    /// assign
    public static implicit operator EncString(string value) => new EncString(value);
    public static implicit operator string(EncString encString) => encString.Value;

    #endregion
}