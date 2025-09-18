Console.WriteLine("Hello, World!");
Console.ReadLine();

public class TaskManager
{
    // TaskId to Task mapping for O(1) access to tasks by their ID and Max-Heap to get the highest priority task efficiently.
    private readonly Dictionary<int, Task> taskIdToTaskMap;
    private readonly SortedSet<Task> maxHeapByPriority; 

    public TaskManager(IList<IList<int>> tasks)
    {
        taskIdToTaskMap = [];
        maxHeapByPriority = [];
        Prepare(tasks);
    }

    public void Add(int userId, int taskId, int priority)
    {
        var task = CreateTask(userId, taskId, priority);
        taskIdToTaskMap.Add(taskId, task);
        maxHeapByPriority.Add(task);
    }

    // Edit the priority of an existing task. If the task does not exist, do nothing.
    public void Edit(int taskId, int newPriority)
    {
        bool isTaskAvailable = taskIdToTaskMap.TryGetValue(taskId, out var task);

        if (!isTaskAvailable || task == null)
            return;

        maxHeapByPriority.Remove(task);
        task.Priority = newPriority;
        maxHeapByPriority.Add(task);
    }

    // Remove a task from the manager. If the task does not exist, do nothing.
    public void Rmv(int taskId)
    {
        var isTaskAvailable = taskIdToTaskMap.TryGetValue(taskId, out var task);

        if (!isTaskAvailable || task == null)
            return;

        taskIdToTaskMap.Remove(taskId);
        maxHeapByPriority.Remove(task);
    }

    // Return the userId of the task with the highest priority and remove it from the task manager. If there are no tasks, return -1.
    public int ExecTop()
    {
        if (maxHeapByPriority.Count == 0 || maxHeapByPriority.Min == null)
            return -1;

        var topTask = maxHeapByPriority.Min;
        taskIdToTaskMap.Remove(topTask.TaskId);
        maxHeapByPriority.Remove(topTask);
        return topTask.UserId;
    }

    private Task CreateTask(int userId, int taskId, int priority)
    {
        return new Task(taskId, priority, userId);
    }

    private void Prepare(IList<IList<int>> tasks)
    {
        foreach (var taskInfo in tasks)
        {
            int userId = taskInfo[0];
            int taskId = taskInfo[1];
            int priority = taskInfo[2];

            Add(userId, taskId, priority);
        }
    }
}

public class Task : IComparable<Task>
{
    public int TaskId { get; set; }
    public int Priority { get; set; }
    public int UserId { get; set; }

    public Task(int taskId, int priority, int userId)
    {
        TaskId = taskId;
        Priority = priority;
        UserId = userId;
    }

    // Higher priority tasks should come first. If two tasks have the same priority, the task with the smaller taskId should come first.
    public int CompareTo(Task tastToCompare)
    {
        if (Priority != tastToCompare.Priority)
            return tastToCompare.Priority.CompareTo(Priority);

        return tastToCompare.TaskId.CompareTo(TaskId);
    }
}