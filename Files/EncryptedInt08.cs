public class EncryptedInt08 : EncryptedInteger<sbyte, float>
{
    /// 8-bit integer value range: -128 to 127
    ///
    /// Wiki page: https://github.com/JosepeDev/SimpleEncryptionTools/wiki
    /// Examples and tutorial: https://github.com/JosepeDev/SimpleEncryptionTools/wiki/Examples-&-Tutorial

    public EncryptedInt08(sbyte value)
        : base(value) { }

    public EncryptedInt08()
        : this(0) { }
}