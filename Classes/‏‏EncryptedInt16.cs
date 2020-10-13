public class EncryptedInt16 : EncryptedInteger<short, float>
{
    /// 16-bit integer value range: -32,768 to 32,767
    ///
    /// Wiki page: https://github.com/JosepeDev/SimpleEncryptionTools/wiki
    /// Examples and tutorial: https://github.com/JosepeDev/SimpleEncryptionTools/wiki/Examples-&-Tutorial

    public EncryptedInt16(short value)
        : base(value) { }

    public EncryptedInt16()
        : this(0) { }
}