using System.IO;
using Employees;
using UnityEngine;

namespace Environment.Tasks 
{
    [CreateAssetMenu(fileName = "ReadEmployeesFile Task", menuName = "ReadEmployeesFile Task")]
    public class ReadEmployeesFileTask : Task 
    {
        [SerializeField]
        private string fileName = "fullEmployeesList.json";

        [SerializeField]
        private InsertEmployeesTask insertTask = null;

        public override void Execute()
        {
            string path = Path.Combine(Application.streamingAssetsPath, fileName);

            if(!File.Exists(path))
            {
                Debug.LogError("File not found: " + path);
                return;
            }

            string json = File.ReadAllText(path);
            EmployeeList employeeList = JsonUtility.FromJson<EmployeeList>(json);

            insertTask.SetEmployees(employeeList.Employees);

            Debug.Log("Read " + employeeList.Employees.Length + " employees from " + fileName);
        }
    }
}
