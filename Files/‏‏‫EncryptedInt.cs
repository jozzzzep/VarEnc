using System;

public class EncryptedInt
{
    /// A class for storing a 32-bit integer while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a floating-point number that is affected by random values. { encryptionKey1 & encryptionKey2 }
    /// It is recommended to reset them everytime the program starts.
    ///
    /// Wiki page: https://github.com/JosepeDev/Variable-Encryption/wiki
    /// Examples and tutorial: https://github.com/JosepeDev/Variable-Encryption/wiki/Examples-&-Tutorial
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
    private float encryptionKey1;
    private float encryptionKey2;

    // The encrypted value stored in memory
    private double encryptedValue;

    // The decrypted value
    public int Value
    {
        set
        {
            encryptedValue = encrypt(value);
        }
        get
        {
            return (int)Math.Round(decrypt(encryptedValue));
        }
    }

    #endregion

    #region Constructors

    // Constractors
    public EncryptedInt(int value)
    {
        SetEncryptionKeys();
        encryptedValue = encrypt(value);
    }

    public EncryptedInt()
        : this(0) { }

    #endregion

    #region Methods

    // Takes a given value and returns it encrypted
    private double encrypt(double value)
    {
        double valueToReturn = value;
        valueToReturn += encryptionKey1;
        valueToReturn *= encryptionKey2;
        return valueToReturn;
    }

    // Takes an encrypted value and returns it decrypted
    private double decrypt(double value)
    {
        double valueToReturn = value;
        valueToReturn /= encryptionKey2;
        valueToReturn -= encryptionKey1;
        return valueToReturn;
    }

    // Setting the encryption keys to a new random values
    private void SetEncryptionKeys()
    {
        encryptionKey1 = EncryptionTools.RandomNumberFloat();
        encryptionKey2 = EncryptionTools.RandomNumberFloat();
    }

    // Resets the encryption keys and keeps the stored values
    public void ResetEncryptionKeys()
    {
        // keep and decrypt the current value
        int decryptedValue = Value;

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