public class EncryptedInt16 : EncryptedInteger<short, float>
{
    /// 16-bit integer value range: -32,768 to 32,767

    #region Constructors

    public EncryptedInt16(short value)
        : base(value) { }

    public EncryptedInt16()
        : this(0) { }

    #endregion
}