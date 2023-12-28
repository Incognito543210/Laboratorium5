using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Emgu;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Image<Bgr,byte> img = new Image<Bgr,byte>("E:\\VisualStudio\\Project\\lab5\\lab5\\image.png");
          Image<Gray,byte> img2 = img.Convert<Gray,byte>();
            Image<Gray, Single> img3 = (img2.Sobel(1, 0, 5));

            Image<Bgr, byte> sepiaImage = img.Copy();
            CvInvoke.CvtColor(img, sepiaImage, ColorConversion.Bgr2Gray);
            CvInvoke.CvtColor(sepiaImage, sepiaImage, ColorConversion.Gray2Bgr);
            CvInvoke.AddWeighted(sepiaImage, 0.5, img, 0.5, 0, sepiaImage);

            Image<Bgr, byte> invertedImage = img.Copy();
            CvInvoke.BitwiseNot(img, invertedImage);

            Image<Gray, byte> grayImage = img.Convert<Gray, byte>();
            Image<Gray, byte> thresholdedImage = grayImage.CopyBlank();
            CvInvoke.Threshold(grayImage, thresholdedImage, 128, 255, ThresholdType.Binary);

            CvInvoke.Imshow("Original Image", img);
            CvInvoke.Imshow("Sepia Filter", sepiaImage);
            CvInvoke.Imshow("Inverted Colors", invertedImage);
            CvInvoke.Imshow("Thresholded Image", thresholdedImage);
            CvInvoke.WaitKey(0);
        }
    }
}