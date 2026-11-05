using Employees;
using UnityEngine;

namespace Environment.Tasks 
{
    [CreateAssetMenu(fileName = "InsertEmployees Task", menuName = "InsertEmployees Task")]
    public class InsertEmployeesTask : Task 
    {
        [SerializeField]
        private EmployeeDatabase database = null;

        private Employee[] employeesFromFile = null;

        public void SetEmployees(Employee[] employees)
        {
            employeesFromFile = employees;
        }

        public override void Execute()
        {
            if(employeesFromFile == null)
            {
                Debug.LogError("No employees to insert. Run the read task first.");
                return;
            }

            Employee[] employeeArray = new Employee[employeesFromFile.Length];

            for(int i = 0; i < employeesFromFile.Length; i++)
            {
                employeeArray[i] = employeesFromFile[i];
            }

            database.employees = employeeArray;
            employeesFromFile = null;

            Debug.Log("Inserted " + employeeArray.Length + " employees into the array");
        }
    }
}
