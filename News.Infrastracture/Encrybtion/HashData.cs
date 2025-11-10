using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Infrastracture.Encrybtion;

public class HashData
{
    public static string Hash(string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentException("Input cannot be null or empty.", nameof(input));   
        var result= BCrypt.Net.BCrypt.HashPassword(input);
        return result;  

    }
    public static bool Verify(string input, string hash)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentException("Input cannot be null or empty.", nameof(input));
        if (string.IsNullOrEmpty(hash))
            throw new ArgumentException("Hash cannot be null or empty.", nameof(hash));
        var result = BCrypt.Net.BCrypt.Verify(input, hash);
        return result;
    }
}
