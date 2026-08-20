using ChatStudents_Shapovalov.Classes.Common;
using ChatStudents_Shapovalov.Models;
using System.Windows.Controls;

namespace ChatStudents_Shapovalov.Pages.Items
{
    /// <summary>Логика взаимодействия для Message.xaml</summary>
    public partial class Message : UserControl
    {
        public Message(Messages Messages, Users UserFrom)
        {
            InitializeComponent();
            // Конвертируем изображение пользователя из массива байт в BitmapImage
            imgUser.Source = BitmapFromArrayByte.LoadImage(UserFrom.Photo);
            // Получаем ФИО
            FIO.Content = UserFrom.ToFIO();
            // Отображаем изображение
            tbMessage.Text = Messages.Message;
        }
    }
}
