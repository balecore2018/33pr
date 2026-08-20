using ChatStudents_Shapovalov.Classes;
using ChatStudents_Shapovalov.Models;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using ChatStudents_Shapovalov.Classes.Common;
using System.Linq;
using System.Windows.Threading;

namespace ChatStudents_Shapovalov.Pages
{
    public partial class Main : Page
    {
        /// <summary>Выбранный пользовательский диалог</summary>
        public Users SelectedUser = null;

        /// <summary>Контекст для работы с пользователями</summary>
        public UsersContext usersContext = new UsersContext();

        /// <summary>Контекст для работы с сообщениями</summary>
        public MessagesContext messagesContext = new MessagesContext();

        /// <summary>Таймер для обновления сообщений</summary>
        public DispatcherTimer Timer = new DispatcherTimer() { Interval = new System.TimeSpan(0, 0, 3) };

        public Main()
        {
            InitializeComponent();
            LoadUsers();
            // Подписываемся на событие выполнения
            Timer.Tick += Timer_Tick;
            // Запускаем таймер
            Timer.Start();
        }

        /// <summary>Загрузка пользователей</summary>
        public void LoadUsers()
        {
            // Перебираем пользователей
            foreach (Users user in usersContext.Users)
            {
                // Если пользователь не является авторизованным
                if(user.Id != MainWindow.Instance.LoginUser.Id)
                    // Выводим в интерфейс
                    ParentUsers.Children.Add(new Pages.Items.User(user, this));
            }
        }

        /// <summary>Обновление сообщений пользователя</summary>
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            // Если выбран пользовательский диалог
            if (SelectedUser != null)
                // Обновляем сообщения
                SelectUser(SelectedUser);
        }

        /// <summary>Выбор диалога</summary>
        public void SelectUser(Users User)
        {
            // Запоминаем выбранный диалог
            SelectedUser = User;
            // Показываем чат
            Chat.Visibility = Visibility.Visible;
            // Конвертируем изображение пользователя из массива байт в BitmapImage
            imgUser.Source = BitmapFromArrayByte.LoadImage(User.Photo);
            // Отображаем ФИО
            FIO.Content = User.ToFIO();
            // Очищаем сообщения в диалоге
            ParentMessages.Children.Clear();
            // Перебираем сообщения которые :
            // отправил выбранный пользователь авторизованному
            // или отправил авторизованный пользователь выбранному
            // сортируем по ID
            foreach (Messages Message in messagesContext.Messages.Where(x =>
                (x.UserFrom == User.Id && x.UserTo == MainWindow.Instance.LoginUser.Id) ||
                (x.UserFrom == MainWindow.Instance.LoginUser.Id && x.UserTo == User.Id)))
            {
                // Добавляем сообщение в диалог
                ParentMessages.Children.Add(new Pages.Items.Message(Message, usersContext.Users.Where(x => x.Id == Message.UserFrom).First()));
            }
        }

        /// <summary>Отправка сообщения пользователю</summary>
        private void Send(object sender, KeyEventArgs e)
        {
            // Если нажата клавиша Enter
            if (e.Key == Key.Enter)
            {
                // Создаём сообщение, где отправитель мы, а получатель выбранный диалог
                Messages message = new Messages(
                    MainWindow.Instance.LoginUser.Id,
                    SelectedUser.Id,
                    Message.Text
                    );
                // Добавляем сообщения в контекст
                messagesContext.Messages.Add(message);
                // Сохраняем изменения
                messagesContext.SaveChanges();
                // Добавляем сообщения на экран
                ParentMessages.Children.Add(new Pages.Items.Message(message, MainWindow.Instance.LoginUser));
                // Очищаем поле ввода
                Message.Text = "";
            }
        }
    }
}
