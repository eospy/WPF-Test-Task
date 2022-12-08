# WPF-Test-Task
Клиент-серверное приложение для отслеживания работы пользователя с мышью(перемещение на 10 пикселей по любой из осей, нажатие кнопок).
Функционал приложения:
1) Клиент - авторизация, регистрация, управление началом записи, фильтрация записей по дате и типу события, отправка количества событий мыши на заданный адрес;
2) Сервер - авторизация, регистрация, прием и сохранение в бд событий мыши, отправка количества событий мыши на заданный адрес,логгинг обращений к бд и серверу.

Технологический стек:
1) Клиент: WPF .NET 6.0 приложение созданное по шаблону MVVM;
2) Веб-API приложение на ASP.NET Core, БД Sqlite с ADO Entity Framework.