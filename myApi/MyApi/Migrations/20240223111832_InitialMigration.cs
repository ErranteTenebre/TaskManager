using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "TaskStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TaskStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Выполнена" },
                    { 2, "В процессе" },
                    { 3, "Ожидание" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Pass" },
                values: new object[,]
                {
                    { 1, "aidar", "1Exxydnaida" },
                    { 2, "jane.smith", "Pass1234" },
                    { 3, "robert.jones", "SecurePass" },
                    { 4, "emily.white", "StrongPassword" },
                    { 5, "alex.martin", "ComplexPass123" },
                    { 6, "olivia.brown", "Secure123" },
                    { 7, "david.miller", "MyPass567" },
                    { 8, "emma.wilson", "SecretPass" },
                    { 9, "william.jackson", "Password987" },
                    { 10, "sophia.davis", "NewPass123" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "EndDate", "StatusId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Зубы стучат, ноги дрожат, руки крутятся, нервишки мутятся, сегодня я точно его доделаю", new DateTime(2024, 2, 3, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, "Нужно срочно допилить сайт", 1 },
                    { 2, "Собрать все необходимые данные и подготовить детальный отчет", new DateTime(2024, 2, 5, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, "Подготовить отчет для босса", 2 },
                    { 3, "Проверить запасы и сделать заказ на нужные офисные материалы", new DateTime(2024, 2, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, "Заказать канцелярские принадлежности", 3 },
                    { 4, "Создать презентацию и подготовить все необходимые материалы для встречи с клиентом", new DateTime(2024, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, "Подготовить презентацию для клиента", 4 },
                    { 5, "Зарегистрироваться и успешно завершить курс по новым технологиям до указанной даты", new DateTime(2024, 2, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, "Пройти онлайн-курс по новым технологиям", 5 },
                    { 6, "Обновить внешний вид блога, добавить новые функции и улучшить пользовательский опыт", new DateTime(2024, 2, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, "Улучшить дизайн личного блога", 6 },
                    { 7, "Выбрать подходящие тренировки и записаться на них", new DateTime(2024, 2, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), 1, "Записаться на тренировки в фитнес-центре", 7 },
                    { 8, "Решить место и даты отпуска, подготовить все необходимые документы", new DateTime(2024, 3, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, "Планирование отпуска", 8 },
                    { 9, "Составить план, выбрать место проведения и организовать корпоративное мероприятие для сотрудников", new DateTime(2024, 3, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, "Организовать корпоративное мероприятие", 9 },
                    { 10, "Выбрать язык программирования, найти курсы и начать изучение", new DateTime(2024, 3, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), 1, "Изучить новый язык программирования", 10 },
                    { 11, "Разработать макет нового приложения, определить основные функциональные требования", new DateTime(2024, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, "Создать прототип нового приложения", 1 },
                    { 12, "Составить стратегию маркетинга, определить каналы продвижения продукции", new DateTime(2024, 2, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, "Подготовить план маркетинговых мероприятий", 2 },
                    { 13, "Дописать последние разделы статьи, провести редактирование и опубликовать", new DateTime(2024, 2, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, "Завершить написание статьи для блога", 3 },
                    { 14, "Подготовить материалы, выбрать платформу для проведения вебинара и провести мероприятие", new DateTime(2024, 2, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, "Организовать вебинар по теме искусственного интеллекта", 4 },
                    { 15, "Подготовить тестовые сценарии, провести тестирование и выявить возможные ошибки", new DateTime(2024, 3, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, "Провести тестирование новой функциональности", 5 },
                    { 16, "Добавить новые проекты, улучшить навигацию и обновить дизайн портфолио", new DateTime(2024, 3, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, "Обновить дизайн личного портфолио", 6 },
                    { 17, "Обсудить текущие задачи, выявить проблемы и предложить решения", new DateTime(2024, 3, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, "Провести собрание команды", 7 },
                    { 18, "Зафиксировать ключевые моменты собрания, подготовить протокол и распределить задачи", new DateTime(2024, 3, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, "Подготовить протокол совещания", 8 },
                    { 19, "Разработать обучающую программу, провести вводное обучение и поддерживать новых членов команды", new DateTime(2024, 3, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, "Провести обучение новых сотрудников", 9 },
                    { 20, "Анализировать данные маркетинговых показателей, выявлять тенденции и предложить улучшения", new DateTime(2024, 3, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, "Оценить эффективность маркетинговой кампании", 10 },
                    { 21, "Создать содержательную презентацию и подготовиться к выступлению", new DateTime(2024, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, "Подготовить презентацию для конференции", 1 },
                    { 22, "Определить цели продаж, выбрать стратегии и разработать план выполнения", new DateTime(2024, 4, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, "Разработать стратегию продаж", 2 },
                    { 23, "Проверить уязвимости, оценить уровень безопасности и предложить улучшения", new DateTime(2024, 4, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, "Провести аудит безопасности системы", 3 },
                    { 24, "Составить техническое задание, написать код и провести тестирование", new DateTime(2024, 4, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, "Разработать новую функциональность приложения", 4 },
                    { 25, "Анализировать текущие процессы, выявлять узкие места и предлагать оптимизации", new DateTime(2024, 4, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, "Оптимизировать процессы в отделе продаж", 5 },
                    { 26, "Изучить партнеров, определить ключевые моменты и подготовить стратегию переговоров", new DateTime(2024, 4, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, "Подготовиться к переговорам с партнерами", 6 },
                    { 27, "Создать механизм сбора отзывов, анализировать результаты и внедрить улучшения", new DateTime(2024, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, "Реализовать систему обратной связи для клиентов", 7 },
                    { 28, "Определить необходимые ресурсы, создать стенд и подготовить презентационные материалы", new DateTime(2024, 5, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, "Подготовиться к выставке в отрасли", 8 },
                    { 29, "Составить программу поощрений, провести обучение и внедрить систему", new DateTime(2024, 5, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, "Разработать систему мотивации для сотрудников", 9 },
                    { 30, "Выбрать новый дизайн, обновить контент и оптимизировать пользовательский интерфейс", new DateTime(2024, 5, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, "Обновить дизайн корпоративного сайта", 10 },
                    { 31, "Подготовить учебные материалы, провести обучение сотрудников и провести тестирование знаний", new DateTime(2024, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, "Провести обучение по новым стандартам безопасности", 1 },
                    { 32, "Анализировать текущие бизнес-процессы, определить автоматизируемые этапы и внедрить систему", new DateTime(2024, 6, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, "Реализовать систему автоматизации бизнес-процессов", 2 },
                    { 33, "Создать презентацию, брошюры и другие материалы для представления компании на выставке", new DateTime(2024, 6, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), 3, "Подготовить материалы для участия в выставке", 3 },
                    { 34, "Анализировать показатели эффективности рекламы, выявлять ключевые успехи и провалы", new DateTime(2024, 6, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, "Оценить эффективность рекламной кампании", 4 },
                    { 35, "Определить ключевые аспекты успешной командной работы, провести тренинг и укрепить командный дух", new DateTime(2024, 6, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, "Провести тренинг по командной работе", 5 },
                    { 36, "Разработать стратегию сбора отзывов, определить инструменты и подготовить коммуникационные материалы", new DateTime(2024, 6, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), 3, "Подготовить кампанию по сбору обратной связи от клиентов", 6 },
                    { 37, "Анализировать текущие логистические схемы, выявлять узкие места и предложить оптимизации", new DateTime(2024, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, "Оптимизировать логистические процессы", 7 },
                    { 38, "Создать учебный материал, определить ключевые моменты и провести обучение", new DateTime(2024, 7, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, "Разработать обучающий курс для клиентов", 8 },
                    { 39, "Анализировать реакцию аудитории в социальных сетях, выявлять тренды и рекомендовать улучшения", new DateTime(2024, 7, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), 3, "Оценить эффективность социальных медиа кампании", 9 },
                    { 40, "Изучить стратегии конкурентов, провести сравнительный анализ и предложить улучшения", new DateTime(2024, 7, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, "Провести анализ конкурентов", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskStatuses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
