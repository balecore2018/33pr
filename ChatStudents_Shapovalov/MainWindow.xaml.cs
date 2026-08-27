using ChatStudents_Shapovalov.Models;
using System.Windows;
using System.Windows.Controls;

namespace ChatStudents_Shapovalov
{
    public partial class MainWindow : Window
    {
        /// <summary>Ссылка на главное окно</summary>
        public static MainWindow Instance;

        /// <summary>Авторизированный пользователь</summary>
        public Users LoginUser = null;

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            // Открываем страницу авторизации
            OpenPages(new Pages.Login());
        }

        /// <summary>Метод открытия страниц</summary>
        public void OpenPages(Page page) =>
            // Открываем страницу
            frame.Navigate(page);
    }
}
