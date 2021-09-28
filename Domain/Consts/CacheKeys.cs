using System;

namespace Domain.Consts
{
    public static class CacheKeys
    {
        public static string GetAllBooks = "GetAllBooks";

        public static string GetBookById(int id) => $"GetBookById_{id}";

    }
}
