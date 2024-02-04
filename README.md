Требования для запуска проекта:
1.Visual studio
2.Sql Server
3.Node js

Подготовка проекта:
1.Клонируйте репозиторий
2.Откройте папку clientApp в терминале, установите пакеты node js (npm install)
3.Откройте решение MyApi.sln в Visual Studio. Восстановите nuget-пакеты (dotnet restore)
4.Создайте базу данных в sql server. В appsettins.json измените строку подключения на свою
5.Примените миграции, запустив команду dotnet ef database update

Запуск проекта:
1.Запустите сервер через Visual studio через https.
2.Запустите клиентское приложение через терминал (npm start)
