# CryptoStringify
Offers a range of extension methods to easily hash strings

# CryptoStringify
Offers a range of extension methods to easily hash strings. Adds Hash() to all HashAlgorithm and KeyedHashAlgorithm classes:

Example:

    using (MD5 md5 = MD5.Create()) 
    { 
        string strHashedPassword = md5.Hash("123"); 
    }
