using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskUI : MonoBehaviour
{
    [Header("UI References")]
    public TaskManager taskManager;
    public Transform taskListParent;
    public GameObject taskItemPrefab;

    [Header("Create Task Panel")]
    public TMP_InputField titleInput;
    public TMP_InputField descriptionInput;
    public Button createButton;
    public Button loadButton;

    [Header("Edit Panel")]
    public GameObject editPanel;
    public TMP_InputField editTitleInput;
    public TMP_InputField editDescriptionInput;
    public Button saveEditButton;
    public Button cancelEditButton;
    private Task taskBeingEdited;

    [Header("Status")]
    public TextMeshProUGUI statusText;

    private List<GameObject> currentTaskItems = new List<GameObject>();

    private void Start()
    {
        // Subscribe to TaskManager events
        if (taskManager != null)
        {
            taskManager.OnTasksLoaded += DisplayTasks;
            taskManager.OnTaskCreated += OnTaskCreated;
            taskManager.OnTaskUpdated += OnTaskUpdated;
            taskManager.OnTaskDeleted += OnTaskDeleted;
            taskManager.OnError += OnError;
        }

        // Setup UI buttons
        if (createButton != null) createButton.onClick.AddListener(CreateNewTask);
        if (loadButton != null) loadButton.onClick.AddListener(LoadTasks);
        if (saveEditButton != null) saveEditButton.onClick.AddListener(SaveEditTask);
        if (cancelEditButton != null) cancelEditButton.onClick.AddListener(CancelEdit);

        UpdateStatus("Ready to connect to server...");


    }

    private void OnDestroy()
    {
        // Unsubscribe from events
        if (taskManager != null)
        {
            taskManager.OnTasksLoaded -= DisplayTasks;
            taskManager.OnTaskCreated -= OnTaskCreated;
            taskManager.OnTaskUpdated -= OnTaskUpdated;
            taskManager.OnTaskDeleted -= OnTaskDeleted;
            taskManager.OnError -= OnError;
        }
    }

    #region UI Actions

    public void LoadTasks()
    {
        UpdateStatus("Loading tasks...");
        taskManager.LoadAllTasks();
    }

    public void CreateNewTask()
    {
        if (string.IsNullOrEmpty(titleInput.text))
        {
            UpdateStatus("Please enter a task title!");
            return;
        }

        UpdateStatus("Creating task...");
        taskManager.CreateTask(titleInput.text, descriptionInput.text, false);
    }

    public void DeleteTask(int taskId)
    {
        UpdateStatus($"Deleting task {taskId}...");
        taskManager.DeleteTask(taskId);
    }

    public void ToggleTask(Task task)
    {
        UpdateStatus($"Updating task {task.id}...");
        taskManager.ToggleTaskCompletion(task);
    }

    public void UpdateTaskItem(int taskId, string newTitle, string newDescription, bool completed)
    {
        if (newTitle == null || newDescription == null) return;

        if (taskManager != null)
        {
            taskManager.UpdateTask(taskId, newTitle, newDescription, completed);
        }
        else
        {
            Debug.Log("❌ TaskManager non assegnato in TaskUI!");
        }
    }

    public void OpenEditPanel(Task task)
    {
        taskBeingEdited = task;

        editPanel.SetActive(true);
        editTitleInput.text = task.title;
        editDescriptionInput.text = task.description;
    }

    public void SaveEditTask()
    {
        if (taskBeingEdited == null)
        {
            Debug.LogWarning("⚠️ Nessuna task da modificare!");
            return;
        }

        string newTitle = editTitleInput.text;
        string newDescription = editDescriptionInput.text;

        taskBeingEdited.title = newTitle;
        taskBeingEdited.description = newDescription;

        // Aggiorna su server tramite TaskManager
        taskManager.UpdateTask(taskBeingEdited.id, newTitle, newDescription, taskBeingEdited.completed);

        // Aggiorna la UI locale
        taskManager.LoadAllTasks();

        editPanel.SetActive(false);
        taskBeingEdited = null;
    }

    public void CancelEdit()
    {
        Debug.Log($"Annullo le modifiche");
        editPanel.SetActive(false);
        taskBeingEdited = null;
    }

    #endregion

    #region Event Handlers

    private void DisplayTasks(List<Task> tasks)
    {
        // Clear existing task items
        foreach (GameObject item in currentTaskItems)
        {
            if (item != null)
                Destroy(item);
        }
        currentTaskItems.Clear();

        // Create new task items
        foreach (Task task in tasks)
        {
            CreateTaskItem(task);
        }

        UpdateStatus($"Loaded {tasks.Count} tasks");
    }

    private void OnTaskCreated(Task task)
    {
        UpdateStatus($"Task created: {task.title}");
        // Clear input fields
        titleInput.text = "";
        descriptionInput.text = "";
        // Refresh the list
        LoadTasks();
    }

    private void OnTaskUpdated(Task task)
    {
        UpdateStatus($"Task updated: {task.title}");
        // Refresh the list
        LoadTasks();
    }

    private void OnTaskDeleted(string message)
    {
        UpdateStatus($"{message}");
        // Refresh the list
        LoadTasks();
    }

    private void OnError(string error)
    {
        UpdateStatus($"{error}");
    }
    #endregion

    #region Helper Methods

    private void CreateTaskItem(Task task)
    {
        if (taskItemPrefab == null || taskListParent == null) return;

        GameObject taskItem = Instantiate(taskItemPrefab, taskListParent);
        currentTaskItems.Add(taskItem);

        // Get TaskItem component (you'll need to create this)
        TaskItem taskItemComponent = taskItem.GetComponent<TaskItem>();

        if (taskItemComponent != null)
        {
            taskItemComponent.Setup(task, this);
        }
        else
        {
            // Fallback: try to find text components directly
            TextMeshProUGUI[] texts = taskItem.GetComponentsInChildren<TextMeshProUGUI>();
            if (texts.Length >= 2)
            {
                texts[0].text = task.title;
                texts[1].text = task.description;
            }

            // Try to find toggle for completion status
            Toggle toggle = taskItem.GetComponentInChildren<Toggle>();
            if (toggle != null)
            {
                toggle.isOn = task.completed;
                toggle.onValueChanged.AddListener((bool isOn) =>
                {
                    ToggleTask(task);
                });
            }

            // Try to find delete button
            Button deleteButton = taskItem.GetComponentInChildren<Button>();
            if (deleteButton != null)
            {
                deleteButton.onClick.AddListener(() => DeleteTask(task.id));
            }
        }
    }

    private void UpdateStatus(string message)
    {
        if (statusText != null)
            statusText.text = message;

        Debug.Log($"[TaskUI] {message}");
    }
    #endregion
}