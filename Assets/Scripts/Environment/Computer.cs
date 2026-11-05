using Environment.Tasks;
using UnityEngine;
using DataStructures;

namespace Environment 
{
    public class Computer : MonoBehaviour, IInteractable 
    {
        [SerializeField]
        private Task[] startingTasks = null;

        private LinkedQueue<Task> taskQueue = new LinkedQueue<Task>();

        private void Awake()
        {
            foreach(Task task in startingTasks)
            {
                if(task != null)
                {
                    taskQueue.Enqueue(task);
                }
            }
        }

        public void OnInteract()
        {
            if(taskQueue.GetCount() == 0)
            {
                Debug.Log("No tasks queued");
            }

            while(taskQueue.GetCount() > 0)
            {
                Task task = taskQueue.Dequeue();
                task.Execute();
            }
        }
    }
}
