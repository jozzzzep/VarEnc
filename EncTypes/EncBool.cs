using System;
using System.Collections.Generic;
using System.Text;

struct EncBool
{
    /// Of all the encrypted values you could've picked,
    /// you thought you would need an encrypted bool...
    /// you're a failure as a human being and a waste of life.

    #region Variables And Properties

    readonly bool _value;
    bool Value
    {
        get => Decrypt(_value);
    }

    #endregion

    #region Constructors

    private EncBool(bool value) => _value = Encrypt(value);

    #endregion

    #region Methods

    static bool Encrypt(bool boolVar)
    {
        return !boolVar;
    }
    static bool Decrypt(bool boolVar)
    {
        return !boolVar;
    }
    

    #endregion

    #region Operators Overloading

    public static bool operator ==(EncBool eint1, bool eint2) => eint1.Value == eint2;
    public static bool operator !=(EncBool eint1, bool eint2) => eint1.Value != eint2;

    public static bool operator ==(EncBool eint1, EncBool eint2) => eint1.Value == eint2.Value;
    public static bool operator !=(EncBool eint1, EncBool eint2) => eint1.Value != eint2.Value;

    public static implicit operator EncBool(bool value) => new EncBool(value);
    public static implicit operator bool(EncBool eint1) => eint1._value;

    #endregion
}
