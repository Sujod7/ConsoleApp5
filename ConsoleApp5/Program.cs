using ConsoleApp5;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // تأكد من أن قاعدة البيانات تم إنشاؤها
        using (var context = new Employeecontext())
        {
            context.Database.EnsureCreated();
        }

        // قراءة بيانات JSON من الملف
        string file = File.ReadAllText("Employees.json");

        // تحليل البيانات إلى قائمة من الموظفين
        List<Employee> employees = JsonSerializer.Deserialize<List<Employee>>(file);

        // إضافة البيانات إلى قاعدة البيانات
        using (var context = new Employeecontext())
        {
            // إضافة كل موظف على حدة
            context.Employees.AddRange(employees);

            // حفظ التغييرات في قاعدة البيانات
            context.SaveChanges();
        }

        Console.WriteLine("Data has been added successfully.");
    }
}
