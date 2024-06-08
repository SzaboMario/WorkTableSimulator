using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTableSimulator
{
    internal class Axis : ChangeNotifier
    {
        //X
        private Rectangle _XRectangle;
        public Rectangle XRectangle
        {
            get { return _XRectangle; }
            set { _XRectangle = value; OnPropertyChanged(nameof(XRectangle)); }
        }

        private int _XMinPose;
        public int XMinPose
        {
            get { return _XMinPose; }
            set { _XMinPose = value; OnPropertyChanged(nameof(XMinPose)); }
        }

        private int _XMaxPose;
        public int XMaxPose
        {
            get { return _XMaxPose; }
            set { _XMaxPose = value; OnPropertyChanged(nameof(XMaxPose)); }
        }

        private int _XCurrPose;
        public int XCurrPose
        {
            get { return _XCurrPose; }
            set { _XCurrPose = value; OnPropertyChanged(nameof(XCurrPose)); }
        }


        //Y
        private Rectangle _YRectangle;
        public Rectangle YRectangle
        {
            get { return _YRectangle; }
            set { _YRectangle = value; OnPropertyChanged(nameof(YRectangle)); }
        }

        private int _YMinPose;
        public int YMinPose
        {
            get { return _YMinPose; }
            set { _YMinPose = value; OnPropertyChanged(nameof(YMinPose)); }
        }

        private int _YMaxPose;
        public int YMaxPose
        {
            get { return _YMaxPose; }
            set { _YMaxPose = value; OnPropertyChanged(nameof(YMaxPose)); }
        }

        private int _YCurrPose;
        public int YCurrPose
        {
            get { return _YCurrPose; }
            set { _YCurrPose = value; OnPropertyChanged(nameof(YCurrPose)); }
        }


        //Z
        private Rectangle _ZRectangle;
        public Rectangle ZRectangle
        {
            get { return _ZRectangle; }
            set { _ZRectangle = value; OnPropertyChanged(nameof(ZRectangle)); }
        }

        private int _ZMinPose;
        public int ZMinPose
        {
            get { return _ZMinPose; }
            set { _ZMinPose = value; OnPropertyChanged(nameof(ZMinPose)); }
        }

        private int _ZMaxPose;
        public int ZMaxPose
        {
            get { return _ZMaxPose; }
            set { _ZMaxPose = value; OnPropertyChanged(nameof(ZMaxPose)); }
        }

        private int _ZCurrPose;
        public int ZCurrPose
        {
            get { return _ZCurrPose; }
            set { _ZCurrPose = value; OnPropertyChanged(nameof(ZCurrPose)); }
        }

        public Axis() { }
    }
}
