using System.Collections.Generic;
using System;
using System.Linq;

public class Department
{
    public long Id { get; set; }

    public string Name { get; set; }

    public override string ToString() {
        return string.Format("{0}", Name);
    }
}

public class Employee {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Title { get; set; }

    public int DepartmentId { get; set; }

    public override string ToString()
    {
        return string.Format("{0} ({1})", Name, Title);
    }
}

public static class CorporateData
{
    public static readonly Department[] Departments = new Department[]
    {
        new Department(){ Name="Corporate", Id=0},
        new Department(){ Name="Finance", Id=1},
        new Department(){ Name="Engineering", Id=2},
        new Department(){ Name="Information Technology", Id=3},
        new Department(){ Name="Research", Id=4},
        new Department(){ Name="Marketing", Id=5},
    };

    public static readonly Employee[] Employees = new Employee[]
    {
        new Employee(){
            Name="Mark Michaelis", Title="Chief Computer Nerd", DepartmentId = 0},
        new Employee(){
            Name="Michael Stokesbary", Title="Senior Computer Wizard", DepartmentId=2},
        new Employee(){
            Name="Brian Jones", Title="Enterprise Integration Guru", DepartmentId=2},
        new Employee(){
            Name="Jewel Floch", Title="Bookkeeper Extraordinaire", DepartmentId=1},
        new Employee(){
            Name="Robert Stokesbary", Title="Expert Mainframe Engineer", DepartmentId = 3},
        new Employee(){
            Name="Paul R. Bramsman", Title="Programmer Extraordinaire", DepartmentId = 2},
        new Employee(){
            Name="Thomas Heavey", Title="Software Architect", DepartmentId = 2},
        new Employee(){ Name="John Michaelis", Title="Inventor", DepartmentId = 4},
    };
}

class Program
{
    public static void Main(string[] args)
    {
        TestJoin();
        Console.WriteLine();
        TestGroupBy();
        Console.WriteLine();
        TestGroupJoin();
    }

    public static void TestJoin()
    {
        Console.WriteLine("--------------- Join -------------------");
        Employee[] employees = CorporateData.Employees;
        Department[] departments = CorporateData.Departments;

        var items = employees.Join(
            departments, 
            employee => employee.DepartmentId,
            department => department.Id,
            (employee, department) => new {
                employee.Id,
                employee.Name,
                employee.Title,
                Department = department
            });

        foreach (var item in items)
        {
            Console.WriteLine("{0} ({1})", item.Name, item.Title);
            Console.WriteLine("\t" + item.Department);
        }
    }

    public static void TestGroupBy()
    {
        Console.WriteLine("--------------- GroupBy -------------------");
        Employee[] employees = CorporateData.Employees;

        IEnumerable<IGrouping<int, Employee>> groups = employees.GroupBy(employ => employ.DepartmentId);
        Console.WriteLine("Type: " + groups.GetType());
        foreach (var item in groups)
        {
            Console.WriteLine();
            foreach (Employee e in item)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Count: " + item.Count());
        }
    }

    public static void TestGroupJoin()
    {
        Console.WriteLine("---------------- GroupJoin -----------------");
        Employee[] employees = CorporateData.Employees;
        Department[] departments = CorporateData.Departments;

        var items = departments.GroupJoin(
            employees,
            department => department.Id,
            employee => employee.DepartmentId,
            (department, departmentEmployees) => new {
                department.Id,
                department.Name,
                Employees = departmentEmployees
            });

        foreach (var item in items)
        {
            Console.WriteLine("{0}", item.Name);
            foreach (Employee e in item.Employees)
            {
                Console.WriteLine("\t {0}", e);
            }
        }
    }
    
    private static void Print<T>(IEnumerable<T> items)
    {
        foreach (T item in items)
        {
            Console.WriteLine(item);
        }
    }
}
