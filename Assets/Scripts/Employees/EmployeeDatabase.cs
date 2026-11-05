using UnityEngine;

namespace Employees 
{
    [CreateAssetMenu(fileName = "Employee Database", menuName = "Employee Database")]
    public class EmployeeDatabase : ScriptableObject 
    {
        public Employee[] employees;
    }
}
