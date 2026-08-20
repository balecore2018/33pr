using ChatStudents_Shapovalov.Classes;
using ChatStudents_Shapovalov.Models;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ChatStudents_Shapovalov.Pages
{
    public partial class Login : Page
    {
        /// <summary>Изображение пользователя</summary>
        public string srcUserImage = "";

        /// <summary>Контекст пользователя</summary>
        UsersContext usersContext = new UsersContext();

        public Login()
        {
            InitializeComponent();
        }

        /// <summary>Выбор фотографии пользователя</summary>
        private void SelectPhoto(object sender, System.Windows.RoutedEventArgs e)
        {
            // Создаём файл диалог для выбора изображения
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Указываем название файлового диалога
            openFileDialog.Title = "Выберите фотографию:";
            // Указываем начальную директорию
            openFileDialog.InitialDirectory = @"C:\";
            // Указываем фильтры при которых можно выбрать файл
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All files (*.*)|*.*";
            // Если файл выбран
            if (openFileDialog.ShowDialog() == true)
            {
                // Указываем в качестве изображения
                imgUser.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                // Запоминаем выбранную фотографию
                srcUserImage = openFileDialog.FileName;
            }
        }

        /// <summary>Проверка на заполнение полей</summary>
        public bool CheckEmpty(string Pattern, string Input)
        {
            Match m = Regex.Match(Input, Pattern);
            return m.Success;
        }

        /// <summary>Переход на страницу с диалогами</summary>
        private void Continue(object sender, RoutedEventArgs e)
        {
            // Проверяем что пользователь указал фамилию
            if (!CheckEmpty("^[А-ЯЁ][а-яА-ЯёЁ]*$", Lastname.Text))
            {
                MessageBox.Show("Укажите фамилию.");
                return;
            }
            // Проверяем что пользователь указал имя
            if (!CheckEmpty("^[А-ЯЁ][а-яА-ЯёЁ]*$", Firstname.Text))
            {
                MessageBox.Show("Укажите имя.");
                return;
            }
            // Проверяем что пользователь указал отчество
            if (!CheckEmpty("^[А-ЯЁ][а-яА-ЯёЁ]*$", Surname.Text))
            {
                MessageBox.Show("Укажите отчество.");
                return;
            }
            // Проверяем что пользователь указал изображение
            if (String.IsNullOrEmpty(srcUserImage))
            {
                MessageBox.Show("Выберите изображение.");
                return;
            }
            // Обращаемся к БД и проверяем что пользователя с такими данными не существует
            if (usersContext.Users.Where(x => x.Firstname == Firstname.Text &&
                                              x.Lastname == Lastname.Text &&
                                              x.Surname == Surname.Text).Count() > 0)
            {
                // Получаем пользователя по ФИО
                MainWindow.Instance.LoginUser = usersContext.Users.Where(x => x.Firstname == Firstname.Text &&
                                                                              x.Lastname == Lastname.Text &&
                                                                              x.Surname == Surname.Text).First();
                // Изменяем пользователю фотографию
                MainWindow.Instance.LoginUser.Photo = File.ReadAllBytes(srcUserImage);
                // Сохраняем изменения
                usersContext.SaveChanges();
            }
            else
            {
                // Добавляем нового пользователя
                usersContext.Users.Add(new Users(Lastname.Text, Firstname.Text, Surname.Text, File.ReadAllBytes(srcUserImage)));
                // Сохраняем изменения
                usersContext.SaveChanges();
                // Получаем пользователя из БД
                MainWindow.Instance.LoginUser = usersContext.Users.Where(x => x.Firstname == Firstname.Text &&
                                                                              x.Lastname == Lastname.Text &&
                                                                              x.Surname == Surname.Text).First();
            }
            // Открываем главную страницу
            MainWindow.Instance.OpenPages(new Pages.Main());
        }
    }
}
