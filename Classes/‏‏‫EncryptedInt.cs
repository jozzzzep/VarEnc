using System;

[System.Serializable]
public class EncryptedInt
{
    /// A class for storing an int while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a float that is affected by random values. { encryptionValue1 & encryptionValue2 }
    /// It is recommended to reset them everytime the program starts.
    ///
    /// Wiki page: https://github.com/JosepeDev/SimpleEncryptionTools/wiki
    /// Examples and tutorial: https://github.com/JosepeDev/SimpleEncryptionTools/wiki/Examples-&-Tutorial
    /// 
    /// ---- Properties:
    /// 
    /// Value - Returns the decrypted value of the stored int. It'll work exactly as an int.
    /// 
    /// ---- Methods: 
    /// 
    /// ResetEncryptionKeys() - Changes the random values that effect the stored int while keeping its value
    /// ToString() - Returns the value of the stored int as a string.


    #region Variables and Properties

    // The encryption values
    private float encryptionValue1;
    private float encryptionValue2;

    // The encrypted value stored in memory
    private float _value;

    // The decrypted value
    public int Value
    {
        set
        {
            _value = encrypt(value);
        }
        get
        {
            return (int)Math.Round(decrypt(_value));
        }
    }

    #endregion

    #region Constructors

    // Constractors
    public EncryptedInt(int value)
    {
        SetEncryptionKeys();
        _value = encrypt(value);
    }

    public EncryptedInt()
        : this(0) { }

    #endregion

    #region Methods

    // Takes a given value and returns it encrypted
    private float encrypt(float value)
    {
        float valueToReturn = value;
        valueToReturn += encryptionValue1;
        valueToReturn *= encryptionValue2;
        return valueToReturn;
    }

    // Takes an encrypted value and returns it decrypted
    private float decrypt(float value)
    {
        float valueToReturn = value;
        valueToReturn /= encryptionValue2;
        valueToReturn -= encryptionValue1;
        return valueToReturn;
    }

    // Setting the encryption keys to a new random values
    private void SetEncryptionKeys()
    {
        encryptionValue1 = EncryptionTools.RandomNumber();
        encryptionValue2 = EncryptionTools.RandomNumber();
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
}
