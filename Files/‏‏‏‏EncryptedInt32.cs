public class EncryptedInt32 : EncryptedInteger<int, double>
{
    /// 32-bit integer value range: -2,147,483,648 to 2,147,483,647

    #region Constructors

    public EncryptedInt32(int value)
        : base(value) { }

    public EncryptedInt32()
        : this(0) { }

    #endregion
}