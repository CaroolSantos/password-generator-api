using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorAPI.Data;
using PasswordGeneratorAPI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordGeneratorAPI.Services
{
    public class PasswordService
    {
        //private readonly ApplicationDbContext _context;

        //public PasswordService(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public PasswordService()
        {
                
        }

        public async Task<Password> GeneratePasswordAsync(int length, bool includeUpperCase, bool includeLowerCase, bool includeNumbers, bool includeSpecialCharacters)
        {
            var characters = "abcdefghijklmnopqrstuvwxyz";
            if (includeUpperCase) characters += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (includeLowerCase) characters += "abcdefghijklmnopqrstuvwxyz";
            if (includeNumbers) characters += "0123456789";
            if (includeSpecialCharacters) characters += "!@#$%^&*()-_=+<>?";

            var random = new Random();
            var password = new string(Enumerable.Repeat(characters, length)
                                .Select(s => s[random.Next(s.Length)]).ToArray());

            var generatedPassword = new Password
            {
                GeneratedPassword = password,
                GeneratedAt = DateTime.Now
            };

            //_context.Passwords.Add(generatedPassword);
            //await _context.SaveChangesAsync();

            return generatedPassword;
        }
    }
}