﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Task = SimpleTODOLesson.Models.Task;

namespace MyApi.Infrastructure.EntitiesCongiruration
{
    public class TaskSeed : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> modelBuilder)
        {
            modelBuilder.HasData(
                new Task() { Id = 1, Title = "Нужно срочно допилить сайт", Description = "Зубы стучат, ноги дрожат, руки крутятся, нервишки мутятся, сегодня я точно его доделаю", EndDate = new DateTime(2024, 2, 3, 12, 30, 0), UserId = 1, StatusId = 1 },
                new Task() { Id = 2, Title = "Подготовить отчет для босса", Description = "Собрать все необходимые данные и подготовить детальный отчет", EndDate = new DateTime(2024, 2, 5, 15, 0, 0), UserId = 2, StatusId = 2 },
                new Task() { Id = 3, Title = "Заказать канцелярские принадлежности", Description = "Проверить запасы и сделать заказ на нужные офисные материалы", EndDate = new DateTime(2024, 2, 7, 10, 0, 0), UserId = 3, StatusId = 3 },
                new Task() { Id = 4, Title = "Подготовить презентацию для клиента", Description = "Создать презентацию и подготовить все необходимые материалы для встречи с клиентом", EndDate = new DateTime(2024, 2, 10, 14, 0, 0), UserId = 4, StatusId = 1 },
                new Task() { Id = 5, Title = "Пройти онлайн-курс по новым технологиям", Description = "Зарегистрироваться и успешно завершить курс по новым технологиям до указанной даты", EndDate = new DateTime(2024, 2, 15, 18, 0, 0), UserId = 5, StatusId = 2 },
                new Task() { Id = 6, Title = "Улучшить дизайн личного блога", Description = "Обновить внешний вид блога, добавить новые функции и улучшить пользовательский опыт", EndDate = new DateTime(2024, 2, 20, 12, 0, 0), UserId = 6, StatusId = 3 },
                new Task() { Id = 7, Title = "Записаться на тренировки в фитнес-центре", Description = "Выбрать подходящие тренировки и записаться на них", EndDate = new DateTime(2024, 2, 25, 16, 0, 0), UserId = 7, StatusId = 1 },
                new Task() { Id = 8, Title = "Планирование отпуска", Description = "Решить место и даты отпуска, подготовить все необходимые документы", EndDate = new DateTime(2024, 3, 1, 10, 0, 0), UserId = 8, StatusId = 2 },
                new Task() { Id = 9, Title = "Организовать корпоративное мероприятие", Description = "Составить план, выбрать место проведения и организовать корпоративное мероприятие для сотрудников", EndDate = new DateTime(2024, 3, 5, 14, 0, 0), UserId = 9, StatusId = 3 },
                new Task() { Id = 10, Title = "Изучить новый язык программирования", Description = "Выбрать язык программирования, найти курсы и начать изучение", EndDate = new DateTime(2024, 3, 10, 18, 0, 0), UserId = 10, StatusId = 1 },
                new Task() { Id = 11, Title = "Создать прототип нового приложения", Description = "Разработать макет нового приложения, определить основные функциональные требования", EndDate = new DateTime(2024, 2, 10, 15, 0, 0), UserId = 1, StatusId = 2 },
                new Task() { Id = 12, Title = "Подготовить план маркетинговых мероприятий", Description = "Составить стратегию маркетинга, определить каналы продвижения продукции", EndDate = new DateTime(2024, 2, 15, 12, 0, 0), UserId = 2, StatusId = 3 },
                new Task() { Id = 13, Title = "Завершить написание статьи для блога", Description = "Дописать последние разделы статьи, провести редактирование и опубликовать", EndDate = new DateTime(2024, 2, 20, 14, 0, 0), UserId = 3, StatusId = 1 },
                new Task() { Id = 14, Title = "Организовать вебинар по теме искусственного интеллекта", Description = "Подготовить материалы, выбрать платформу для проведения вебинара и провести мероприятие", EndDate = new DateTime(2024, 2, 25, 18, 0, 0), UserId = 4, StatusId = 2 },
                new Task() { Id = 15, Title = "Провести тестирование новой функциональности", Description = "Подготовить тестовые сценарии, провести тестирование и выявить возможные ошибки", EndDate = new DateTime(2024, 3, 1, 10, 0, 0), UserId = 5, StatusId = 3 },
                new Task() { Id = 16, Title = "Обновить дизайн личного портфолио", Description = "Добавить новые проекты, улучшить навигацию и обновить дизайн портфолио", EndDate = new DateTime(2024, 3, 5, 14, 0, 0), UserId = 6, StatusId = 1 },
                new Task() { Id = 17, Title = "Провести собрание команды", Description = "Обсудить текущие задачи, выявить проблемы и предложить решения", EndDate = new DateTime(2024, 3, 10, 18, 0, 0), UserId = 7, StatusId = 2 },
                new Task() { Id = 18, Title = "Подготовить протокол совещания", Description = "Зафиксировать ключевые моменты собрания, подготовить протокол и распределить задачи", EndDate = new DateTime(2024, 3, 15, 12, 0, 0), UserId = 8, StatusId = 3 },
                new Task() { Id = 19, Title = "Провести обучение новых сотрудников", Description = "Разработать обучающую программу, провести вводное обучение и поддерживать новых членов команды", EndDate = new DateTime(2024, 3, 20, 14, 0, 0), UserId = 9, StatusId = 1 },
                new Task() { Id = 20, Title = "Оценить эффективность маркетинговой кампании", Description = "Анализировать данные маркетинговых показателей, выявлять тенденции и предложить улучшения", EndDate = new DateTime(2024, 3, 25, 18, 0, 0), UserId = 10, StatusId = 2 },
                new Task() { Id = 21, Title = "Подготовить презентацию для конференции", Description = "Создать содержательную презентацию и подготовиться к выступлению", EndDate = new DateTime(2024, 4, 1, 10, 0, 0), UserId = 1, StatusId = 3 },
                new Task() { Id = 22, Title = "Разработать стратегию продаж", Description = "Определить цели продаж, выбрать стратегии и разработать план выполнения", EndDate = new DateTime(2024, 4, 5, 14, 0, 0), UserId = 2, StatusId = 1 },
                new Task() { Id = 23, Title = "Провести аудит безопасности системы", Description = "Проверить уязвимости, оценить уровень безопасности и предложить улучшения", EndDate = new DateTime(2024, 4, 10, 18, 0, 0), UserId = 3, StatusId = 2 },
                new Task() { Id = 24, Title = "Разработать новую функциональность приложения", Description = "Составить техническое задание, написать код и провести тестирование", EndDate = new DateTime(2024, 4, 15, 12, 0, 0), UserId = 4, StatusId = 3 },
                new Task() { Id = 25, Title = "Оптимизировать процессы в отделе продаж", Description = "Анализировать текущие процессы, выявлять узкие места и предлагать оптимизации", EndDate = new DateTime(2024, 4, 20, 14, 0, 0), UserId = 5, StatusId = 1 },
                new Task() { Id = 26, Title = "Подготовиться к переговорам с партнерами", Description = "Изучить партнеров, определить ключевые моменты и подготовить стратегию переговоров", EndDate = new DateTime(2024, 4, 25, 18, 0, 0), UserId = 6, StatusId = 2 },
                new Task() { Id = 27, Title = "Реализовать систему обратной связи для клиентов", Description = "Создать механизм сбора отзывов, анализировать результаты и внедрить улучшения", EndDate = new DateTime(2024, 5, 1, 10, 0, 0), UserId = 7, StatusId = 3 },
                new Task() { Id = 28, Title = "Подготовиться к выставке в отрасли", Description = "Определить необходимые ресурсы, создать стенд и подготовить презентационные материалы", EndDate = new DateTime(2024, 5, 5, 14, 0, 0), UserId = 8, StatusId = 1 },
                new Task() { Id = 29, Title = "Разработать систему мотивации для сотрудников", Description = "Составить программу поощрений, провести обучение и внедрить систему", EndDate = new DateTime(2024, 5, 10, 18, 0, 0), UserId = 9, StatusId = 2 },
                new Task() { Id = 30, Title = "Обновить дизайн корпоративного сайта", Description = "Выбрать новый дизайн, обновить контент и оптимизировать пользовательский интерфейс", EndDate = new DateTime(2024, 5, 15, 12, 0, 0), UserId = 10, StatusId = 3 },
                new Task() { Id = 31, Title = "Провести обучение по новым стандартам безопасности", Description = "Подготовить учебные материалы, провести обучение сотрудников и провести тестирование знаний", EndDate = new DateTime(2024, 6, 1, 10, 0, 0), UserId = 1, StatusId = 1 },
                new Task() { Id = 32, Title = "Реализовать систему автоматизации бизнес-процессов", Description = "Анализировать текущие бизнес-процессы, определить автоматизируемые этапы и внедрить систему", EndDate = new DateTime(2024, 6, 5, 14, 0, 0), UserId = 2, StatusId = 2 },
                new Task() { Id = 33, Title = "Подготовить материалы для участия в выставке", Description = "Создать презентацию, брошюры и другие материалы для представления компании на выставке", EndDate = new DateTime(2024, 6, 10, 18, 0, 0), UserId = 3, StatusId = 3 },
                new Task() { Id = 34, Title = "Оценить эффективность рекламной кампании", Description = "Анализировать показатели эффективности рекламы, выявлять ключевые успехи и провалы", EndDate = new DateTime(2024, 6, 15, 12, 0, 0), UserId = 4, StatusId = 1 },
                new Task() { Id = 35, Title = "Провести тренинг по командной работе", Description = "Определить ключевые аспекты успешной командной работы, провести тренинг и укрепить командный дух", EndDate = new DateTime(2024, 6, 20, 14, 0, 0), UserId = 5, StatusId = 2 },
                new Task() { Id = 36, Title = "Подготовить кампанию по сбору обратной связи от клиентов", Description = "Разработать стратегию сбора отзывов, определить инструменты и подготовить коммуникационные материалы", EndDate = new DateTime(2024, 6, 25, 18, 0, 0), UserId = 6, StatusId = 3 },
                new Task() { Id = 37, Title = "Оптимизировать логистические процессы", Description = "Анализировать текущие логистические схемы, выявлять узкие места и предложить оптимизации", EndDate = new DateTime(2024, 7, 1, 10, 0, 0), UserId = 7, StatusId = 1 },
                new Task() { Id = 38, Title = "Разработать обучающий курс для клиентов", Description = "Создать учебный материал, определить ключевые моменты и провести обучение", EndDate = new DateTime(2024, 7, 5, 14, 0, 0), UserId = 8, StatusId = 2 },
                new Task() { Id = 39, Title = "Оценить эффективность социальных медиа кампании", Description = "Анализировать реакцию аудитории в социальных сетях, выявлять тренды и рекомендовать улучшения", EndDate = new DateTime(2024, 7, 10, 18, 0, 0), UserId = 9, StatusId = 3 },
                new Task() { Id = 40, Title = "Провести анализ конкурентов", Description = "Изучить стратегии конкурентов, провести сравнительный анализ и предложить улучшения", EndDate = new DateTime(2024, 7, 15, 12, 0, 0), UserId = 10, StatusId = 1 });
        }
    }
}
