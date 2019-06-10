using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ResearchHub
{
    public class ReadPort
    {
        String[] fields = {"Artificial Intelligence", "Security & Privacy",
            "Computer Graphics, Vision, Animation, & Game Science", "Computing for Development",
            "Computational & Synthetic Biology", "Theory of Computation",
            "Wireless & Sensor Systems", "Robotics",
            "Human Computer Interaction & Accessible Technology", "Augmented & Virtual Reality",
            "Machine Learning", "Data Management & Visualization",
            "Computer Architecture", "Fabrication",
            "Data Science", "Systems & Networking",
            "Molecular Information Systems", "Natural Language Processing",
            "Ubiquitous Computing", "Programming Languages & Software Engineering"};
        private SerialPort port;
        public ReadPort()
        {/*
            port = new SerialPort();
            port.BaudRate = 9600;
            port.PortName = "COM3";
            port.DiscardNull = true;
            port.DtrEnable = true;
            port.Open();*/
        }

        public string read() {
            return "";
            /*
            string serialRead = port.ReadLine();
            if (serialRead == null) return "none";
            for (int i = 0; i < 20; i ++) {
                if (fields[i].Contains(serialRead)) return fields[i];
            }
            return "default";*/
        }
    }
}
