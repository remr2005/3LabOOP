//UTF - 8: AFC85E624CD65093906C8B6A222111FF
//unicode: 7A0E8A52E35E48F0BAC1200E81216157D0BCD0B5D182D0BED0B22C20D09AD0B5D0BCD180D0B0D0BD2C20D09BD0B5D0BDD0B2D0B5D180D0BED0B2D0B8D187

using System;
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
