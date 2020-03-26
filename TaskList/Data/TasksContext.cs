using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using TaskList.Domain.Models;

namespace TaskList.Data
{
    public class TasksContext
    {
        private static readonly string _host = "https://localhost:5001/v1/tasks";

        internal static async System.Threading.Tasks.Task<List<Task>> GetTasks()
        {
            using var httpClient = new HttpClient();

            using var response = await httpClient.GetAsync($"{_host}\\get-tasks");

            var apiResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Task>>(apiResponse);
        }

        internal static async System.Threading.Tasks.Task<Task> AddTask(Task task)
        {
            using var httpClient = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync($"{_host}\\add-task", content);

            var apiResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Task>(apiResponse);
        }

        internal static async void UpdateTask(Task task)
        {
            using var httpClient = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync($"{_host}\\update-task", content);
        }
        internal static async System.Threading.Tasks.Task<Task> DeleteTask(int id)
        {
            using var httpClient = new HttpClient();

            using var response = await httpClient.GetAsync($"{_host}\\delete-task?id={id}");

            var str = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Task>(str);
        }

        internal static async System.Threading.Tasks.Task<Task> GetTask(int id)
        {
            using var httpClient = new HttpClient();

            using var response = await httpClient.GetAsync($"{_host}\\get-task?id={id}");

            var str = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Task>(str);
        }
    }
}