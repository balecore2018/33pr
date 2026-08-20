using ChatStudents_Shapovalov.Classes.Common;
using ChatStudents_Shapovalov.Models;
using System.Windows.Controls;

namespace ChatStudents_Shapovalov.Pages.Items
{
    public partial class User : UserControl
    {
        /// <summary>Пользователь которого отображаем</summary>
        Users user;

        /// <summary>Ссылка на главное окно</summary>
        Main main;

        public User(Users user, Main main)
        {
            InitializeComponent();
            // Запоминаем пользователя которого отображаем
            this.user = user;
            // Запоминаем ссылку на главное окно
            this.main = main;
            // Конвертируем изображение из массива байт, в BitmapImage
            imgUser.Source = BitmapFromArrayByte.LoadImage(user.Photo);
            // Присваиваем ФИО
            FIO.Content = user.ToFIO();
        }

        /// <summary>Выбор диалога</summary>
        private void SelectChat(object sender, System.Windows.Input.MouseButtonEventArgs e) =>
            // При нажатии вызываем метод выбора пользователя на
            // главном окне, передавая выбранного пользователя
            main.SelectUser(user);
    }
}
