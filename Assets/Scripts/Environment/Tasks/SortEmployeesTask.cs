using Algorithms;
using Employees;
using UnityEngine;

namespace Environment.Tasks 
{
    [CreateAssetMenu(fileName = "SortEmployees Task", menuName = "SortEmployees Task")]
    public class SortEmployeesTask : Task
    {
        [SerializeField]
        private EmployeeDatabase database = null;

        public override void Execute()
        {
            Employee[] employees = database.employees;

            if(employees.Length == 0)
            {
                Debug.LogError("No employees to sort. Run the read task and insert task first.");
                return;
            }

            int lastIndex = employees.Length - 1;

            Quicksort.Sort(employees, 0, lastIndex, EmployeeComparisons.IsEntranceBefore);

            Debug.Log("Sorted " + employees.Length + " employees");
            for(int i = 0; i < employees.Length; i++)
            {
                Debug.Log("Employee:" + employees[i].Name + " " + employees[i].LastEntranceInEngineRoom);
            }
            
            Debug.Log("First: " + employees[0].Name + " " + employees[0].LastEntranceInEngineRoom);
            Debug.Log("Last: " + employees[lastIndex].Name + " " + employees[lastIndex].LastEntranceInEngineRoom);
        }
    }
}
