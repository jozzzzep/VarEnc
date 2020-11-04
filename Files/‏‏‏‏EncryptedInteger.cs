using System;

[System.Serializable]
public class EncryptedInteger<TDecrypted, TEncrypted>
        where TDecrypted : IComparable, IConvertible
        where TEncrypted : IComparable, IConvertible
{
    /// A generic class for storing every type of integer while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a floating-point number that is affected by random values. { encryptionKey1 & encryptionKey2 }
    /// It is recommended to reset them everytime the program starts.
    ///
    /// Wiki page: https://github.com/JosepeDev/Variable-Encryption/wiki
    /// Examples and tutorial: https://github.com/JosepeDev/Variable-Encryption/wiki/Examples-&-Tutorial
    /// 
    /// ---- Generic setup:
    /// 
    /// TDecrypted should be an integer:
    /// sbyte, short, int, long
    /// 
    /// TEncrypted shoud be a floating-point number:
    /// float, double, decimal
    /// 
    /// ---- Properties:
    /// 
    /// Value - Returns the decrypted value of the stored int. It'll work exactly as an int.
    /// 
    /// ---- Methods: 
    /// 
    /// ResetEncryptionKeys() - Changes the random values that effect the stored int while keeping its value
    /// ToString() - Returns the value of the stored int as a string.

    #region Content

    #region Variables and Properties

    // The encryption values
    dynamic encryptionKey1;
    dynamic encryptionKey2;

    // The encrypted value stored in memory
    private TEncrypted encryptedValue;

    // The decrypted value
    public TDecrypted Value
    {
        set
        {
            dynamic val = value;
            encryptedValue = encrypt(val);
        }
        get
        {
            dynamic encryptedVal = encryptedValue;
            return (TDecrypted)Math.Round(decrypt(encryptedVal));
        }
    }

    #endregion

    #region Constructors

    // Constractors
    public EncryptedInteger(TDecrypted value)
    {
        dynamic val = value;
        SetEncryptionKeys();
        encryptedValue = encrypt(val);
    }

    public EncryptedInteger()
    {
        dynamic val = 0;
        SetEncryptionKeys();
        encryptedValue = encrypt(val);
    }

    #endregion

    #region Methods

    // Takes a given value and returns it encrypted
    private TEncrypted encrypt(TEncrypted value)
    {
        TEncrypted valueToReturn = value;
        valueToReturn += encryptionKey1;
        valueToReturn *= encryptionKey2;
        return valueToReturn;
    }

    // Takes an encrypted value and returns it decrypted
    private TEncrypted decrypt(TEncrypted value)
    {
        TEncrypted valueToReturn = value;
        valueToReturn /= encryptionKey2;
        valueToReturn -= encryptionKey1;
        return valueToReturn;
    }

    // Setting the encryption keys to a new random values
    private void SetEncryptionKeys()
    {
        dynamic randomVar1 = EncryptionTools.RandomNumberDouble();
        dynamic randomVar2 = EncryptionTools.RandomNumberDouble();
        encryptionKey1 = (TEncrypted)randomVar1;
        encryptionKey2 = (TEncrypted)randomVar2;
    }

    // Resets the encryption keys and keeps the stored values
    public void ResetEncryptionKeys()
    {
        // keep and decrypt the current value
        TDecrypted decryptedValue = Value;

        // set a new values to the encryption keys
        SetEncryptionKeys();

        // set and encrypt the value back with the new keys
        Value = decryptedValue;
    }

    // Returns the stored value as a string
    public string ToString()
    {
        return Value.ToString();
    }

    #endregion

    #endregion
}