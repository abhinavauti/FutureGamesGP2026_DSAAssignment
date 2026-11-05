using Algorithms;
using Employees;
using UnityEngine;
using Utilities;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "SearchEmployees Task", menuName = "SearchEmployees Task")]
    public class SearchEmployeesTask : Task
    {
        [SerializeField]
        private EmployeeDatabase database = null;

        [SerializeField]
        private EmployeeDatabase suspects = null;

        [SerializeField]
        private string startTime = "2234-08-09T22:00:00";

        [SerializeField]
        private string endTime = "2234-08-09T23:00:00";

        [SerializeField]
        private int benchmarkRuns = 1000;

        public override void Execute()
        {
            Employee[] employees = database.employees;

            if(employees.Length == 0)
            {
                Debug.LogError("No employees to search. Run the read, insert and sort tasks first.");
                return;
            }

            Employee[] found = BinarySearch.FindRange(employees, startTime, endTime, EmployeeComparisons.CompareEntrance);

            suspects.employees = found;

            Debug.Log("Found " + found.Length + " employees who entered the engine room between " + startTime + " and " + endTime);

            foreach(Employee suspect in found)
            {
                Debug.Log("Suspect: " + suspect.Name + ", ID " + suspect.EmployeeId + ", entered " + suspect.LastEntranceInEngineRoom + ", exited " + suspect.LastExitFromEngineRoom);
            }

            double binaryTime = Benchmark.Measure(RunBinarySearch, benchmarkRuns);
            double linearTime = Benchmark.Measure(RunLinearSearch, benchmarkRuns);

            Debug.Log("Binary search: " + binaryTime.ToString("F5") + " ms per search, average of " + benchmarkRuns + " runs");
            Debug.Log("Linear search: " + linearTime.ToString("F5") + " ms per search, average of " + benchmarkRuns + " runs");
            Debug.Log("Linear search was " + (linearTime / binaryTime).ToString("F0") + " times slower");
        }

        private void RunBinarySearch()
        {
            BinarySearch.FindRange(database.employees, startTime, endTime, EmployeeComparisons.CompareEntrance);
        }

        private void RunLinearSearch()
        {
            LinearSearch.FindRange(database.employees, startTime, endTime, EmployeeComparisons.CompareEntrance);
        }
    }
}
