using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        DateTime now = DateTime.Now;
        DateTime date1 = new DateTime(2023, 7, 29, 12, 30, 0);
        DateTime date2 = new DateTime(2023, 7, 30, 12, 30, 0);
        DateTime date3 = new DateTime(2023, 7, 31, 12, 30, 0);

        var users = new List<dynamic>
        {
            new { Id = "ohviae",UserId = "john", product_id = 1, UserRole = "Administrator", EmployeeIdNo = "E123", UserName = "John Doe", Item2 = 10, UpdateDateTime = DateTime.Now },
            new { Id = "vibuve",UserId = "alice", product_id = 2, UserRole = "User", EmployeeIdNo = "E456", UserName = "Alice Smith", Item2 = 5, UpdateDateTime = DateTime.Now },
            new { Id = "vebidd",UserId = "jones", product_id = 3, UserRole = "User", EmployeeIdNo = "E789", UserName = "Tom Jones", Item2 = 3, UpdateDateTime = DateTime.Now },
        };

        var users2 = new List<dynamic>
        {
            new { UserId = "john", LockDuration = now }, 
            new { UserId = "alice", LockDuration = date1 }, 
            new { UserId = "jones", LockDuration = date2 }, 
        };

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
