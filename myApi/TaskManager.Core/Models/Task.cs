using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core.Models
{
    public class Task
    {
        private const int MAX_TITLE_LENGTH = 50;
        private const int MAX_DECRIPTION_LENGTH = 300;

        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }

        private Task(string title, string description, DateTime endDate, int userId, int statusId)
        {
            UserId = userId;
            StatusId = statusId;
            Title = title;
            Description = description;
            EndDate = endDate;
        }

        public static (Task task, string error) Create(string title, string description, DateTime endDate, int userId, int statusId)
        {
            string error = string.Empty;
            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = $"Заголовок задачи не может быть пустым или быть длинее {MAX_TITLE_LENGTH} символов";
            }

            Task task = new Task(title, description, endDate, userId, statusId);

            return (task, error);
        }
    }
}
