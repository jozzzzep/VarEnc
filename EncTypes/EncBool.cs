using System;

namespace EncTypes
{
    public struct EncBool
    {
        /// Of all the encrypted values you could've picked.
        /// You thought you would need an encrypted bool.
        /// You're a failure as a human being and a waste of life.

        #region Variables

        readonly bool _value;

        #endregion

        #region Properties

        public bool Value
        {
            get => Decrypt();
        }

        public static string FalseString { get => Boolean.FalseString; }
        public static string TrueString { get => Boolean.TrueString; }

        #endregion

        #region Constructors

        private EncBool(bool value) => _value = Encrypt(value);

        #endregion

        #region Methods

        static bool Encrypt(bool boolVar)
        {
            return !boolVar;
        }

        bool Decrypt()
        {
            return !_value;
        }

        public int CompareTo(Boolean value) => Value.CompareTo(value);
        public int CompareTo(object obj) => Value.CompareTo(obj);
        public Boolean Equals(Boolean obj) => Value.Equals(obj);
        public override Boolean Equals(object obj) => Value.Equals(obj);
        public override int GetHashCode() => Value.GetHashCode();
        public TypeCode GetTypeCode() => Value.GetTypeCode();
        public override string ToString() => Value.ToString();
        public string ToString(IFormatProvider provider) => Value.ToString(provider);

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
}