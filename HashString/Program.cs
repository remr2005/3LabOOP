using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("MD5");
        Console.WriteLine($"UTF-8: {computeMD5("UTF-8")}");
        Console.WriteLine($"unicode: {computeMD5("unicode")}");
        Console.WriteLine("SHA256");
        Console.WriteLine($"UTF-8: {computeSHA256("UTF-8")}");
        Console.WriteLine($"unicode: {computeSHA256("unicode")}");
    }
    private static string computeMD5(string str)
    {
        MD5 md5 = MD5.Create();
        byte[] arr = Encoding.GetEncoding(str).GetBytes("Аметов, Кемран, Ленверович");
        arr = md5.ComputeHash(arr);
        return Convert.ToHexString(arr);
    }
    private static string computeSHA256(string str)
    {
        SHA256 md5 = SHA256.Create();
        byte[] arr = Encoding.GetEncoding(str).GetBytes("Аметов, Кемран, Ленверович");
        arr = md5.ComputeHash(arr);
        return Convert.ToHexString(arr);
    }
}
