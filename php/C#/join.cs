using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var users = new List<dynamic>
        {
            new { Id = "ohviae",UserId = "john", product_id = 1, UserRole = "Administrator", EmployeeIdNo = "E123", UserName = "John Doe", Item2 = 10, UpdateDateTime = DateTime.Now },
            new { Id = "vibuve",UserId = "alice", product_id = 2, UserRole = "User", EmployeeIdNo = "E456", UserName = "Alice Smith", Item2 = 5, UpdateDateTime = DateTime.Now },
            new { Id = "vebidd",UserId = "jones", product_id = 3, UserRole = "User", EmployeeIdNo = "E789", UserName = "Tom Jones", Item2 = 3, UpdateDateTime = DateTime.Now },
        };

        var users2 = new List<dynamic>
        {
            new { UserId = "john", LockDuration = DateTime.Now.AddDays(1) }, 
            new { UserId = "alice", LockDuration = DateTime.Now.AddMinutes(-30) }, 
            new { UserId = "jones", LockDuration = DateTime.Now.AddHours(2) }, 
        };

        DateTime now = DateTime.Now;
        
        // マージする
        var mergedUsers = users
            .Join(users2,
                user => user.UserId,
                user2 => user2.UserId,
                (user, user2) => new
                {
                    user.Id,
                    user.UserId,
                    user.product_id,
                    user.UserRole,
                    user.EmployeeIdNo,
                    user.UserName,
                    user.Item2,
                    user.UpdateDateTime,
                    LockDuration = user2.LockDuration
                })
            .ToList();

        // マージした結果を表示（デバッグ用）
        foreach (var user in mergedUsers)
        {
            Console.WriteLine($"Id: {user.Id}, UserId: {user.UserId}, product_id: {user.product_id}, UserRole: {user.UserRole}, EmployeeIdNo: {user.EmployeeIdNo}, UserName: {user.UserName}, Item2: {user.Item2}, UpdateDateTime: {user.UpdateDateTime}, LockDuration: {user.LockDuration}");
        }

    }
}
