using Algorithms;
using Employees;
using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "NarrowSuspects Task", menuName = "NarrowSuspects Task")]
    public class NarrowSuspectsTask : Task
    {
        [SerializeField]
        private EmployeeDatabase suspects = null;

        [SerializeField]
        private string exitStartTime = "2234-08-09T22:00:00";

        [SerializeField]
        private string exitEndTime = "2234-08-09T23:00:00";

        public override void Execute()
        {
            Employee[] candidates = suspects.employees;

            if(candidates.Length == 0)
            {
                Debug.LogError("No suspects to narrow down. Run the search task first, or try a wider window.");
                return;
            }

            int lastIndex = candidates.Length - 1;

            Quicksort.Sort(candidates, 0, lastIndex, EmployeeComparisons.IsExitBefore);

            Employee[] found = BinarySearch.FindRange(candidates, exitStartTime, exitEndTime, EmployeeComparisons.CompareExit);

            Debug.Log(found.Length + " of " + candidates.Length + " suspects also exited between " + exitStartTime + " and " + exitEndTime);

            foreach(Employee suspect in found)
            {
                Debug.Log("Prime suspect: " + suspect.Name + ", ID " + suspect.EmployeeId + ", entered " + suspect.LastEntranceInEngineRoom + ", exited " + suspect.LastExitFromEngineRoom);
            }
        }
    }
}
