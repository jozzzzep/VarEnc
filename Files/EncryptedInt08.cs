public class EncryptedInt08 : EncryptedInteger<sbyte, float>
{
    /// 8-bit integer value range: -128 to 127

    #region Constructors

    public EncryptedInt08(sbyte value)
        : base(value) { }

    public EncryptedInt08()
        : this(0) { }

    #endregion
}