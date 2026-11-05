namespace Employees
{
    public static class EmployeeComparisons
    {
        public static bool IsEntranceBefore(Employee a, Employee b)
        {
            int result = string.CompareOrdinal(a.LastEntranceInEngineRoom, b.LastEntranceInEngineRoom);

            if(result == 0)
            {
                result = string.CompareOrdinal(a.LastExitFromEngineRoom, b.LastExitFromEngineRoom);
            }

            return result < 0;
        }

        public static bool IsExitBefore(Employee a, Employee b)
        {
            int result = string.CompareOrdinal(a.LastExitFromEngineRoom, b.LastExitFromEngineRoom);

            return result < 0;
        }

        public static int CompareEntrance(Employee employee, string time)
        {
            return string.CompareOrdinal(employee.LastEntranceInEngineRoom, time);
        }

        public static int CompareExit(Employee employee, string time)
        {
            return string.CompareOrdinal(employee.LastExitFromEngineRoom, time);
        }
    }
}
