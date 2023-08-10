

namespace Kryptering_4___Asymmetric_Encryption_Receiver.Services
{
    /// <summary>
    /// Responsible for decryption logic
    /// </summary>
    internal interface IDecryptionService
    {
        /// <summary>
        /// Generates a public key used for encryption
        /// </summary>
        /// <returns>Byte array containing the public key</returns>
        public void GenNewKeys(string publicKeyPath, string privateKeyPath);

        /// <summary>
        /// Decrypts a message with a private key
        /// </summary>
        /// <param name="bytesToDecrypt">The bytes to decrypt</param>
        /// <param name="privateKey">The private key used for decryption</param>
        /// <returns>Byte array containing the decrypted message</returns>
        public byte[] Decrypt(byte[] bytesToDecrypt, string privateKeyPath);
    }
}
