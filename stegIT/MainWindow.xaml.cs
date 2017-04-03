using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace stegIT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string img;
        public string arch;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|MP3 Files (*.mp3)|*.mp3";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // set the value of 'img' to the full path of the image 
                img = dlg.FileName;
                textBox1.Text = "Loaded";
                //enabling the button to select archive
                button2.IsEnabled = true;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".7z";
            dlg.Filter = "ZIP Files (*.zip)|*.zip|7zip Files (*.7z)|*.7z|RAR Files (*.rar)|*.rar|TAR Files (*.tar)|*.tar";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // set the value of 'arch' to the full path of the archive 
                arch = dlg.FileName;
                textBox2.Text = "Loaded";
                //enabling the button to call CombineFiles function.
                button3.IsEnabled = true;
            }
        }

        //Clicking on StegIT! button
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            //calls the CombineFiles function using the paths of the image and the archive
            CombineFiles(img, arch);
            //Showing a message box saying DONE
            MessageBox.Show("Done!");
            //Terminating the application after clicking OK
            Close();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        // Function that BinaryCopies the files (called Streaming apparently)
        private void CombineFiles(string imgFileName, string archFileName)
        {
            using (Stream original = new FileStream(imgFileName, FileMode.Append))
            {
                using (Stream extra = new FileStream(archFileName, FileMode.Open, FileAccess.Read))
                {
                    var buffer = new byte[32 * 1024];

                    int blockSize;
                    while ((blockSize = extra.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        original.Write(buffer, 0, blockSize);
                    }
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AboutBox1 aboutWindow = new AboutBox1();
            aboutWindow.Show();
        }
    }
}
