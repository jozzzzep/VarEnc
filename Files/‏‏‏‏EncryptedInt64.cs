public class EncryptedInt64 : EncryptedInteger<long, decimal>
{
    /// 64-bit integer value range: -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807

    #region Constructors

    public EncryptedInt64(long value)
        : base(value) { }

    public EncryptedInt64()
        : this(0) { }

    #endregion
}