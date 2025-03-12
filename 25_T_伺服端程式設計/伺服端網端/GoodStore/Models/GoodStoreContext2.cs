using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace GoodStore.Models;

public partial class GoodStoreContext : DbContext
{
    public string ComputeSha256Hash(string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }


    public async Task<int> ExecSPAddNewOrderAsync(string MemberID, string ContactName, string ContactAddress, string Cart)
    {
        var result= this.Database.ExecuteSqlRawAsync("EXEC AddNewOrder {0}, {1},{2},{3}", MemberID, ContactName, ContactAddress, Cart);

        return await result;
    }

}
